using Datos;
using Entidades;

namespace Negocio
{
    public class NG_Organizacion
    {
        // GLOBALES
        private static DT_Organizacion dtOrganizacion = DT_Organizacion.Instanciar();

        private static NG_Organizacion ngOrganizacion = null;

        private NG_Organizacion()
        {
            //Singleton
        }

        public static NG_Organizacion Instanciar()
        {
            if (ngOrganizacion == null)
            {
                ngOrganizacion = new NG_Organizacion();
            }
            return ngOrganizacion;
        }

        // METODOS

        public Organizacion Obtener()
        {
            return dtOrganizacion.Obtener();
        }

        public bool Editar(Organizacion obj)
        {
            return dtOrganizacion.Editar(obj);
        }
    }
}
