using Datos;
using Entidades;
using System.Collections.Generic;

namespace Negocio
{
    public class NG_EstadosCiviles
    {
        //GLOBALES
        private static DT_EstadosCiviles dtEstadosCiviles = DT_EstadosCiviles.Instanciar();

        private static NG_EstadosCiviles ngEstadosCiviles = null;

        private NG_EstadosCiviles()
        {
            //Singleton
        }

        public static NG_EstadosCiviles Instanciar()
        {
            if (ngEstadosCiviles == null)
            {
                ngEstadosCiviles = new NG_EstadosCiviles();
            }
            return ngEstadosCiviles;
        }

        public int AgregarObtenerID(EstadoCivil obj)
        {
            return dtEstadosCiviles.Agregar(obj);
        }

        public bool Agregar(EstadoCivil obj)
        {
            return (dtEstadosCiviles.Agregar(obj) > 0);
        }

        public bool Borrar(int id)
        {
            return dtEstadosCiviles.Borrar(id);
        }

        public EstadoCivil Consultar(int id)
        {
            return dtEstadosCiviles.Consultar(id);
        }

        public bool Editar(EstadoCivil obj)
        {
            return dtEstadosCiviles.Editar(obj);
        }

        public List<EstadoCivil> Listar()
        {
            return dtEstadosCiviles.Listar();
        }

        public List<EstadoCivil> ListarPorEstado(bool estado)
        {
            return null; //dtEstadosCiviles.ListarPorEstado(estado);
        }
    }
}