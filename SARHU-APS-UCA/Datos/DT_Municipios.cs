using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Collections.Generic;

namespace Datos
{
    public class DT_Municipios
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();
        private List<Municipio> municipios = new List<Municipio>();

        private static DT_Municipios dtMunicipios = null;

        private DT_Municipios()
        {
            //Singleton
        }

        public static DT_Municipios Instanciar()
        {
            if (dtMunicipios == null)
            {
                dtMunicipios = new DT_Municipios();
            }
            return dtMunicipios;
        }

        // METODOS
        /// <summary>
        /// El método permite obtener la lista de registros de la entidad [Municipio] desde la base de datos.
        /// Los campos que se devuelven son: Id, Nombre y DepartamentoId.
        /// En caso de no existir ningún registro se devuelve una lista nula o vacía.
        /// </summary>
        public List<Municipio> Listar()
        {
            if(this.municipios != null)
            {
                return this.municipios;
            }

            List<Municipio> listaMunicipios = new List<Municipio>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.MunicipiosListar;

            comandoSql.Parameters.Clear();

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
      
            while (reader.Read())
            {
               Municipio m = new Municipio();

                m.Id = int.Parse(reader["municipio_id"].ToString());
                m.Nombre = reader["municipio_nombre"].ToString();
                m.DepartamentoId = int.Parse(reader["departamento_id"].ToString());

                listaMunicipios.Add(m);
            }

            reader.Close();

            conexionSql.Close();

            this.municipios.Clear();
            this.municipios = listaMunicipios;

            return listaMunicipios;
        }

        public Municipio Consultar(int id)
        {
            Municipio municipio = null;

            foreach (Municipio m in this.municipios)
            {
                if (m.Id == id)
                {
                    municipio = m;
                    break;
                }
            }

            return municipio;
        }

        public List<Municipio> ObtenerMunicipios(int DepartamentoId)
        {
            List<Municipio> municipiosDepartamento = new List<Municipio>();

            foreach(Municipio m in this.municipios)
            {
                if(m.Id == DepartamentoId)
                {
                    municipiosDepartamento.Add(m);
                }
            }

            return municipiosDepartamento;
        }
    }
}
