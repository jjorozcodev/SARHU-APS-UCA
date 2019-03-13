using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class DT_Municipios
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionDB();
        private SqlCommand comandoSql = new SqlCommand();
        private SqlDataAdapter adaptadorSql = null;

        private static DT_Municipios dtMunicipios = null;

        private DT_Municipios()
        {
            //Singleton
        }

        public static DT_Municipios Instanciar()
        {
            if (dtMunicipios == null)
            {
                dtMunicipios = new DT_Municipios();
            }
            return dtMunicipios;
        }

        // METODOS
        public DataTable Listar()
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.MunicipiosListar;
            adaptadorSql = new SqlDataAdapter(comandoSql);
            DataTable dt = new DataTable();
            adaptadorSql.Fill(dt);
            adaptadorSql.Dispose();
            return dt;
        }
    }
}
