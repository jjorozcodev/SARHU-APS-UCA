using Datos;
using Entidades;
using System.Collections.Generic;

namespace Negocio
{
    public class NG_Funciones
    {
        //GLOBALES
        private static DT_Funciones dtFunciones = DT_Funciones.Instanciar();

        private static NG_Funciones ngFunciones = null;

        private NG_Funciones()
        {
            //Singleton
        }

        public static NG_Funciones Instanciar()
        {
            if (ngFunciones == null)
            {
                ngFunciones = new NG_Funciones();
            }
            return ngFunciones;
        }

        public bool Agregar(Funcion obj)
        {
            return dtFunciones.Agregar(obj) > 0;
        }

        public bool Borrar(int id)
        {
            return dtFunciones.Borrar(id);
        }

        public Funcion Consultar(int id)
        {
            return dtFunciones.Consultar(id);
        }

        public bool Editar(Funcion obj)
        {
            return dtFunciones.Editar(obj);
        }

        public List<Funcion> Listar()
        {
            return dtFunciones.Listar();
        }

        public List<Funcion> ListarPorEstado(bool estado)
        {
            return dtFunciones.ListarPorEstado(estado);
        }
    }
}
