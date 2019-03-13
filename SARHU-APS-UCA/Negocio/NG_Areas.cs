using Datos;
using System.Data;

namespace Negocio
{
    public class NG_Areas
    {
        //GLOBALES
        private static DT_Areas dtAreas = DT_Areas.Instanciar();

        private static NG_Areas ngAreas = null;

        private NG_Areas()
        {
            //Singleton
        }

        public static NG_Areas Instanciar()
        {
            if (ngAreas == null)
            {
                ngAreas = new NG_Areas();
            }
            return ngAreas;
        }

        public DataTable Listar()
        {
            return dtAreas.Listar();
        }
    }
}
