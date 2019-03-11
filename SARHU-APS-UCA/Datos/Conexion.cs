using System.Data.SqlClient;

namespace Datos
{
    public class Conexion
    {
        #region "Patrón Singleton"
        private static Conexion conexion = null;
        private string connectionString = "Data Source=165.98.12.158;Initial Catalog=SARHU_BD; MultipleActiveResultSets=True ;Max Pool Size = 50; Min Pool Size = 1; Pooling = True;User ID = aps; Password = $qlS3rv3rAPS*;";
        private Conexion()
        {

        }

        public static Conexion Instanciar()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
            return conexion;
        }
        #endregion

        //Método que devuelve una conexión SQL a la Base de Datos
        public SqlConnection ConexionDB()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = connectionString;
            return conexion;
        }
    }
}
