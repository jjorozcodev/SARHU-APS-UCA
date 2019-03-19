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
        private SqlDataAdapter adaptadorSql = null;

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
            List<Municipio> municipios = new List<Municipio>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.AreasListar;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
            Municipio m = new Municipio();

            while (reader.Read())
            {
                m.Id = reader.GetInt32(0);
                m.Nombre = reader.GetString(1);
                m.DepartamentoId = reader.GetInt32(2);

                municipios.Add(m);
            }
            reader.Close();

            conexionSql.Close();

            return municipios;
        }
    }
}
