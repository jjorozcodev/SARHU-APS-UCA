using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Collections.Generic;
using System;

namespace Datos
{
    public class DT_Adendums : I_CRUD<Adendum>
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();
        private List<Adendum> adendums = new List<Adendum>();

        private static DT_Adendums dtAdendums = null;

        private DT_Adendums()
        {
            //Singleton
        }

        public static DT_Adendums Instanciar()
        {
            if(dtAdendums == null)
            {
                dtAdendums = new DT_Adendums();
            }
            return dtAdendums;
        }

        // METODOS
        /// <summary>
        /// El método permite agregar un registro de la entidad [Adendum].
        /// Recibe como parámetro un objeto [Adendum] con la información a agregar a la base de datos (Id de empleado, Incremento Salarial, Fecha de Aplicación y Observaciones).
        /// Devuelve un valor entero con el id generado.
        /// </summary>
        public int Agregar(Adendum obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.AdendumsAgregar;

            comandoSql.Parameters.Clear();

            comandoSql.Parameters.Add("@empleado_id", SqlDbType.Int).Value = obj.EmpleadoId;
            comandoSql.Parameters.Add("@adendum_incremento_salarial", SqlDbType.Decimal).Value = obj.IncrementoSalarial;
            comandoSql.Parameters.Add("@adendum_fecha_aplicacion", SqlDbType.Date).Value = obj.FechaAplicacion.Date;
            comandoSql.Parameters.Add("@adendum_observaciones", SqlDbType.VarChar).Value = obj.Observaciones;

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }

            int idGenerado = int.Parse(comandoSql.ExecuteScalar().ToString());

            conexionSql.Close();

            return idGenerado;
        }

        /// <summary>
        /// El método permite borrar un registro de la entidad [Adendum].
        /// Recibe como parámetro el id [int] del registro a borrar en la base de datos.
        /// Devuelve un valor booleano para notificar si el registro fue borrado o no.
        /// </summary>
        public bool Borrar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.AdendumsBorrar;

            comandoSql.Parameters.Clear();

            comandoSql.Parameters.Add("@adendum_id", SqlDbType.Int).Value = id;

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }

            int borrado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (borrado > 0);
        }

        /// <summary>
        /// El método permite consultar/buscar un registro de la entidad [Adendum].
        /// Recibe como parámetro el id [int] del registro a consultar/buscar en la base de datos.
        /// Devuelve un objeto [Adendum] nulo en caso de no encontrarse, o con la información del registro en caso que exista.
        /// </summary>
        public Adendum Consultar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.AdendumsConsultar;

            comandoSql.Parameters.Clear();

            comandoSql.Parameters.Add("@adendum_id", SqlDbType.Int).Value = id;

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();

            Adendum adendum = new Adendum();

            while (reader.Read())
            {
                DateTime fa;
                
                adendum.Id = id;
                adendum.EmpleadoId = int.Parse(reader["empleado_id"].ToString());
                adendum.IncrementoSalarial = decimal.Parse(reader["adendum_incremento_salarial"].ToString());
                DateTime.TryParse(reader["adendum_fecha_aplicacion"].ToString(), out fa);
                adendum.FechaAplicacion = fa;
                adendum.Observaciones = reader["adendum_observaciones"].ToString();
                adendum.Estado = bool.Parse(reader["adendum_estado"].ToString());
                
            }

            reader.Close();

            conexionSql.Close();

            return adendum;
        }

        /// <summary>
        /// El método permite editar un registro de la entidad [Adendum].
        /// Recibe como parámetro un objeto [Adendum] con la información editada para actualizarse en la base de datos (Ide de Empleado, Incremento Salarial, Fecha de Aplicación y Observaciones).//@ int, @ int, @ decimal (8,2), @adendum_fecha_aplicacion date, @adendum_observaciones varchar(150)
        /// Devuelve un valor booleano para notificar si el registro fue editado o no.
        /// </summary>
        public bool Editar(Adendum obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.AdendumsEditar;
            
            comandoSql.Parameters.Clear();

            comandoSql.Parameters.Add("@adendum_id", SqlDbType.Int).Value = obj.Id;
            comandoSql.Parameters.Add("@empleado_id", SqlDbType.Int).Value = obj.EmpleadoId;
            comandoSql.Parameters.Add("@adendum_incremento_salarial", SqlDbType.Decimal).Value = obj.IncrementoSalarial;
            comandoSql.Parameters.Add("@adendum_fecha_aplicacion", SqlDbType.Date).Value = obj.FechaAplicacion.Date;
            comandoSql.Parameters.Add("@adendum_observaciones", SqlDbType.VarChar).Value = obj.Observaciones;

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
        /// El método permite obtener la lista de registros de la entidad [Adendum] desde la base de datos.
        /// Los campos que se devuelven son: Id de Adendum, Ide de Empleado, Incremento Salarial, Fecha de Aplicación, Observaciones y Estado.
        /// En caso de no existir ningún registro se devuelve una lista nula o vacía.
        /// </summary>
        public List<Adendum> Listar()
        {
            List<Adendum> listaAdendums = new List<Adendum>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.AdendumsListar;
            
            comandoSql.Parameters.Clear();

            if (conexionSql.State != ConnectionState.Open)
            {
                conexionSql.Close();
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();

            while (reader.Read())
            {
                Adendum a = new Adendum();
                ///, , , , , 
                DateTime fa;

                a.Id = int.Parse(reader["adendum_id"].ToString());
                a.EmpleadoId = int.Parse(reader["empleado_id"].ToString());
                a.IncrementoSalarial = decimal.Parse(reader["adendum_incremento_salarial"].ToString());
                DateTime.TryParse(reader["adendum_fecha_aplicacion"].ToString(), out fa);
                a.FechaAplicacion = fa;
                a.Observaciones = reader["adendum_observaciones"].ToString();
                a.Estado = bool.Parse(reader["adendum_estado"].ToString());
                
                listaAdendums.Add(a);
            }

            reader.Close();

            conexionSql.Close();

            this.adendums.Clear();
            this.adendums = listaAdendums;

            return listaAdendums;
        }

        public List<Adendum> ListarPorEstado(bool Estado)
        {
            // Actualizar
            Listar();

            List<Adendum> listAdendums = new List<Adendum>();

            foreach (Adendum a in adendums)
            {
                if (a.Estado == Estado)
                {
                    listAdendums.Add(a);
                }
            }

            return listAdendums;
        }
    }
}
