using Datos;
using Entidades;
using System.Collections.Generic;

namespace Negocio
{
    public class NG_Localidades
    {
        //GLOBALES
        private static DT_Localidades dtLocalidades = DT_Localidades.Instanciar();

        private static NG_Localidades ngLocalidades = null;

        private NG_Localidades()
        {
            //Singleton
        }

        public static NG_Localidades Instanciar()
        {
            if (ngLocalidades == null)
            {
                ngLocalidades = new NG_Localidades();
            }
            return ngLocalidades;
        }

        public bool Agregar(Localidad obj)
        {
            return dtLocalidades.Agregar(obj) > 0;
        }

        public bool Borrar(int id)
        {
            return dtLocalidades.Borrar(id);
        }

        public Localidad Consultar(int id)
        {
            return dtLocalidades.Consultar(id);
        }

        public bool Editar(Localidad obj)
        {
            return dtLocalidades.Editar(obj);
        }

        public List<Localidad> Listar()
        {
            return dtLocalidades.Listar();
        }
    }
}
