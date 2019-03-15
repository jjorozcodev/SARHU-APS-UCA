using Datos;
using Entidades;
using System.Collections.Generic;

namespace Negocio
{
    public class NG_Departamentos
    {
        private DT_Departamentos dtDepartamentos = DT_Departamentos.Instanciar();

        private static NG_Departamentos ngDepartamentos = null;

        private NG_Departamentos()
        {
            // Singleton
        }
        
        public static NG_Departamentos Instanciar()
        {
            if (ngDepartamentos == null)
            {
                ngDepartamentos = new NG_Departamentos();
            }
            return ngDepartamentos;
        }

        public List<Departamento> Listar()
        {
            return dtDepartamentos.Listar();
        }
    }
}
