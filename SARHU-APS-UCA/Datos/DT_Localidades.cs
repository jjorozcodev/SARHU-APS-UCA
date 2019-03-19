using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Collections.Generic;

namespace Datos
{
    public class DT_Localidades : I_CRUD<Localidad>
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();
        private SqlDataAdapter adaptadorSql = null;

        private static DT_Localidades dtLocalidades = null;

        private DT_Localidades()
        {
            //Singleton
        }

        public static DT_Localidades Instanciar()
        {
            if (dtLocalidades == null)
            {
                dtLocalidades = new DT_Localidades();
            }
            return dtLocalidades;
        }

        // METODOS

        /// <summary>
        /// El método permite agregar un registro de la entidad [Localidad].
        /// Recibe como parámetro un objeto [Localidad] con la información a agregar a la base de datos (ProgramaId, MunicipioId, DirectorId, Alias, Telefono y Direccion).
        /// Devuelve un valor booleano para notificar si el registro fue agregado o no.
        /// </summary>
        public bool Agregar(Localidad obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.LocalidadesAgregar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@programa_id", SqlDbType.Int).Value = obj.ProgramaId;
            comandoSql.Parameters.Add("@municipio_id", SqlDbType.Int).Value = obj.MunicipioId;
            comandoSql.Parameters.Add("@director_id", SqlDbType.Int).Value = obj.DirectorId;
            comandoSql.Parameters.Add("@localidad_alias", SqlDbType.VarChar).Value = obj.Alias; comandoSql.Parameters.Add("@localidad_telefono", SqlDbType.VarChar).Value = obj.Telefono;
            comandoSql.Parameters.Add("@localidad_direccion", SqlDbType.VarChar).Value = obj.Direccion;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int agregado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (agregado > 0);
        }

        /// <summary>
        /// El método permite borrar un registro de la entidad [Localidad].
        /// Recibe como parámetro el id [int] del registro a borrar en la base de datos.
        /// Devuelve un valor booleano para notificar si el registro fue borrado o no.
        /// </summary>
        public bool Borrar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.LocalidadesBorrar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@localidad_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int borrado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (borrado > 0);
        }

        /// <summary>
        /// El método permite consultar/buscar un registro de la entidad [Localidad].
        /// Recibe como parámetro el id [int] del registro a consultar/buscar en la base de datos.
        /// Devuelve un objeto [Localidad] nulo en caso de no encontrarse, o con la información del registro en caso que exista.
        /// </summary>
        public Localidad Consultar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.LocalidadesConsultar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@localidad_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
            Localidad localidad = new Localidad();

            while (reader.Read())
            {
                localidad.Id = reader.GetInt32(0);
                localidad.ProgramaId = reader.GetInt32(1);
                localidad.MunicipioId = reader.GetInt32(2);
                localidad.DirectorId = reader.GetInt32(3);
                localidad.Alias = reader.GetString(4);
                localidad.Telefono = reader.GetString(5);
                localidad.Direccion = reader.GetString(6);
            }
            reader.Close();

            conexionSql.Close();

            return localidad;
        }

        /// <summary>
        /// El método permite editar un registro de la entidad [Localidad].
        /// Recibe como parámetro un objeto [Localidad] con la información editada para actualizarse en la base de datos (ProgramaId, MunicipioId, DirectorId, Alias, Telefono y Direccion).
        /// Devuelve un valor booleano para notificar si el registro fue editado o no.
        /// </summary>
        public bool Editar(Localidad obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.LocalidadesEditar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@localidad_id", SqlDbType.Int).Value = obj.Id;
            comandoSql.Parameters.Add("@programa_id", SqlDbType.Int).Value = obj.ProgramaId;
            comandoSql.Parameters.Add("@municipio_id", SqlDbType.Int).Value = obj.MunicipioId;
            comandoSql.Parameters.Add("@director_id", SqlDbType.Int).Value = obj.DirectorId;
            comandoSql.Parameters.Add("@localidad_alias", SqlDbType.VarChar).Value = obj.Alias; comandoSql.Parameters.Add("@localidad_telefono", SqlDbType.VarChar).Value = obj.Telefono;
            comandoSql.Parameters.Add("@localidad_direccion", SqlDbType.VarChar).Value = obj.Direccion;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int editado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (editado > 0);
        }

        /// <summary>
        /// El método permite obtener la lista de registros de la entidad [Localidad] desde la base de datos.
        /// Los campos que se devuelven son: Id, ProgramaId, MunicipioId, DirectorId, Alias, Telefono y Direccion.
        /// En caso de no existir ningún registro se devuelve una lista nula o vacía.
        /// </summary>
        public List<Localidad> Listar()
        {
            List<Localidad> localidades = new List<Localidad>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.ProgramasListar;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
            Localidad l = new Localidad();

            while (reader.Read())
            {
                l.Id = reader.GetInt32(0);
                l.ProgramaId = reader.GetInt32(1);
                l.MunicipioId = reader.GetInt32(2);
                l.DirectorId = reader.GetInt32(3);
                l.Alias = reader.GetString(4);
                l.Telefono = reader.GetString(5);
                l.Direccion = reader.GetString(6);

                localidades.Add(l);
            }
            reader.Close();

            conexionSql.Close();

            return localidades;
        }

        /// <summary>
        /// Método aún en desarrollo...
        /// </summary>
        public DataTable ObtenerVista()
        {
            // TODO: Para mostrar en la tabla.
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.LocalidadesListar;
            adaptadorSql = new SqlDataAdapter(comandoSql);
            DataTable dt = new DataTable();
            adaptadorSql.Fill(dt);
            adaptadorSql.Dispose();
            return dt;
        }
    }
}
