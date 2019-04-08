using Datos;
using Entidades;
using System.Collections.Generic;

namespace Negocio
{
    public class NG_NivelesAcademicos
    {
        //GLOBALES
        private static DT_NivelesAcademicos dtNivelesAcademicos = DT_NivelesAcademicos.Instanciar();

        private static NG_NivelesAcademicos ngNivelesAcademicos = null;

        private NG_NivelesAcademicos()
        {
            //Singleton
        }

        public static NG_NivelesAcademicos Instanciar()
        {
            if (ngNivelesAcademicos == null)
            {
                ngNivelesAcademicos = new NG_NivelesAcademicos();
            }
            return ngNivelesAcademicos;
        }

        public int AgregarObtenerID(NivelAcademico obj)
        {
            return dtNivelesAcademicos.Agregar(obj);
        }

        public bool Agregar(NivelAcademico obj)
        {
            return (dtNivelesAcademicos.Agregar(obj) > 0);
        }

        public bool Borrar(int id)
        {
            return dtNivelesAcademicos.Borrar(id);
        }

        public NivelAcademico Consultar(int id)
        {
            return dtNivelesAcademicos.Consultar(id);
        }

        public bool Editar(NivelAcademico obj)
        {
            return dtNivelesAcademicos.Editar(obj);
        }

        public List<NivelAcademico> Listar()
        {
            return dtNivelesAcademicos.Listar();
        }

        public List<NivelAcademico> ListarPorEstado(bool estado)
        {
            return dtNivelesAcademicos.ListarPorEstado(estado);
        }
    }
}
