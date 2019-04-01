using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Collections.Generic;
using System;

namespace Datos
{
    public class DT_Adelantos : I_CRUD<Adelanto>
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();
        private List<Adelanto> adelantos = new List<Adelanto>();

        private static DT_Adelantos dtAdelantos = null;

        private DT_Adelantos()
        {
            //Singleton
        }

        public static DT_Adelantos Instanciar()
        {
            if(dtAdelantos == null)
            {
                dtAdelantos = new DT_Adelantos();
            }
            return dtAdelantos;
        }

        // METODOS
        /// <summary>
        /// El método permite agregar un registro de la entidad [Adelanto].
        /// Recibe como parámetro un objeto [Adelanto] con la información a agregar a la base de datos (Id de empleado, Monto, Fecha de Entrega, Fecha de Deducción y Descripción).
        /// Devuelve un valor entero con el id generado.
        /// </summary>
        public int Agregar(Adelanto obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.AdelantosAgregar;
            
            comandoSql.Parameters.Clear();

            comandoSql.Parameters.Add("@empleado_id", SqlDbType.Int).Value = obj.EmpleadoId;
            comandoSql.Parameters.Add("@adelanto_monto", SqlDbType.Decimal).Value = obj.Monto;
            comandoSql.Parameters.Add("@adelanto_fecha_entrega", SqlDbType.Date).Value = obj.FechaEntrega.Date;
            comandoSql.Parameters.Add("@adelanto_fecha_deduccion", SqlDbType.Date).Value = obj.FechaDeduccion.Date;
            comandoSql.Parameters.Add("@adelanto_descripcion", SqlDbType.VarChar).Value = obj.Descripcion;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int idGenerado = int.Parse(comandoSql.ExecuteScalar().ToString());

            conexionSql.Close();

            return idGenerado;
        }

        /// <summary>
        /// El método permite borrar un registro de la entidad [Adelanto].
        /// Recibe como parámetro el id [int] del registro a borrar en la base de datos.
        /// Devuelve un valor booleano para notificar si el registro fue borrado o no.
        /// </summary>
        public bool Borrar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.AdelantosBorrar;

            comandoSql.Parameters.Clear();

            comandoSql.Parameters.Add("@adelanto_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int borrado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (borrado > 0);
        }

        /// <summary>
        /// El método permite consultar/buscar un registro de la entidad [Adelanto].
        /// Recibe como parámetro el id [int] del registro a consultar/buscar en la base de datos.
        /// Devuelve un objeto [Adelanto] nulo en caso de no encontrarse, o con la información del registro en caso que exista.
        /// </summary>
        public Adelanto Consultar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.AdelantosConsultar;

            comandoSql.Parameters.Clear();

            comandoSql.Parameters.Add("@adelanto_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();

            Adelanto adelanto = new Adelanto();

            while (reader.Read())
            {
                DateTime fe, fd;

                adelanto.Id = id;
                adelanto.EmpleadoId = int.Parse(reader["empleado_id"].ToString());
                adelanto.Monto = decimal.Parse(reader["adelanto_monto"].ToString());
                DateTime.TryParse(reader["adelanto_fecha_entrega"].ToString(), out fe);
                adelanto.FechaEntrega = fe;
                DateTime.TryParse(reader["adelanto_fecha_deduccion"].ToString(), out fd);
                adelanto.FechaDeduccion = fd;
                adelanto.Descripcion = reader["adelanto_descripcion"].ToString();
                adelanto.Cancelado = bool.Parse(reader["adelanto_cancelado"].ToString());
                adelanto.Estado = bool.Parse(reader["adelanto_estado"].ToString());
                
            }

            reader.Close();

            conexionSql.Close();

            return adelanto;
        }

        /// <summary>
        /// El método permite editar un registro de la entidad [Adelanto].
        /// Recibe como parámetro un objeto [Adelanto] con la información editada para actualizarse en la base de datos (Id de empleado, Monto, Fecha de Entrega, Fecha de Deducción y Descripción).
        /// Devuelve un valor booleano para notificar si el registro fue editado o no.
        /// </summary>
        public bool Editar(Adelanto obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.AdelantosEditar;
            
            comandoSql.Parameters.Clear();

            comandoSql.Parameters.Add("@adelanto_id", SqlDbType.Int).Value = obj.Id;
            comandoSql.Parameters.Add("@empleado_id", SqlDbType.Int).Value = obj.EmpleadoId;
            comandoSql.Parameters.Add("@adelanto_monto", SqlDbType.Decimal).Value = obj.Monto;
            comandoSql.Parameters.Add("@adelanto_fecha_entrega", SqlDbType.Date).Value = obj.FechaEntrega.Date;
            comandoSql.Parameters.Add("@adelanto_fecha_deduccion", SqlDbType.Date).Value = obj.FechaDeduccion.Date;
            comandoSql.Parameters.Add("@adelanto_descripcion", SqlDbType.VarChar).Value = obj.Descripcion;
            comandoSql.Parameters.Add("@adelanto_cancelado", SqlDbType.Bit).Value = obj.Cancelado;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int editado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (editado > 0);
        }

        /// <summary>
        /// El método permite obtener la lista de registros de la entidad [Adelanto] desde la base de datos.
        /// Los campos que se devuelven son: Id de Adelanto, Id de Empleado, Monto, Fecha de Entrega, Fecha de Deducción, Descripción, Cancelado y Estado.
        /// En caso de no existir ningún registro se devuelve una lista nula o vacía.
        /// </summary>
        public List<Adelanto> Listar()
        {
            List<Adelanto> listaAdelantos = new List<Adelanto>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.AdelantosListar;
            
            comandoSql.Parameters.Clear();

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();

            while (reader.Read())
            {
                Adelanto a = new Adelanto();

                DateTime fe, fd;

                a.Id = int.Parse(reader["adelanto_id"].ToString());
                a.EmpleadoId = int.Parse(reader["empleado_id"].ToString());
                a.Monto = decimal.Parse(reader["adelanto_monto"].ToString());
                DateTime.TryParse(reader["adelanto_fecha_entrega"].ToString(), out fe);
                a.FechaEntrega = fe;
                DateTime.TryParse(reader["adelanto_fecha_deduccion"].ToString(), out fd);
                a.FechaDeduccion = fd;
                a.Descripcion = reader["adelanto_descripcion"].ToString();
                a.Cancelado = bool.Parse(reader["adelanto_cancelado"].ToString());
                a.Estado = bool.Parse(reader["adelanto_estado"].ToString());

                listaAdelantos.Add(a);
            }

            reader.Close();

            conexionSql.Close();

            this.adelantos.Clear();
            this.adelantos = listaAdelantos;

            return listaAdelantos;
        }

        public List<Adelanto> ListarPorEstado(bool Estado)
        {
            // Actualizar
            Listar();

            List<Adelanto> listAdelantos = new List<Adelanto>();

            foreach (Adelanto a in adelantos)
            {
                if (a.Estado == Estado)
                {
                    listAdelantos.Add(a);
                }
            }

            return listAdelantos;
        }
    }
}
