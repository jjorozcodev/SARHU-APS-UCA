using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class DT_NivelesAcademicos : I_CRUD<NivelAcademico>
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();
        private List<NivelAcademico> nivelesAcademicos = new List<NivelAcademico>();

        private static DT_NivelesAcademicos dtNivelesAcademicos = null;

        private DT_NivelesAcademicos()
        {
            //Singleton
        }

        public static DT_NivelesAcademicos Instanciar()
        {
            if (dtNivelesAcademicos == null)
            {
                dtNivelesAcademicos = new DT_NivelesAcademicos();
            }
            return dtNivelesAcademicos;
        }

        // METODOS

        public int Agregar(NivelAcademico obj)
        {
            throw new System.NotImplementedException();
        }

        public bool Borrar(int id)
        {
            throw new System.NotImplementedException();
        }

        public NivelAcademico Consultar(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Editar(NivelAcademico obj)
        {
            throw new System.NotImplementedException();
        }

        public List<NivelAcademico> Listar()
        {
            throw new System.NotImplementedException();
        }
    }
}
