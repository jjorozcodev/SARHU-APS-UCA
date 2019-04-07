using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class DT_EstadosCiviles : I_CRUD<EstadoCivil>
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();
        private List<EstadoCivil> estadosCiviles = new List<EstadoCivil>();

        private static DT_EstadosCiviles dtEstadosCiviles = null;

        private DT_EstadosCiviles()
        {
            //Singleton
        }

        public static DT_EstadosCiviles Instanciar()
        {
            if (dtEstadosCiviles == null)
            {
                dtEstadosCiviles = new DT_EstadosCiviles();
            }
            return dtEstadosCiviles;
        }

        // METODOS

        public int Agregar(EstadoCivil obj)
        {
            throw new System.NotImplementedException();
        }

        public bool Borrar(int id)
        {
            throw new System.NotImplementedException();
        }

        public EstadoCivil Consultar(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Editar(EstadoCivil obj)
        {
            throw new System.NotImplementedException();
        }

        public List<EstadoCivil> Listar()
        {
            throw new System.NotImplementedException();
        }
    }
}
