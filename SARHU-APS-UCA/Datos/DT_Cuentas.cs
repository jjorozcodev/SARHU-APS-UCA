using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Collections.Generic;

namespace Datos
{
    public class DT_Cuentas : I_CRUD<Cuenta>
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();
        private List<Cuenta> cuentas = new List<Cuenta>();

        private static DT_Cuentas dtCuentas = null;

        private DT_Cuentas()
        {
            //Singleton
        }

        public static DT_Cuentas Instanciar()
        {
            if (dtCuentas == null)
            {
                dtCuentas = new DT_Cuentas();
            }
            return dtCuentas;
        }

        // METODOS

        /// <summary>
        /// El método permite agregar un registro de la entidad [Cuenta].
        /// Recibe como parámetro un objeto [Cuenta] con la información a agregar a la base de datos (Código Contable, Descripción, Cuenta de Salario, de Impuestos y de Seguros).
        /// Devuelve un valor entero con el id generado.
        /// </summary>
        public int Agregar(Cuenta obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.CuentasAgregar;

            comandoSql.Parameters.Clear();

            comandoSql.Parameters.Add("@cuenta_codigo_contable", SqlDbType.VarChar).Value = obj.CodigoContable;
            comandoSql.Parameters.Add("@cuenta_descripcion", SqlDbType.VarChar).Value = obj.Descripcion;
            comandoSql.Parameters.Add("@cuenta_codigo_salarios", SqlDbType.VarChar).Value = obj.CuentaSalario;
            comandoSql.Parameters.Add("@cuenta_codigo_impuestos", SqlDbType.VarChar).Value = obj.CuentaImpuestos;
            comandoSql.Parameters.Add("@cuenta_codigo_seguros", SqlDbType.VarChar).Value = obj.CuentaSeguros;
            comandoSql.Parameters.Add("@cuenta_planilla", SqlDbType.Bit).Value = obj.Planilla;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int idGenerado = int.Parse(comandoSql.ExecuteScalar().ToString());

            conexionSql.Close();

            return idGenerado;
        }

        /// <summary>
        /// El método permite borrar un registro de la entidad [Cuenta].
        /// Recibe como parámetro el id [int] del registro a borrar en la base de datos.
        /// Devuelve un valor booleano para notificar si el registro fue borrado o no.
        /// </summary>
        public bool Borrar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.CuentasBorrar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@cuenta_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int borrado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (borrado > 0);
        }

        /// <summary>
        /// El método permite consultar/buscar un registro de la entidad [Cuenta].
        /// Recibe como parámetro el id [int] del registro a consultar/buscar en la base de datos.
        /// Devuelve un objeto [Cuenta] nulo en caso de no encontrarse, o con la información del registro en caso que exista.
        /// </summary>
        public Cuenta Consultar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.CuentasConsultar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@cuenta_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();

            Cuenta cuenta = new Cuenta();

            while (reader.Read())
            {
                cuenta.Id = id;
                cuenta.CodigoContable = reader["cuenta_codigo_contable"].ToString();
                cuenta.Descripcion = reader["cuenta_descripcion"].ToString();
                cuenta.CuentaSalario = reader["cuenta_codigo_salarios"].ToString();
                cuenta.CuentaImpuestos = reader["cuenta_codigo_impuestos"].ToString();
                cuenta.CuentaSeguros = reader["cuenta_codigo_seguros"].ToString();
                cuenta.Planilla = bool.Parse(reader["cuenta_planilla"].ToString());
                cuenta.Estado = bool.Parse(reader["cuenta_estado"].ToString());
            }

            reader.Close();

            conexionSql.Close();

            return cuenta;
        }

        /// <summary>
        /// El método permite editar un registro de la entidad [Cuenta].
        /// Recibe como parámetro un objeto [Cuenta] con la información editada para actualizarse en la base de datos (Descripción, Cuenta de Salario, de Impuestos y de Seguros).
        /// Devuelve un valor booleano para notificar si el registro fue editado o no.
        /// </summary>
        public bool Editar(Cuenta obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.CuentasEditar;

            comandoSql.Parameters.Clear();

            comandoSql.Parameters.Add("@cuenta_id", SqlDbType.Int).Value = obj.Id;
            comandoSql.Parameters.Add("@cuenta_codigo_contable", SqlDbType.VarChar).Value = obj.CodigoContable;
            comandoSql.Parameters.Add("@cuenta_descripcion", SqlDbType.VarChar).Value = obj.Descripcion;
            comandoSql.Parameters.Add("@cuenta_codigo_salarios", SqlDbType.VarChar).Value = obj.CuentaSalario;
            comandoSql.Parameters.Add("@cuenta_codigo_impuestos", SqlDbType.VarChar).Value = obj.CuentaImpuestos;
            comandoSql.Parameters.Add("@cuenta_codigo_seguros", SqlDbType.VarChar).Value = obj.CuentaSeguros;
            comandoSql.Parameters.Add("@cuenta_planilla", SqlDbType.Bit).Value = obj.Planilla;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int editado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (editado > 0);
        }

        /// <summary>
        /// El método permite obtener la lista de registros de la entidad [Cuenta] desde la base de datos.
        /// Los campos que se devuelven son: Id, Código Contable, Cuenta de Salarios, Cuenta de Seguros, Cuenta de Impuestos, Si es de Planilla y Estado.
        /// En caso de no existir ningún registro se devuelve una lista nula o vacía.
        /// </summary>
        public List<Cuenta> Listar()
        {
            List<Cuenta> listaCuentas = new List<Cuenta>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.CuentasListar;

            comandoSql.Parameters.Clear();

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();

            while (reader.Read())
            {
                Cuenta c = new Cuenta();

                c.Id = int.Parse(reader["cuenta_id"].ToString());
                c.CodigoContable = reader["cuenta_codigo_contable"].ToString();
                c.Descripcion = reader["cuenta_descripcion"].ToString();
                c.CuentaSalario = reader["cuenta_codigo_salarios"].ToString();
                c.CuentaImpuestos = reader["cuenta_codigo_impuestos"].ToString();
                c.CuentaSeguros = reader["cuenta_codigo_seguros"].ToString();
                c.Planilla = bool.Parse(reader["cuenta_planilla"].ToString());
                c.Estado = bool.Parse(reader["cuenta_estado"].ToString());

                listaCuentas.Add(c);
            }

            reader.Close();

            conexionSql.Close();

            this.cuentas.Clear();
            this.cuentas = listaCuentas;

            return listaCuentas;
        }

        public List<Cuenta> ListarPorEstado(bool Estado)
        {
            // Actualizar
            Listar();

            List<Cuenta> listCuentas = new List<Cuenta>();

            foreach (Cuenta c in cuentas)
            {
                if (c.Estado == Estado)
                {
                    listCuentas.Add(c);
                }
            }

            return listCuentas;
        }
    }
}
