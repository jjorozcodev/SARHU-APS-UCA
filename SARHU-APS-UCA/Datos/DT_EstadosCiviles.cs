using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
using System.Data;

namespace Datos
{
    public class DT_EstadosCiviles : I_CRUD<EstadoCivil>
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();
        private List<EstadoCivil> estadosCiviles = new List<EstadoCivil>();

        private static DT_EstadosCiviles dtEstadosCiviles = null;

        private DT_EstadosCiviles()
        {
            //Singleton
        }

        public static DT_EstadosCiviles Instanciar()
        {
            if (dtEstadosCiviles == null)
            {
                dtEstadosCiviles = new DT_EstadosCiviles();
            }
            return dtEstadosCiviles;
        }

        // METODOS

        /// <summary>
        /// El método permite agregar un registro de la entidad [EstadoCivil].
        /// Recibe como parámetro un objeto [EstadoCivil] con la información a agregar a la base de datos.
        /// Devuelve un valor entero con el id generado.
        /// </summary>
        public int Agregar(EstadoCivil obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.EstadosCivilesAgregar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@estado_civil_nombre", SqlDbType.VarChar).Value = obj.Nombre;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int idGenerado = int.Parse(comandoSql.ExecuteScalar().ToString());

            conexionSql.Close();

            return idGenerado;
        }

        /// <summary>
        /// El método permite borrar un registro de la entidad [EstadoCivil].
        /// Recibe como parámetro el id [int] del registro a la base de datos.
        /// Devuelve un valor booleano para notificar si el registro fue borrado o no.
        /// </summary>
        public bool Borrar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.EstadosCivilesBorrar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@estado_civil_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int borrado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (borrado > 0);
        }

        /// <summary>
        /// El método permite consultar/buscar un registro de la entidad [EstadoCivil].
        /// Recibe como parámetro el id [int] del registro a consultar/buscar en la base de datos.
        /// Devuelve un objeto [EstadoCivil] nulo en caso de no encontrarse, o con la información del registro en caso que exista.
        /// </summary>
        public EstadoCivil Consultar(int id)
        {
            //comandoSql.Connection = conexionSql;
            //comandoSql.CommandType = CommandType.StoredProcedure;
            //comandoSql.CommandText = Procedimientos.EstadosCivilesConsultar;

            //comandoSql.Parameters.Clear();
            //comandoSql.Parameters.Add("@estado_civil_id", SqlDbType.Int).Value = id;

            //if (conexionSql.State == ConnectionState.Closed)
            //{
            //    conexionSql.Open();
            //}

            //SqlDataReader reader = comandoSql.ExecuteReader();

            //EstadoCivil estadoCivil = new EstadoCivil();

            //while (reader.Read())
            //{
            //    estadoCivil.Id = id;
            //    estadoCivil.Nombre = reader["estado_civil_nombre"].ToString();
            //    estadoCivil.Estado = bool.Parse(reader["estado_civil_estado"].ToString());
            //}

            //reader.Close();

            //conexionSql.Close();

            EstadoCivil estadoCivil = null;

            foreach (EstadoCivil e in estadosCiviles)
            {
                if (e.Id == id)
                {
                    estadoCivil = e;
                    break;
                }
            }

            return estadoCivil;
        }

        /// <summary>
        /// El método permite editar un registro de la entidad [EstadoCivil].
        /// Recibe como parámetro un objeto [EstadoCivil] con la información editada para actualizarse en la base de datos.
        /// Devuelve un valor booleano para notificar si el registro fue editado o no.
        /// </summary>
        public bool Editar(EstadoCivil obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.EstadosCivilesEditar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@estado_civil_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@estado_civil_id", SqlDbType.Int).Value = obj.Id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int editado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (editado > 0);
        }

        /// <summary>
        /// El método permite obtener la lista de registros de la entidad [EstadoCivil] desde la base de datos.
        /// Los campos que se devuelven son: Id, Nombre y Estado.
        /// En caso de no existir ningún registro se devuelve una lista nula o vacía.
        /// </summary>
        public List<EstadoCivil> Listar()
        {
            List<EstadoCivil> listaEstadosCiviles = new List<EstadoCivil>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.EstadosCivilesListar;

            comandoSql.Parameters.Clear();

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();

            while (reader.Read())
            {
                EstadoCivil ec = new EstadoCivil();

                ec.Id = int.Parse(reader["estado_civil_id"].ToString());
                ec.Nombre = reader["estado_civil_nombre"].ToString();
                ec.Estado = bool.Parse(reader["estado_civil_estado"].ToString());

                listaEstadosCiviles.Add(ec);
            }

            reader.Close();

            conexionSql.Close();

            this.estadosCiviles.Clear();
            this.estadosCiviles = listaEstadosCiviles;

            return listaEstadosCiviles;
        }

        public List<EstadoCivil> ListarPorEstado(bool Estado)
        {
            // Actualizar
            Listar();

            List<EstadoCivil> listEstadosCiviles = new List<EstadoCivil>();

            foreach (EstadoCivil e in estadosCiviles)
            {
                if (e.Estado == Estado)
                {
                    listEstadosCiviles.Add(e);
                }
            }

            return listEstadosCiviles;
        }
    }
}
