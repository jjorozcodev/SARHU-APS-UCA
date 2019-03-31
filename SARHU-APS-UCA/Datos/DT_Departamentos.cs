using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Collections.Generic;

namespace Datos
{
    public class DT_Departamentos
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();
        private List<Departamento> departamentos = null;

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
            if (this.departamentos != null)
            {
                return this.departamentos;
            }

            List<Departamento> departamentos = new List<Departamento>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.DepartamentosListar;

            comandoSql.Parameters.Clear();

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
         

            while (reader.Read())
            {
                Departamento d = new Departamento();

                d.Id = int.Parse(reader["departamento_id"].ToString());
                d.Nombre = reader["departamento_nombre"].ToString();

                departamentos.Add(d);
            }

            reader.Close();

            conexionSql.Close();

            this.departamentos = departamentos;

            return departamentos;
        }

        public Departamento Consultar(int id)
        {
            Listar();

            Departamento departamento = null;
           
            foreach (Departamento d in this.departamentos)
            {
                if (d.Id == id)
                {
                    departamento = d;
                    break;
                }
            }

            return departamento;
        }

    }
}
