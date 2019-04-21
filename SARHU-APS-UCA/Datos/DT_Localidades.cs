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
        private List<Localidad> localidades = new List<Localidad>();

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
        /// Devuelve un valor entero con el id generado.
        /// </summary>
        public int Agregar(Localidad obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.LocalidadesAgregar;
            
            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@programa_id", SqlDbType.Int).Value = obj.ProgramaId;
            comandoSql.Parameters.Add("@municipio_id", SqlDbType.Int).Value = obj.MunicipioId;
            comandoSql.Parameters.Add("@director_id", SqlDbType.Int).Value = obj.DirectorId;
            comandoSql.Parameters.Add("@localidad_alias", SqlDbType.VarChar).Value = obj.Alias;
            comandoSql.Parameters.Add("@localidad_telefono", SqlDbType.VarChar).Value = obj.Telefono;
            comandoSql.Parameters.Add("@localidad_direccion", SqlDbType.VarChar).Value = obj.Direccion;

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

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
            
            Localidad localidad = new Localidad();

            while (reader.Read())
            {
                localidad.Id = id;
                localidad.ProgramaId = int.Parse(reader["programa_id"].ToString());
                localidad.DirectorId = int.Parse(reader["director_id"].ToString());
                localidad.MunicipioId = int.Parse(reader["municipio_id"].ToString());
                localidad.Alias = reader["localidad_alias"].ToString();
                localidad.Telefono = reader["localidad_telefono"].ToString();
                localidad.Direccion = reader["localidad_direccion"].ToString();
                localidad.Estado = bool.Parse(reader["localidad_estado"].ToString());
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
            comandoSql.Parameters.Add("@programa_id", SqlDbType.Int).Value = obj.ProgramaId;
            comandoSql.Parameters.Add("@municipio_id", SqlDbType.Int).Value = obj.MunicipioId;           
            comandoSql.Parameters.Add("@director_id", SqlDbType.Int).Value = obj.DirectorId;
            comandoSql.Parameters.Add("@localidad_alias", SqlDbType.VarChar).Value = obj.Alias;
            comandoSql.Parameters.Add("@localidad_telefono", SqlDbType.VarChar).Value = obj.Telefono;
            comandoSql.Parameters.Add("@localidad_direccion", SqlDbType.VarChar).Value = obj.Direccion;
            comandoSql.Parameters.Add("@localidad_id", SqlDbType.VarChar).Value = obj.Id;

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
        /// El método permite obtener la lista de registros de la entidad [Localidad] desde la base de datos.
        /// Los campos que se devuelven son: Id, ProgramaId, MunicipioId, DirectorId, Alias, Telefono y Direccion.
        /// En caso de no existir ningún registro se devuelve una lista nula o vacía.
        /// </summary>
        public List<Localidad> Listar()
        {
            List<Localidad> listaLocalidades = new List<Localidad>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.LocalidadesListar;

            comandoSql.Parameters.Clear();

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
            
            while (reader.Read())
            {
                Localidad l = new Localidad();

                l.Id = int.Parse(reader["localidad_id"].ToString());
                l.ProgramaId = int.Parse(reader["programa_id"].ToString());
                l.DirectorId = int.Parse(reader["director_id"].ToString());
                l.MunicipioId = int.Parse(reader["municipio_id"].ToString());
                l.Alias = reader["localidad_alias"].ToString();
                l.Telefono = reader["localidad_telefono"].ToString();
                l.Direccion = reader["localidad_direccion"].ToString();
                l.Estado = bool.Parse(reader["localidad_estado"].ToString());

                listaLocalidades.Add(l);
            }

            reader.Close();

            conexionSql.Close();

            this.localidades.Clear();
            this.localidades = listaLocalidades;

            return listaLocalidades;
        }

        public List<Localidad> ListarPorEstado(bool Estado)
        {
            // Actualizar
            Listar();

            List<Localidad> listLocalidades = new List<Localidad>();

            foreach (Localidad l in localidades)
            {
                if (l.Estado == Estado)
                {
                    listLocalidades.Add(l);
                }
            }

            return listLocalidades;
        }
    }
}
