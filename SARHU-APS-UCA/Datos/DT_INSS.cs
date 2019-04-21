using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DT_INSS
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();

        private static DT_INSS dtInss = null;

        private DT_INSS()
        {
            // Singleton
        }

        public static DT_INSS Instanciar()
        {
            if (dtInss == null)
            {
                dtInss = new DT_INSS();
            }

            return dtInss;
        }


        // Métodos

        /// <summary>
        /// El método permite consultar/buscar un registro de la entidad [INSS].
        /// Recibe como parámetro el id [int] del registro a consultar/buscar en la base de datos.
        /// Devuelve un objeto [INSS] nulo en caso de no encontrarse, o con la información del registro en caso que exista.
        /// </summary>
        public INSS Consultar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.INSSConsultar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@inss_id", SqlDbType.Int).Value = id;

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();

            INSS inss = new INSS();

            while (reader.Read())
            {
                DateTime ff;

                inss.Id = id;
                inss.Porcentaje = decimal.Parse(reader["inss_porcentaje"].ToString());
                inss.Patronal = bool.Parse(reader["inss_patronal"].ToString());
                DateTime.TryParse(reader["inss_ultima_actualizacion"].ToString(), out ff);
                inss.UltimaActualizacion = ff;
            }

            reader.Close();

            conexionSql.Close();
            
            return inss;
        }

        /// <summary>
        /// El método permite editar un registro de la entidad [INSS].
        /// Recibe como parámetro un objeto [INSS] con la información editada para actualizarse en la base de datos (Porcentaje y Última Actualización).
        /// Devuelve un valor booleano para notificar si el registro fue editado o no.
        /// </summary>
        public bool Editar(INSS obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.INSSEditar;

            comandoSql.Parameters.Clear();

            comandoSql.Parameters.Add("@inss_id", SqlDbType.Int).Value = obj.Id;
            comandoSql.Parameters.Add("@inss_porcentaje", SqlDbType.Decimal).Value = obj.Porcentaje;
            comandoSql.Parameters.Add("@ultima_actualizacion", SqlDbType.DateTime).Value = obj.UltimaActualizacion;

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
        /// El método permite obtener la lista de registros de la entidad [INSS] desde la base de datos.
        /// Los campos que se devuelven son: Id, Porcentaje, Patronal y Última Actualización.
        /// En caso de no existir ningún registro se devuelve una lista nula o vacía.
        /// </summary>
        public List<INSS> Listar()
        {
            List<INSS> listaINSS = new List<INSS>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.INSSListar;

            comandoSql.Parameters.Clear();

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();

            while (reader.Read())
            {
                INSS i = new INSS();

                DateTime ff;

                i.Id = int.Parse(reader["inss_id"].ToString());
                i.Porcentaje = decimal.Parse(reader["inss_porcentaje"].ToString());
                i.Patronal = bool.Parse(reader["inss_patronal"].ToString());
                DateTime.TryParse(reader["inss_ultima_actualizacion"].ToString(), out ff);
                i.UltimaActualizacion = ff;

                listaINSS.Add(i);
            }

            reader.Close();

            conexionSql.Close();
            
            return listaINSS;
        }
    }
}
