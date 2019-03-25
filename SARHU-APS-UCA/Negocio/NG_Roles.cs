using Datos;
using Entidades;
using System.Collections.Generic;

namespace Negocio
{
    public class NG_Roles
    {
        //GLOBALES
        private static DT_Roles dtRoles = DT_Roles.Instanciar();

        private static NG_Roles ngRoles = null;

        private NG_Roles()
        {
            //Singleton
        }

        public static NG_Roles Instanciar()
        {
            if (ngRoles == null)
            {
                ngRoles = new NG_Roles();
            }
            return ngRoles;
        }

        public int AgregarObtenerID(Rol obj)
        {
            return dtRoles.Agregar(obj);
        }

        public bool Agregar(Rol obj)
        {
            return (dtRoles.Agregar(obj) > 0);
        }

        public bool Borrar(int id)
        {
            return dtRoles.Borrar(id);
        }

        public Rol Consultar(int id)
        {
            return dtRoles.Consultar(id);
        }

        public bool Editar(Rol obj)
        {
            return dtRoles.Editar(obj);
        }

        public List<Rol> Listar()
        {
            return dtRoles.Listar();
        }

        public List<Rol> ListarPorEstado(bool estado)
        {
            return dtRoles.ListarPorEstado(estado);
        }
    }
}
