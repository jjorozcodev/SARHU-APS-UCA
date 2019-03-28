using Datos;
using Entidades;
using System.Collections.Generic;

namespace Negocio
{
    public class NG_Variables
    {
        //GLOBALES
        private static DT_Variables dtVariables = DT_Variables.Instanciar();

        private static NG_Variables ngVariables = null;

        private NG_Variables()
        {
            //Singleton
        }

        public static NG_Variables Instanciar()
        {
            if (ngVariables == null)
            {
                ngVariables = new NG_Variables();
            }
            return ngVariables;
        }

        public Variable Consultar(int id)
        {
            return dtVariables.Consultar(id);
        }

        public bool Editar(Variable obj)
        {
            return dtVariables.Editar(obj);
        }

        public List<Variable> Listar()
        {
            return dtVariables.Listar();
        }
    }
}
