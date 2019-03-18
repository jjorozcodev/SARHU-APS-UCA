using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Collections.Generic;

namespace Datos
{
    public class DT_Municipios
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionDB();
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
        public List<Municipio> Listar(int id)
        {
            List<Municipio> municipios = new List<Municipio>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.MunicipiosListar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@departamento_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
      

            while (reader.Read())
            {
                Municipio m = new Municipio();
                m.Id = reader.GetInt32(0);
                m.Nombre = reader.GetString(1);
             

                municipios.Add(m);
            }
            reader.Close();

            conexionSql.Close();

            return municipios;
        }
    }
}
