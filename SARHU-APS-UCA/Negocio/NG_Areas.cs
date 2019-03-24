using Datos;
using Entidades;
using System.Collections.Generic;

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

        public int AgregarObtenerID(Area obj)
        {
            return dtAreas.Agregar(obj);
        }

        public bool Agregar(Area obj)
        {
            return (dtAreas.Agregar(obj) > 0);
        }

        public bool Borrar(int id)
        {
            return dtAreas.Borrar(id);
        }

        public Area Consultar(int id)
        {
            return dtAreas.Consultar(id);
        }

        public bool Editar(Area obj)
        {
            return dtAreas.Editar(obj);
        }

        public List<Area> Listar()
        {
            return dtAreas.Listar();
        }

        public List<Area> ListarPorEstado(bool estado)
        {
            return dtAreas.ListarPorEstado(estado);
        }
    }
}
