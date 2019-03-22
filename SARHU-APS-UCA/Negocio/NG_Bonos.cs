using Datos;
using Entidades;
using System.Collections.Generic;

namespace Negocio
{
    public class NG_Bonos
    {
        //GLOBALES
        private static DT_Bonos dtBonos = DT_Bonos.Instanciar();

        private static NG_Bonos ngBonos = null;

        private NG_Bonos()
        {
            //Singleton
        }

        public static NG_Bonos Instanciar()
        {
            if (ngBonos == null)
            {
                ngBonos = new NG_Bonos();
            }
            return ngBonos;
        }

        public bool Agregar(Bono obj)
        {
            return dtBonos.Agregar(obj);
        }

        public bool Borrar(int id)
        {
            return dtBonos.Borrar(id);
        }

        public Bono Consultar(int id)
        {
            return dtBonos.Consultar(id);
        }

        public bool Editar(Bono obj)
        {
            return dtBonos.Editar(obj);
        }

        public List<Bono> Listar()
        {
            return dtBonos.Listar();
        }

        public List<Bono> ListarPorEstado(bool estado)
        {
            return dtBonos.ListarPorEstado(estado);
        }
    }
}
