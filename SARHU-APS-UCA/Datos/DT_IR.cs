using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace Datos
{
    public class DT_IR
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();

        private static DT_IR dtIR = null;

        private DT_IR()
        {
            // Singleton
        }

        public static DT_IR Instanciar()
        {
            if (dtIR == null)
            {
                dtIR = new DT_IR();
            }

            return dtIR;
        }


        // Métodos

        /// <summary>
        /// El método permite consultar/buscar un registro de la entidad [IR].
        /// Recibe como parámetro el id [int] del registro a consultar/buscar en la base de datos.
        /// Devuelve un objeto [IR] nulo en caso de no encontrarse, o con la información del registro en caso que exista.
        /// </summary>
        public IR Consultar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.IRConsultar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@ir_id", SqlDbType.Int).Value = id;

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();

            IR ir = new IR();

            while (reader.Read())
            {
                DateTime ua;

                ir.Id = id;
                ir.Desde = decimal.Parse(reader["ir_desde"].ToString());
                ir.Hasta = decimal.Parse(reader["ir_hasta"].ToString());
                ir.Base = decimal.Parse(reader["ir_base"].ToString());
                ir.Exceso = decimal.Parse(reader["ir_exceso"].ToString());
                ir.PorcentajeAplicable = decimal.Parse(reader["ir_porcentaje_aplicable"].ToString());
                DateTime.TryParse(reader["ir_ultima_actualizacion"].ToString(), out ua);
                ir.UltimaActualizacion = ua;
            }

            reader.Close();

            conexionSql.Close();

            return ir;
        }

        /// <summary>
        /// El método permite editar un registro de la entidad [IR].
        /// Recibe como parámetro un objeto [IR] con la información editada para actualizarse en la base de datos (Desde, Hasta, Base, Exceso, Porcentaje Aplicable y Última Actualización).
        /// Devuelve un valor booleano para notificar si el registro fue editado o no.
        /// </summary>
        public bool Editar(IR obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.IREditar;

            comandoSql.Parameters.Clear();

            comandoSql.Parameters.Add("@ir_id", SqlDbType.Int).Value = obj.Id;
            comandoSql.Parameters.Add("@ir_desde", SqlDbType.Decimal).Value = obj.Desde;
            comandoSql.Parameters.Add("@ir_hasta", SqlDbType.Decimal).Value = obj.Hasta;
            comandoSql.Parameters.Add("@ir_base", SqlDbType.Decimal).Value = obj.Base;
            comandoSql.Parameters.Add("@ir_exceso", SqlDbType.Decimal).Value = obj.Exceso;
            comandoSql.Parameters.Add("@ir_porcentaje_aplicable", SqlDbType.Decimal).Value = obj.PorcentajeAplicable;
            comandoSql.Parameters.Add("@ir_ultima_actualizacion", SqlDbType.DateTime).Value = obj.UltimaActualizacion;

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
        /// El método permite obtener la lista de registros de la entidad [IR] desde la base de datos.
        /// Los campos que se devuelven son: Id, Desde, Hasta, Base, Exceso, Porcentaje Aplicable y Última Actualización.
        /// En caso de no existir ningún registro se devuelve una lista nula o vacía.
        /// </summary>
        public List<IR> Listar()
        {
            List<IR> listaIR = new List<IR>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.IRListar;

            comandoSql.Parameters.Clear();

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();

            while (reader.Read())
            {
                IR i = new IR();

                DateTime ua;

                i.Id = int.Parse(reader["ir_id"].ToString());
                i.Desde = decimal.Parse(reader["ir_desde"].ToString());
                i.Hasta = decimal.Parse(reader["ir_hasta"].ToString());
                i.Base = decimal.Parse(reader["ir_base"].ToString());
                i.Exceso = decimal.Parse(reader["ir_exceso"].ToString());
                i.PorcentajeAplicable = decimal.Parse(reader["ir_porcentaje_aplicable"].ToString());
                DateTime.TryParse(reader["ir_ultima_actualizacion"].ToString(), out ua);
                i.UltimaActualizacion = ua;

                listaIR.Add(i);
            }

            reader.Close();

            conexionSql.Close();

            return listaIR;
        }
    }
}