using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class DT_Departamentos
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionDB();
        private SqlCommand comandoSql = new SqlCommand();
        private SqlDataAdapter adaptadorSql = null;

        private static DT_Departamentos dtDepartamentos = null;

        private DT_Departamentos()
        {
            //Singleton
        }

        public static DT_Departamentos Instanciar()
        {
            if (dtDepartamentos == null)
            {
                dtDepartamentos = new DT_Departamentos();
            }
            return dtDepartamentos;
        }

        // METODOS
        public DataTable Obtener()
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.DepartamentosListar;
            adaptadorSql = new SqlDataAdapter(comandoSql);
            DataTable dt = new DataTable();
            adaptadorSql.Fill(dt);
            adaptadorSql.Dispose();
            return dt;
        }

    }
}
