using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class DT_Bonos : I_CRUD<Bono>
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionDB();
        private SqlCommand comandoSql = new SqlCommand();
        private SqlDataAdapter adaptadorSql = null;

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

        public bool Agregar(Bono obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.BonosAgregar;

            comandoSql.Parameters.Add("@bono_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@bono_descripcion", SqlDbType.VarChar).Value = obj.Descripcion;

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
            comandoSql.CommandText = Procedimientos.BonosBorrar;

            comandoSql.Parameters.Add("@bono_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int borrado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (borrado > 0);
        }

        public Bono Consultar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.BonosConsultar;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
            Bono bono = new Bono();

            while (reader.Read())
            {
                bono.Id = reader.GetInt32(0);
                bono.Nombre = reader.GetString(1);
                bono.Descripcion = reader.GetString(2);
                bono.Monto = reader.GetDecimal(3);
            }
            reader.Close();

            conexionSql.Close();

            return bono;
        }

        public bool Editar(Bono obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.BonosEditar;

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

        public DataTable Listar()
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.BonosListar;
            adaptadorSql = new SqlDataAdapter(comandoSql);
            DataTable dt = new DataTable();
            adaptadorSql.Fill(dt);
            adaptadorSql.Dispose();
            return dt;
        }
    }
}
