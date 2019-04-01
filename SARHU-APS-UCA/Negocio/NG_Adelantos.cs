using Datos;
using Entidades;
using System.Collections.Generic;

namespace Negocio
{
    public class NG_Adelantos
    {
        //GLOBALES
        private static DT_Adelantos dtAdelantos = DT_Adelantos.Instanciar();
        
        private static NG_Adelantos ngAdelantos = null;

        private NG_Adelantos()
        {
            //Singleton
        }

        public static NG_Adelantos Instanciar()
        {
            if (ngAdelantos == null)
            {
                ngAdelantos = new NG_Adelantos();
            }
            return ngAdelantos;
        }

        public int AgregarObtenerID(Adelanto obj)
        {
            return dtAdelantos.Agregar(obj);
        }

        public bool Agregar(Adelanto obj)
        {
            return (dtAdelantos.Agregar(obj) > 0);
        }

        public bool Borrar(int id)
        {
            return dtAdelantos.Borrar(id);
        }

        public Adelanto Consultar(int id)
        {
            return dtAdelantos.Consultar(id);
        }

        public bool Editar(Adelanto obj)
        {
            return dtAdelantos.Editar(obj);
        }

        public List<Adelanto> Listar()
        {
            return dtAdelantos.Listar();
        }

        public List<Adelanto> ListarPorEstado(bool estado)
        {
            return dtAdelantos.ListarPorEstado(estado);
        }
    }
}

