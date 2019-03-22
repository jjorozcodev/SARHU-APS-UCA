using Datos;
using Entidades;
using System.Collections.Generic;


namespace Negocio
{
    public class NG_Roles
    {

        //GLOBALES
        private static DT_Roles dtroles = DT_Roles.Instanciar();

        private static NG_Roles ngroles = null;

        private NG_Roles()
        {
            //Singleton
        }

        public static NG_Roles Instanciar()
        {
            if (ngroles == null)
            {
                ngroles = new NG_Roles();
            }
            return ngroles;
        }

        public bool Agregar(Rol obj)
        {
            return dtroles.Agregar(obj);
        }

        public bool Borrar(int id)
        {
            return dtroles.Borrar(id);
        }

        public Rol Consultar(int id)
        {
            return dtroles.Consultar(id);
        }

        public bool Editar(Rol obj)
        {
            return dtroles.Editar(obj);
        }

        public List<Rol> Listar()
        {
            return dtroles.Listar();
        }

        public List<Rol> ListarPorEstado(bool estado)
        {
            return dtroles.ListarPorEstado(estado);
        }









    }
}
