using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Web;

namespace Datos
{
    public class Conexion
    {
        private static Conexion Con = null;
        private readonly string CadenaConexion = ObtenerCadena();
        private static readonly int CantParametrosConfig = 4;

        private Conexion()
        {
            // Implementación de Singleton
        }

        public static Conexion Instanciar()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }

        private static string ObtenerCadena()
        {
            string[] configs = CargarConfiguraciones();
            string conconfig = string.Format("Data Source={0};Initial Catalog={1};MultipleActiveResultSets=True;Max Pool Size=50;Min Pool Size=1;Pooling=True;User ID={2};Password={3};", configs[0], configs[1], configs[2], configs[3]);
            System.Diagnostics.Debug.WriteLine(conconfig);
            return conconfig;
        }

        private static string[] CargarConfiguraciones()
        {
            StreamReader sr = null;

            if (HttpContext.Current != null)
            {
                sr = new StreamReader(HttpContext.Current.Server.MapPath("~/ConfiguracionBD.sarhu"));
            }
            else
                sr = new StreamReader("ConfiguracionBD.sarhu");

            string[] configs = new string[CantParametrosConfig];
            
            for(int i=0; i<CantParametrosConfig; i++)
            {
                string linea = sr.ReadLine();
                configs[i] = linea.Substring(linea.IndexOf("=") + 1);
            }

            return configs;
        }

        //Método que devuelve una conexión SQL a la Base de Datos
        public SqlConnection ConexionBD()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = CadenaConexion;
            return conexion;
        }
    }
}