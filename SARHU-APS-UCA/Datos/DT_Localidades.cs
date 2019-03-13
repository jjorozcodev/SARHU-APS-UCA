using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class DT_Localidades : I_CRUD<Localidad>
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionDB();
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

        public bool Agregar(Localidad obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.LocalidadesAgregar;

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

        public bool Borrar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.LocalidadesBorrar;

            comandoSql.Parameters.Add("@localidad_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int borrado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (borrado > 0);
        }

        public Localidad Consultar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.LocalidadesConsultar;

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

        public bool Editar(Localidad obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.LocalidadesEditar;

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

        public DataTable Listar()
        {
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
