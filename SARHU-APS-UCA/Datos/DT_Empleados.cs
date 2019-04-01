using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Collections.Generic;

namespace Datos
{
    public class DT_Empleados 
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();
        private List<Empleado> empleados = new List<Empleado>();

        private static DT_Empleados dtEmpleados = null;

        private DT_Empleados()
        {
            //Singleton
        }

        public static DT_Empleados Instanciar()
        {
            if (dtEmpleados == null)
            {
                dtEmpleados = new DT_Empleados();
            }
            return dtEmpleados;
        }

        // METODOS

        /// <summary>
        /// El método permite agregar un registro de la entidad [Empleado].
        /// Recibe como parámetro un objeto [Empleado] con la información a agregar a la base de datos (Nombre y Descripción).
        /// Devuelve un valor entero con el id generado.
        /// </summary>
        public int Agregar(Empleado obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.EmpleadosAgregar;
            
            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@empleado_codigo", SqlDbType.VarChar).Value = obj.Codigo;
            comandoSql.Parameters.Add("@empleado_foto", SqlDbType.VarChar).Value = obj.Foto;
            comandoSql.Parameters.Add("@empleado_nombres", SqlDbType.VarChar).Value = obj.Nombres;
            comandoSql.Parameters.Add("@empleado_apellidos", SqlDbType.VarChar).Value = obj.Apellidos;
            comandoSql.Parameters.Add("@empleado_cedula", SqlDbType.VarChar).Value = obj.Cedula;
            comandoSql.Parameters.Add("@empleado_sexo", SqlDbType.VarChar).Value = obj.Sexo;
            comandoSql.Parameters.Add("@empleado_fecha_nacimiento", SqlDbType.VarChar).Value = obj.FechaNacimiento;
            comandoSql.Parameters.Add("@empleado_estado_civil", SqlDbType.VarChar).Value = obj.EstadoCivilId;
            comandoSql.Parameters.Add("@empleado_nivel_academico", SqlDbType.VarChar).Value = obj.Codigo;
            comandoSql.Parameters.Add("@empleado_telefono ", SqlDbType.VarChar).Value = obj.Codigo;
            comandoSql.Parameters.Add("@empleado_direccion", SqlDbType.VarChar).Value = obj.Codigo;
            comandoSql.Parameters.Add("@empleado_fecha_ingreso", SqlDbType.VarChar).Value = obj.Codigo;
            comandoSql.Parameters.Add("@empleado_seguro_social", SqlDbType.VarChar).Value = obj.Codigo;
            comandoSql.Parameters.Add("@empleado_banco", SqlDbType.VarChar).Value = obj.Codigo;
            comandoSql.Parameters.Add("@empleado_cuenta_banco", SqlDbType.VarChar).Value = obj.Codigo;
            comandoSql.Parameters.Add("@localidad_id", SqlDbType.VarChar).Value = obj.Codigo;
            comandoSql.Parameters.Add("@puesto_id", SqlDbType.VarChar).Value = obj.Codigo;
            comandoSql.Parameters.Add("@empleado_observaciones", SqlDbType.VarChar).Value = obj.Codigo;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int idGenerado = int.Parse(comandoSql.ExecuteScalar().ToString());

            conexionSql.Close();

            return idGenerado;
        }

        /// <summary>
        /// El método permite borrar un registro de la entidad [Empleado].
        /// Recibe como parámetro el id [int] del registro a borrar en la base de datos.
        /// Devuelve un valor booleano para notificar si el registro fue borrado o no.
        /// </summary>
        public bool Borrar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.EmpleadosBorrar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@empleado_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int borrado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (borrado > 0);
        }

        /// <summary>
        /// El método permite consultar/buscar un registro de la entidad [Empleado].
        /// Recibe como parámetro el id [int] del registro a consultar/buscar en la base de datos.
        /// Devuelve un objeto [Empleado] nulo en caso de no encontrarse, o con la información del registro en caso que exista.
        /// </summary>
        public Empleado Consultar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.EmpleadosConsultar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@empleado_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();

            Empleado empleado = new Empleado();

            while (reader.Read())
            {
                empleado.Id = id;
                empleado.Nombre = reader["empleado_nombre"].ToString();
                empleado.Estado = bool.Parse(reader["empleado_estado"].ToString());
            }

            reader.Close();

            conexionSql.Close();

            return empleado;
        }

        /// <summary>
        /// El método permite editar un registro de la entidad [Empleado].
        /// Recibe como parámetro un objeto [Empleado] con la información editada para actualizarse en la base de datos (Nombre y Descripción).
        /// Devuelve un valor booleano para notificar si el registro fue editado o no.
        /// </summary>
        public bool Editar(Empleado obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.EmpleadosEditar;

            comandoSql.Parameters.Clear();

            comandoSql.Parameters.Add("@empleado_id", SqlDbType.Int).Value = obj.Id;
            comandoSql.Parameters.Add("@empleado_nombre", SqlDbType.VarChar).Value = obj.Nombre;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int editado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (editado > 0);
        }

        /// <summary>
        /// El método permite obtener la lista de registros de la entidad [Empleado] desde la base de datos.
        /// Los campos que se devuelven son: Id, Nombre y Descripción.
        /// En caso de no existir ningún registro se devuelve una lista nula o vacía.
        /// </summary>
        public List<Empleado> Listar()
        {
            List<Empleado> listaEmpleados = new List<Empleado>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.EmpleadosListar;

            comandoSql.Parameters.Clear();

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();

            while (reader.Read())
            {
                Empleado e = new Empleado();

                e.Id = int.Parse(reader["empleado_id"].ToString());
                e.Nombre = reader["empleado_nombre"].ToString();
                e.Estado = bool.Parse(reader["empleado_estado"].ToString());

                listaEmpleados.Add(e);
            }

            reader.Close();

            conexionSql.Close();

            this.empleados.Clear();
            this.empleados = listaEmpleados;

            return listaEmpleados;
        }

        public List<Empleado> ListarPorEstado(bool Estado)
        {
            // Actualizar
            Listar();

            List<Empleado> listEmpleados = new List<Empleado>();

            foreach (Empleado e in empleados)
            {
                if (e.Estado == Estado)
                {
                    listEmpleados.Add(e);
                }
            }

            return listEmpleados;
        }
    }
}
