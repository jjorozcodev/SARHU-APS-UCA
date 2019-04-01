using Datos;
using Entidades;
using System.Collections.Generic;

namespace Negocio
{
    public class NG_Adendums
    {
        //GLOBALES
        private static DT_Adendums dtAdendums = DT_Adendums.Instanciar();

        private static NG_Adendums ngAdendums = null;

        private NG_Adendums()
        {
            //Singleton
        }

        public static NG_Adendums Instanciar()
        {
            if (ngAdendums == null)
            {
                ngAdendums = new NG_Adendums();
            }
            return ngAdendums;
        }

        public int AgregarObtenerID(Adendum obj)
        {
            return dtAdendums.Agregar(obj);
        }

        public bool Agregar(Adendum obj)
        {
            return (dtAdendums.Agregar(obj) > 0);
        }

        public bool Borrar(int id)
        {
            return dtAdendums.Borrar(id);
        }

        public Adendum Consultar(int id)
        {
            return dtAdendums.Consultar(id);
        }

        public bool Editar(Adendum obj)
        {
            return dtAdendums.Editar(obj);
        }

        public List<Adendum> Listar()
        {
            return dtAdendums.Listar();
        }

        public List<Adendum> ListarPorEstado(bool estado)
        {
            return dtAdendums.ListarPorEstado(estado);
        }
    }
}

