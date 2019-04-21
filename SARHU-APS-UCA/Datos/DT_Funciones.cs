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
        private List<Funcion> funciones = new List<Funcion>();

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
        public int Agregar(Funcion obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.FuncionesAgregar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@funcion_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@funcion_descripcion", SqlDbType.VarChar).Value = obj.Descripcion;

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }

            int idGenerado = int.Parse(comandoSql.ExecuteScalar().ToString());

            conexionSql.Close();

            return idGenerado;
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

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@funcion_id", SqlDbType.Int).Value = id;

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
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

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@funcion_id", SqlDbType.Int).Value = id;

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();

            Funcion funcion = new Funcion();

            while (reader.Read())
            {
                funcion.Id = id;
                funcion.Nombre = reader["funcion_nombre"].ToString();
                funcion.Descripcion = reader["funcion_descripcion"].ToString();
                funcion.Estado = bool.Parse(reader["funcion_estado"].ToString());
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

            comandoSql.Parameters.Clear();

            comandoSql.Parameters.Add("@funcion_id", SqlDbType.Int).Value = obj.Id;
            comandoSql.Parameters.Add("@funcion_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@funcion_descripcion", SqlDbType.VarChar).Value = obj.Descripcion;

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
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
            List<Funcion> listaFunciones = new List<Funcion>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.FuncionesListar;

            comandoSql.Parameters.Clear();

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
            
            while (reader.Read())
            {
                Funcion f = new Funcion();

                f.Id = int.Parse(reader["funcion_id"].ToString());
                f.Nombre = reader["funcion_nombre"].ToString();
                f.Descripcion = reader["funcion_descripcion"].ToString();
                f.Estado = bool.Parse(reader["funcion_estado"].ToString());

                listaFunciones.Add(f);
            }

            reader.Close();

            conexionSql.Close();

            this.funciones.Clear();
            this.funciones = listaFunciones;

            return listaFunciones;
        }

        public List<Funcion> ListarPorEstado(bool Estado)
        {
            // Actualizar
            Listar();

            List<Funcion> listFunciones = new List<Funcion>();

            foreach (Funcion f in funciones)
            {
                if (f.Estado == Estado)
                {
                    listFunciones.Add(f);
                }
            }

            return listFunciones;
        }
    }
}
