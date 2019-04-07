using Datos;
using Entidades;
using System.Collections.Generic;

namespace Negocio
{
    public class NG_NivelesAcademicos
    {
        //GLOBALES
        private static DT_NivelesAcademicos dtBonos = DT_NivelesAcademicos.Instanciar();

        private static NG_NivelesAcademicos ngBonos = null;

        private NG_NivelesAcademicos()
        {
            //Singleton
        }

        public static NG_NivelesAcademicos Instanciar()
        {
            if (ngBonos == null)
            {
                ngBonos = new NG_NivelesAcademicos();
            }
            return ngBonos;
        }

        public int AgregarObtenerID(NivelAcademico obj)
        {
            return dtBonos.Agregar(obj);
        }

        public bool Agregar(NivelAcademico obj)
        {
            return (dtBonos.Agregar(obj) > 0);
        }

        public bool Borrar(int id)
        {
            return dtBonos.Borrar(id);
        }

        public NivelAcademico Consultar(int id)
        {
            return dtBonos.Consultar(id);
        }

        public bool Editar(NivelAcademico obj)
        {
            return dtBonos.Editar(obj);
        }

        public List<NivelAcademico> Listar()
        {
            return dtBonos.Listar();
        }

        public List<NivelAcademico> ListarPorEstado(bool estado)
        {
            return null; //dtNivelesAcademicos.ListarPorEstado(estado);
        }
    }
}
