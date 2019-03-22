using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Collections.Generic;

namespace Datos
{
    public class DT_Bonos : I_CRUD<Bono>
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();
        private List<Bono> bonos = new List<Bono>();

        private static DT_Bonos dtBonos = null;

        private DT_Bonos()
        {
            //Singleton
        }

        public static DT_Bonos Instanciar()
        {
            if (dtBonos == null)
            {
                dtBonos = new DT_Bonos();
            }
            return dtBonos;
        }

        // METODOS

        /// <summary>
        /// El método permite agregar un registro de la entidad [Bono].
        /// Recibe como parámetro un objeto [Bono] con la información a agregar a la base de datos (Nombre, Descripción y Monto).
        /// Devuelve un valor booleano para notificar si el registro fue agregado o no.
        /// </summary>
        public bool Agregar(Bono obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.BonosAgregar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@bono_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@bono_descripcion", SqlDbType.VarChar).Value = obj.Descripcion;
            comandoSql.Parameters.Add("@bono_monto", SqlDbType.Decimal).Value = obj.Monto;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int agregado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (agregado > 0);
        }

        /// <summary>
        /// El método permite borrar un registro de la entidad [Bono].
        /// Recibe como parámetro el id [int] del registro a borrar en la base de datos.
        /// Devuelve un valor booleano para notificar si el registro fue borrado o no.
        /// </summary>
        public bool Borrar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.BonosBorrar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@bono_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int borrado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (borrado > 0);
        }

        /// <summary>
        /// El método permite consultar/buscar un registro de la entidad [Bono].
        /// Recibe como parámetro el id [int] del registro a consultar/buscar en la base de datos.
        /// Devuelve un objeto [Bono] nulo en caso de no encontrarse, o con la información del registro en caso que exista.
        /// </summary>
        public Bono Consultar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.BonosConsultar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@bono_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
            Bono bono = new Bono();

            while (reader.Read())
            {
                bono.Id = id;
                bono.Nombre = reader.GetString(0);
                bono.Descripcion = reader.GetString(1);
                bono.Monto = reader.GetDecimal(2);
                bono.Estado = reader.GetBoolean(3);
            }
            reader.Close();

            conexionSql.Close();

            return bono;
        }

        /// <summary>
        /// El método permite editar un registro de la entidad [Bono].
        /// Recibe como parámetro un objeto [Bono] con la información editada para actualizarse en la base de datos (Nombre, Descripción y Monto).
        /// Devuelve un valor booleano para notificar si el registro fue editado o no.
        /// </summary>
        public bool Editar(Bono obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.BonosEditar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@bono_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@bono_descripcion", SqlDbType.VarChar).Value = obj.Descripcion;
            comandoSql.Parameters.Add("@bono_monto", SqlDbType.Decimal).Value = obj.Monto;
            comandoSql.Parameters.Add("@bono_id", SqlDbType.Int).Value = obj.Id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int editado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (editado > 0);
        }

        /// <summary>
        /// El método permite obtener la lista de registros de la entidad [Bono] desde la base de datos.
        /// Los campos que se devuelven son: Id, Nombre, Descripción y Monto.
        /// En caso de no existir ningún registro se devuelve una lista nula o vacía.
        /// </summary>
        public List<Bono> Listar()
        {
            List<Bono> listaBons = new List<Bono>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.BonosListar;

            comandoSql.Parameters.Clear();

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();            

            while (reader.Read())
            {
                Bono b = new Bono();
                b.Id = reader.GetInt32(0);
                b.Nombre = reader.GetString(1);
                b.Descripcion = reader.GetString(2);
                b.Monto = reader.GetDecimal(3);
                b.Estado = reader.GetBoolean(4);

                listaBons.Add(b);
            }
            reader.Close();

            conexionSql.Close();

            this.bonos.Clear();
            this.bonos = listaBons;

            return listaBons;
        }

        public List<Bono> ListarPorEstado(bool Estado)
        {
            // Actualizar
            Listar();

            List<Bono> bons = new List<Bono>();

            foreach (Bono b in bonos)
            {
                if (b.Estado == Estado)
                {
                    bons.Add(b);
                }
            }

            return bons;
        }
    }
}
