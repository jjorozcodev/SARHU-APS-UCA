using Datos;
using Entidades;
using System.Collections.Generic;

namespace Negocio
{
    public class NG_Usuarios
    {
        //GLOBALES
        private static DT_Usuarios dtUsuarios = DT_Usuarios.Instanciar();

        private static NG_Usuarios ngUsuarios = null;

        private NG_Usuarios()
        {
            //Singleton
        }

        public static NG_Usuarios Instanciar()
        {
            if (ngUsuarios == null)
            {
                ngUsuarios = new NG_Usuarios();
            }
            return ngUsuarios;
        }

        public int AgregarObtenerID(Usuario obj)
        {
            return dtUsuarios.Agregar(obj);
        }

        public bool Agregar(Usuario obj)
        {
            return (dtUsuarios.Agregar(obj) > 0);
        }

        public bool Borrar(int id)
        {
            return dtUsuarios.Borrar(id);
        }

        public Usuario Consultar(int id)
        {
            return dtUsuarios.Consultar(id);
        }

        public bool Editar(Usuario obj)
        {
            return dtUsuarios.Editar(obj);
        }

        public List<Usuario> Listar()
        {
            return dtUsuarios.Listar();
        }

        public List<Usuario> ListarPorEstado(bool estado)
        {
            return dtUsuarios.ListarPorEstado(estado);
        }
    }
}

