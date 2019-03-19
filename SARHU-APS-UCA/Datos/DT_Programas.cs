using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Collections.Generic;

namespace Datos
{
    public class DT_Programas : I_CRUD<Programa>
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();
        private SqlDataAdapter adaptadorSql = null;

        private static DT_Programas dtProgramas = null;

        private DT_Programas()
        {
            //Singleton
        }

        public static DT_Programas Instanciar()
        {
            if (dtProgramas == null)
            {
                dtProgramas = new DT_Programas();
            }
            return dtProgramas;
        }

        // METODOS

        /// <summary>
        /// El método permite agregar un registro de la entidad [Programa].
        /// Recibe como parámetro un objeto [Programa] con la información a agregar a la base de datos (Nombre y Descripción).
        /// Devuelve un valor booleano para notificar si el registro fue agregado o no.
        /// </summary>
        public bool Agregar(Programa obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.ProgramasAgregar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@programa_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@programa_descripcion", SqlDbType.VarChar).Value = obj.Descripcion;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int agregado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (agregado > 0);
        }

        /// <summary>
        /// El método permite borrar un registro de la entidad [Programa].
        /// Recibe como parámetro el id [int] del registro a borrar en la base de datos.
        /// Devuelve un valor booleano para notificar si el registro fue borrado o no.
        /// </summary>
        public bool Borrar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.ProgramasBorrar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@programa_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int borrado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (borrado > 0);
        }

        /// <summary>
        /// El método permite consultar/buscar un registro de la entidad [Programa].
        /// Recibe como parámetro el id [int] del registro a consultar/buscar en la base de datos.
        /// Devuelve un objeto [Programa] nulo en caso de no encontrarse, o con la información del registro en caso que exista.
        /// </summary>
        public Programa Consultar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.ProgramasConsultar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@programa_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
            Programa programa = new Programa();

            while (reader.Read())
            {
                programa.Id = reader.GetInt32(0);
                programa.Nombre = reader.GetString(1);
                programa.Descripcion = reader.GetString(2);
            }
            reader.Close();

            conexionSql.Close();

            return programa;
        }

        /// <summary>
        /// El método permite editar un registro de la entidad [Programa].
        /// Recibe como parámetro un objeto [Programa] con la información editada para actualizarse en la base de datos (Nombre y Descripción).
        /// Devuelve un valor booleano para notificar si el registro fue editado o no.
        /// </summary>
        public bool Editar(Programa obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.ProgramasEditar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@programa_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@programa_descripcion", SqlDbType.VarChar).Value = obj.Descripcion;
            comandoSql.Parameters.Add("@programa_id", SqlDbType.Int).Value = obj.Id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int editado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (editado > 0);
        }

        /// <summary>
        /// El método permite obtener la lista de registros de la entidad [Programa] desde la base de datos.
        /// Los campos que se devuelven son: Id, Nombre y Descripción.
        /// En caso de no existir ningún registro se devuelve una lista nula o vacía.
        /// </summary>
        public List<Programa> Listar()
        {
            List<Programa> programas = new List<Programa>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.ProgramasListar;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
            Programa p = new Programa();

            while (reader.Read())
            {
                p.Id = reader.GetInt32(0);
                p.Nombre = reader.GetString(1);
                p.Descripcion = reader.GetString(2);

                programas.Add(p);
            }
            reader.Close();

            conexionSql.Close();

            return programas;
        }
    }
}
