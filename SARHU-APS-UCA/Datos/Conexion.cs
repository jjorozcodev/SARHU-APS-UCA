using System.Data.SqlClient;

namespace Datos
{
    public class Conexion
    {
        private static Conexion conexion = null;
        private readonly string ConnectionString = "Data Source = 165.98.12.158; Initial Catalog = SARHU; MultipleActiveResultSets=True; Max Pool Size = 50; Min Pool Size = 1; Pooling = True;User ID = aps; Password = $qlS3rv3rAPS*;";

        private Conexion()
        {
            // Implementación de Singleton
        }

        public static Conexion Instanciar()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
            return conexion;
        }

        //Método que devuelve una conexión SQL a la Base de Datos
        public SqlConnection ConexionDB()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConnectionString;
            return conexion;
        }
    }
}