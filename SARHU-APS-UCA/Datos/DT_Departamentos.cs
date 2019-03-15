using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Collections.Generic;

namespace Datos
{
    public class DT_Departamentos
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionDB();
        private SqlCommand comandoSql = new SqlCommand();
        private SqlDataAdapter adaptadorSql = null;

        private static DT_Departamentos dtDepartamentos = null;

        private DT_Departamentos()
        {
            //Singleton
        }

        public static DT_Departamentos Instanciar()
        {
            if (dtDepartamentos == null)
            {
                dtDepartamentos = new DT_Departamentos();
            }
            return dtDepartamentos;
        }

        // METODOS

        /// <summary>
        /// El método permite obtener la lista de registros de la entidad [Departamento] desde la base de datos.
        /// Los campos que se devuelven son: Id y Nombre.
        /// En caso de no existir ningún registro se devuelve una lista nula o vacía.
        /// </summary>
        public List<Departamento> Listar()
        {
            List<Departamento> departamentos = new List<Departamento>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.AreasListar;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
            Departamento d = new Departamento();

            while (reader.Read())
            {
                d.Id = reader.GetInt32(0);
                d.Nombre = reader.GetString(1);

                departamentos.Add(d);
            }
            reader.Close();

            conexionSql.Close();

            return departamentos;
        }

    }
}
