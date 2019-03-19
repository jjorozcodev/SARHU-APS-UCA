using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Collections.Generic;

namespace Datos
{
    public class DT_Funciones : I_CRUD<Funcion>
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();
        private SqlDataAdapter adaptadorSql = null;

        private static DT_Funciones dtFunciones = null;

        private DT_Funciones()
        {
            //Singleton
        }

        public static DT_Funciones Instanciar()
        {
            if (dtFunciones == null)
            {
                dtFunciones = new DT_Funciones();
            }
            return dtFunciones;
        }

        // METODOS

        /// <summary>
        /// El método permite agregar un registro de la entidad [Funcion].
        /// Recibe como parámetro un objeto [Funcion] con la información a agregar a la base de datos (Nombre y Descripción).
        /// Devuelve un valor booleano para notificar si el registro fue agregado o no.
        /// </summary>
        public bool Agregar(Funcion obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.FuncionesAgregar;

            comandoSql.Parameters.Add("@funcion_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@funcion_descripcion", SqlDbType.VarChar).Value = obj.Descripcion;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int agregado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (agregado > 0);
        }

        /// <summary>
        /// El método permite borrar un registro de la entidad [Funcion].
        /// Recibe como parámetro el id [int] del registro a borrar en la base de datos.
        /// Devuelve un valor booleano para notificar si el registro fue borrado o no.
        /// </summary>
        public bool Borrar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.FuncionesBorrar;

            comandoSql.Parameters.Add("@funcion_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int borrado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (borrado > 0);
        }

        /// <summary>
        /// El método permite consultar/buscar un registro de la entidad [Funcion].
        /// Recibe como parámetro el id [int] del registro a consultar/buscar en la base de datos.
        /// Devuelve un objeto [Funcion] nulo en caso de no encontrarse, o con la información del registro en caso que exista.
        /// </summary>
        public Funcion Consultar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.FuncionesConsultar;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
            Funcion funcion = new Funcion();

            while (reader.Read())
            {
                funcion.Id = reader.GetInt32(0);
                funcion.Nombre = reader.GetString(1);
                funcion.Descripcion = reader.GetString(2);
            }
            reader.Close();

            conexionSql.Close();

            return funcion;
        }

        /// <summary>
        /// El método permite editar un registro de la entidad [Funcion].
        /// Recibe como parámetro un objeto [Funcion] con la información editada para actualizarse en la base de datos (Nombre y Descripción).
        /// Devuelve un valor booleano para notificar si el registro fue editado o no.
        /// </summary>
        public bool Editar(Funcion obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.FuncionesEditar;

            comandoSql.Parameters.Add("@funcion_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@funcion_descripcion", SqlDbType.VarChar).Value = obj.Descripcion;
            comandoSql.Parameters.Add("@funcion_id", SqlDbType.Int).Value = obj.Id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int editado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (editado > 0);
        }

        /// <summary>
        /// El método permite obtener la lista de registros de la entidad [Funcion] desde la base de datos.
        /// Los campos que se devuelven son: Id, Nombre y Descripción.
        /// En caso de no existir ningún registro se devuelve una lista nula o vacía.
        /// </summary>
        public List<Funcion> Listar()
        {
            List<Funcion> funciones = new List<Funcion>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.FuncionesListar;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
            Funcion f = new Funcion();

            while (reader.Read())
            {
                f.Id = reader.GetInt32(0);
                f.Nombre = reader.GetString(1);
                f.Descripcion = reader.GetString(2);

                funciones.Add(f);
            }
            reader.Close();

            conexionSql.Close();

            return funciones;
        }
    }
}
