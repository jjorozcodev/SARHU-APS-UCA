using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Collections.Generic;
using System;

namespace Datos
{
    public class DT_Variables
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();

        private static DT_Variables dtVariables = null;

        private DT_Variables()
        {
            // Singleton
        }

        public static DT_Variables Instanciar()
        {
            if (dtVariables == null)
            {
                dtVariables = new DT_Variables();
            }

            return dtVariables;
        }


        // Métodos

        /// <summary>
        /// El método permite consultar/buscar un registro de la entidad [Variable].
        /// Recibe como parámetro el id [int] del registro a consultar/buscar en la base de datos.
        /// Devuelve un objeto [Variable] nulo en caso de no encontrarse, o con la información del registro en caso que exista.
        /// </summary>
        public Variable Consultar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.VariablesConsultar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@variable_id", SqlDbType.Int).Value = id;

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }
            
            SqlDataReader reader = comandoSql.ExecuteReader();

            Variable var = new Variable();

            while (reader.Read())
            {
                DateTime ua;

                var.Id = id;
                var.Nombre = reader["variable_nombre"].ToString();
                var.Valor = decimal.Parse(reader["variable_valor"].ToString());
                DateTime.TryParse(reader["variable_ultima_actualizacion"].ToString(), out ua);
                var.UltimaActualizacion = ua;
            }

            reader.Close();

            conexionSql.Close();

            return var;
        }

        /// <summary>
        /// El método permite editar un registro de la entidad [Variable].
        /// Recibe como parámetro un objeto [Variable] con la información editada para actualizarse en la base de datos (Nombre y Valor).
        /// Devuelve un valor booleano para notificar si el registro fue editado o no.
        /// </summary>
        public bool Editar(Variable obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.VariablesEditar;

            comandoSql.Parameters.Clear();

            comandoSql.Parameters.Add("@variable_id", SqlDbType.Int).Value = obj.Id;
            comandoSql.Parameters.Add("@variable_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@variable_valor", SqlDbType.Decimal).Value = obj.Valor;
            comandoSql.Parameters.Add("@variable_ultima_actualizacion", SqlDbType.DateTime).Value = obj.UltimaActualizacion;

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }

            int editado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (editado > 0);
        }

        /// <summary>
        /// El método permite obtener la lista de registros de la entidad [Variable] desde la base de datos.
        /// Los campos que se devuelven son: Id, Nombre, Valor y Última Actualización.
        /// En caso de no existir ningún registro se devuelve una lista nula o vacía.
        /// </summary>
        public List<Variable> Listar()
        {
            List<Variable> listaVariables = new List<Variable>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.VariablesListar;

            comandoSql.Parameters.Clear();

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();

            while (reader.Read())
            {
                Variable v = new Variable();

                DateTime ua;

                v.Id = int.Parse(reader["variable_id"].ToString());
                v.Nombre = reader["variable_nombre"].ToString();
                v.Valor = decimal.Parse(reader["variable_valor"].ToString());
                DateTime.TryParse(reader["variable_ultima_actualizacion"].ToString(), out ua);
                v.UltimaActualizacion = ua;

                listaVariables.Add(v);
            }

            reader.Close();

            conexionSql.Close();

            return listaVariables;
        }
    }
}