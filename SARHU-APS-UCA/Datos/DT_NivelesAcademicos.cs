using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;
using System.Data;

namespace Datos
{
    public class DT_NivelesAcademicos : I_CRUD<NivelAcademico>
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();
        private List<NivelAcademico> nivelesAcademicos = new List<NivelAcademico>();

        private static DT_NivelesAcademicos dtNivelesAcademicos = null;

        private DT_NivelesAcademicos()
        {
            //Singleton
        }

        public static DT_NivelesAcademicos Instanciar()
        {
            if (dtNivelesAcademicos == null)
            {
                dtNivelesAcademicos = new DT_NivelesAcademicos();
            }
            return dtNivelesAcademicos;
        }

        // METODOS

        /// <summary>
        /// El método permite agregar un registro de la entidad [NivelAcademico].
        /// Recibe como parámetro un objeto [NivelAcademico] con la información a agregar a la base de datos.
        /// Devuelve un valor entero con el id generado.
        /// </summary>
        public int Agregar(NivelAcademico obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.NivelesAcademicosAgregar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@nivel_academico_nombre", SqlDbType.VarChar).Value = obj.Nombre;

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
        /// El método permite borrar un registro de la entidad [NivelAcademico].
        /// Recibe como parámetro el id [int] del registro a la base de datos.
        /// Devuelve un valor booleano para notificar si el registro fue borrado o no.
        /// </summary>
        public bool Borrar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.NivelesAcademicosBorrar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@nivel_academico_id", SqlDbType.Int).Value = id;

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
        /// El método permite consultar/buscar un registro de la entidad [NivelAcademico].
        /// Recibe como parámetro el id [int] del registro a consultar/buscar en la base de datos.
        /// Devuelve un objeto [NivelAcademico] nulo en caso de no encontrarse, o con la información del registro en caso que exista.
        /// </summary>
        public NivelAcademico Consultar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.NivelesAcademicosConsultar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@nivel_academico_id", SqlDbType.Int).Value = id;

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();

            NivelAcademico nivelAcademico = new NivelAcademico();

            while (reader.Read())
            {
                nivelAcademico.Id = id;
                nivelAcademico.Nombre = reader["nivel_academico_nombre"].ToString();
                nivelAcademico.Estado = bool.Parse(reader["nivel_academico_estado"].ToString());
            }

            reader.Close();

            conexionSql.Close();

            return nivelAcademico;
        }

        /// <summary>
        /// El método permite editar un registro de la entidad [NivelAcademico].
        /// Recibe como parámetro un objeto [NivelAcademico] con la información editada para actualizarse en la base de datos.
        /// Devuelve un valor booleano para notificar si el registro fue editado o no.
        /// </summary>
        public bool Editar(NivelAcademico obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.NivelesAcademicosEditar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@nivel_academico_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@nivel_academico_id", SqlDbType.Int).Value = obj.Id;

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
        /// El método permite obtener la lista de registros de la entidad [NivelAcademico] desde la base de datos.
        /// Los campos que se devuelven son: Id, Nombre y Estado.
        /// En caso de no existir ningún registro se devuelve una lista nula o vacía.
        /// </summary>
        public List<NivelAcademico> Listar()
        {
            List<NivelAcademico> listaNivelesAcademicos = new List<NivelAcademico>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.NivelesAcademicosListar;

            comandoSql.Parameters.Clear();

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();

            while (reader.Read())
            {
                NivelAcademico na = new NivelAcademico();

                na.Id = int.Parse(reader["nivel_academico_id"].ToString());
                na.Nombre = reader["nivel_academico_nombre"].ToString();
                na.Estado = bool.Parse(reader["nivel_academico_estado"].ToString());

                listaNivelesAcademicos.Add(na);
            }

            reader.Close();

            conexionSql.Close();

            this.nivelesAcademicos.Clear();
            this.nivelesAcademicos = listaNivelesAcademicos;

            return listaNivelesAcademicos;
        }

        public List<NivelAcademico> ListarPorEstado(bool Estado)
        {
            // Actualizar
            Listar();

            List<NivelAcademico> listNivelesAcademicos = new List<NivelAcademico>();

            foreach (NivelAcademico n in nivelesAcademicos)
            {
                if (n.Estado == Estado)
                {
                    listNivelesAcademicos.Add(n);
                }
            }

            return listNivelesAcademicos;
        }
    }
}
