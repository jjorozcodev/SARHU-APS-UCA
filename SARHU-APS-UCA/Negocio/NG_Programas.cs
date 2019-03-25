using Datos;
using Entidades;
using System.Collections.Generic;

namespace Negocio
{
    public class NG_Programas
    {
        //GLOBALES
        private static DT_Programas dtProgramas = DT_Programas.Instanciar();

        private static NG_Programas ngProgramas = null;

        private NG_Programas()
        {
            //Singleton
        }
        
        public static NG_Programas Instanciar()
        {
            if (ngProgramas == null)
            {
                ngProgramas = new NG_Programas();
            }
            return ngProgramas;
        }

        public int AgregarObtenerID(Programa obj)
        {
            return dtProgramas.Agregar(obj);
        }

        public bool Agregar(Programa obj)
        {
            return (dtProgramas.Agregar(obj) > 0);
        }

        public bool Borrar(int id)
        {
            return dtProgramas.Borrar(id);
        }

        public Programa Consultar(int id)
        {
            return dtProgramas.Consultar(id);
        }

        public bool Editar(Programa obj)
        {
            return dtProgramas.Editar(obj);
        }

        public List<Programa> Listar()
        {
            return dtProgramas.Listar();
        }

        public List<Programa> ListarPorEstado(bool estado)
        {
            return dtProgramas.ListarPorEstado(estado);
        }

        public int CantidadProgramasActivos()
        {
            List<Programa> prgms = this.ListarPorEstado(true);
            int cantidadProgActivos = prgms.Count;
            return cantidadProgActivos;
        }
    }
}
