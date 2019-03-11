using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using Entidades;
using System.Data;

namespace Datos
{
    public class DTDeduccionesDevengados : IDatos<DeduccionDevengado>
    {
        //VARIABLES GLOBALES
        private SqlConnection conexionSql = Conexion.Instanciar().ConexionDB();
        private SqlCommand comandoSql = new SqlCommand();

        #region "Patrón Singleton"
        private static DTDeduccionesDevengados dtDeduccionesDevengados = null;
        private DTDeduccionesDevengados()
        {

        }

        public static DTDeduccionesDevengados Instanciar()
        {
            if (dtDeduccionesDevengados == null)
            {
                dtDeduccionesDevengados = new DTDeduccionesDevengados();
            }
            return dtDeduccionesDevengados;
        }
        #endregion

        public bool Crear(DeduccionDevengado deduccionDevengado)
        {
            //Variable tipo booleano que informará si el método se ejecutó con éxito.
            bool creado = false;

            //Se realiza la ejecución con un TRY para controlar los errores que puedan surgir
            try
            {
                //Sentencia SQL que se ejecutará en la BD
                string sentencia = "INSERT INTO T_Deducciones_Devengados (Id_Tipo_DD, Id_Empleado, Descripcion, Fecha_Registro, Valor_Porcentual, Valor_Absoluto)";
                sentencia += " VALUES(@idTipoDD, @idEmpleado, @descripcion, @fechaRegistro, @valorPorcentual, @valorAbsoluto)";
                System.Diagnostics.Debug.WriteLine("SQL enviado: " + sentencia);
                //Estableciendo parámetros necesarios para realizar la consulta SQL a la BD
                using (comandoSql = new SqlCommand(sentencia, conexionSql))
                {
                    //Los parámetros deben corresponderse con la sentencia SQL y los valores de su entidad.
                    comandoSql.Parameters.AddWithValue("@idTipoDD", deduccionDevengado.IdTipoDD);
                    comandoSql.Parameters.AddWithValue("@idEmpleado", deduccionDevengado.IdEmpleado);
                    comandoSql.Parameters.AddWithValue("@descripcion", deduccionDevengado.Descripcion);
                    comandoSql.Parameters.AddWithValue("@fechaRegistro", deduccionDevengado.FechaRegistro);
                    comandoSql.Parameters.AddWithValue("@valorPorcentual", deduccionDevengado.ValorPorcentual);
                    comandoSql.Parameters.AddWithValue("@valorAbsoluto", deduccionDevengado.ValorAbsoluto);

                    //Se abre la conexión con la base de datos para ejecutar la consulta
                    comandoSql.Connection.Open();

                    //Se ejecuta la sentencia SQL almacenando la cantidad de filas afectadas
                    int filasAfectadas = comandoSql.ExecuteNonQuery();

                    //Si hubo al menos una fila insertada, la ejecución fue exitosa.
                    if (filasAfectadas > 0)
                    {
                        creado = true;
                    }
                }
            }
            //En caso que la ejecución falle, se utiliza un manejador.
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.ToString());
                throw e;
            }
            //Terminado el intento de ejecución para la consulta SQL, se cierra la conexión a la BD.
            finally
            {
                comandoSql.Connection.Close();
            }

            //Finalmente se devuelve el valor de la variable que informa si hubo exito en la ejecución de la sentencia SQL.
            return creado;
        }

        public List<DeduccionDevengado> Listar()
        {
            //Variables locales
            SqlDataReader lectorDatos = null;
            List<DeduccionDevengado> listaDeduccionesDevengados = new List<DeduccionDevengado>();

            //Se realiza la ejecución con un TRY para controlar los errores que puedan surgir
            try
            {
                //Sentencia SQL que se ejecutará en la BD
                string sentencia = "SELECT * FROM T_Deducciones_Devengados";

                //Estableciendo parámetros necesarios para realizar la consulta SQL a la BD
                comandoSql = new SqlCommand(sentencia, conexionSql);
                comandoSql.CommandType = System.Data.CommandType.Text;

                //Se abre la conexión con la base de datos para ejecutar la consulta
                comandoSql.Connection.Open();

                //Se ejecuta la sentencia SQL y los datos obtenidos se almacenan para su posterior lectura
                lectorDatos = comandoSql.ExecuteReader();

                //Se recorre el lector de datos mientras éste contenga información
                while (lectorDatos.Read())
                {
                    //Se instancia un objeto para luego asignarle valores
                    DeduccionDevengado deduccionDevengado = new DeduccionDevengado();

                    //Se asignan los valores correspondientes a las propiedades del objeto
                    deduccionDevengado.IdDDEmpleado = Convert.ToInt32(lectorDatos["Id_DD_Empleado"].ToString());
                    deduccionDevengado.IdTipoDD = Convert.ToInt32(lectorDatos["Id_Tipo_DD"].ToString());
                    deduccionDevengado.IdEmpleado = Convert.ToInt32(lectorDatos["Id_Empleado"].ToString());
                    deduccionDevengado.Descripcion = lectorDatos["Descripcion"].ToString();
                    deduccionDevengado.FechaRegistro = Convert.ToDateTime(lectorDatos["Fecha_Registro"].ToString());
                    deduccionDevengado.ValorPorcentual = (float) Convert.ToDouble(lectorDatos["Valor_Porcentual"].ToString());
                    deduccionDevengado.ValorAbsoluto = (float) Convert.ToDouble(lectorDatos["Valor_Absoluto"].ToString());

                    //Se agrega el objeto instanciado a la lista
                    listaDeduccionesDevengados.Add(deduccionDevengado);
                }
            }
            //En caso que la ejecución falle, se utiliza un manejador.
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.ToString());
                throw e;
            }
            //Terminado el intento de ejecución para la consulta SQL, se cierra la conexión a la BD.
            finally
            {
                comandoSql.Connection.Close();
            }

            //Finalmente se devuelve el valor de la variable que informa si hubo exito en la ejecución de la sentencia SQL.
            return listaDeduccionesDevengados;
        }

        public bool Actualizar(DeduccionDevengado deduccionDevengado)
        {
            //Variable tipo booleano que informará si el método se ejecutó con éxito.
            bool actualizado = false;

            //Se realiza la ejecución con un TRY para controlar los errores que puedan surgir
            try
            {
                //Sentencia SQL que se ejecutará en la BD
                string sentencia = "UPDATE T_Deducciones_Devengados";
                sentencia += " SET Id_Tipo_DD=@idTipoDD, Id_Empleado=@idEmpleado, Descripcion=@descripcion,";
                sentencia += " Fecha_Registro=@fechaRegistro, Valor_Porcentual=@valorPorcentual, Valor_Absoluto=@valorAbsoluto";
                sentencia += " WHERE Id_DD_Empleado=@idDDEmpleado";


                //Estableciendo parámetros necesarios para realizar la consulta SQL a la BD
                using (comandoSql = new SqlCommand(sentencia, conexionSql))
                {
                    //Los parámetros deben corresponderse con la sentencia SQL y los valores de su entidad.
                    comandoSql.Parameters.AddWithValue("@idTipoDD", deduccionDevengado.IdTipoDD);
                    comandoSql.Parameters.AddWithValue("@idEmpleado", deduccionDevengado.IdEmpleado);
                    comandoSql.Parameters.AddWithValue("@descripcion", deduccionDevengado.Descripcion);
                    comandoSql.Parameters.AddWithValue("@fechaRegistro", deduccionDevengado.FechaRegistro);
                    comandoSql.Parameters.AddWithValue("@valorPorcentual", deduccionDevengado.ValorPorcentual);
                    comandoSql.Parameters.AddWithValue("@valorAbsoluto", deduccionDevengado.ValorAbsoluto);
                    comandoSql.Parameters.AddWithValue("@idDDEmpleado", deduccionDevengado.IdDDEmpleado);

                    //Se abre la conexión con la base de datos para ejecutar la consulta
                    comandoSql.Connection.Open();

                    //Se ejecuta la sentencia SQL almacenando la cantidad de filas afectadas
                    int filasAfectadas = comandoSql.ExecuteNonQuery();

                    //Si hubo al menos una fila insertada, la ejecución fue exitosa.
                    if (filasAfectadas > 0)
                    {
                        actualizado = true;
                    }
                }
            }
            //En caso que la ejecución falle, se utiliza un manejador.
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.ToString());
                throw e;
            }
            //Terminado el intento de ejecución para la consulta SQL, se cierra la conexión a la BD.
            finally
            {
                comandoSql.Connection.Close();
            }

            //Finalmente se devuelve el valor de la variable que informa si hubo exito en la ejecución de la sentencia SQL.
            return actualizado;
        }

        public bool Borrar(int idDDEmpleado)
        {
            //Variable tipo booleano que informará si el método se ejecutó con éxito.
            bool borrado = false;

            //Se realiza la ejecución con un TRY para controlar los errores que puedan surgir
            try
            {
                //Sentencia SQL que se ejecutará en la BD
                string sentencia = "DELETE FROM T_Deducciones_Devengados";
                sentencia += " WHERE Id_DD_Empleado=@idDDEmpleado";

                //Estableciendo parámetros necesarios para realizar la consulta SQL a la BD
                using (comandoSql = new SqlCommand(sentencia, conexionSql))
                {
                    //Los parámetros deben corresponderse con la sentencia SQL y los valores de su entidad.
                    comandoSql.Parameters.AddWithValue("@idDDEmpleado", idDDEmpleado);

                    //Se abre la conexión con la base de datos para ejecutar la consulta
                    comandoSql.Connection.Open();

                    //Se ejecuta la sentencia SQL almacenando la cantidad de filas afectadas
                    int filasAfectadas = comandoSql.ExecuteNonQuery();

                    //Si hubo al menos una fila insertada, la ejecución fue exitosa.
                    if (filasAfectadas > 0)
                    {
                        borrado = true;
                    }
                }
            }
            //En caso que la ejecución falle, se utiliza un manejador.
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.ToString());
                throw e;
            }
            //Terminado el intento de ejecución para la consulta SQL, se cierra la conexión a la BD.
            finally
            {
                comandoSql.Connection.Close();
            }

            //Finalmente se devuelve el valor de la variable que informa si hubo exito en la ejecución de la sentencia SQL.
            return borrado;
        }

        //Método personalizado: Devuelve una vista de Devengados
        //Funciona como Listar() pero en base a una vista para mostrar al usuario final
        public DataTable MostrarDevengados()
        {
            //Variables locales
            SqlDataReader lectorDatos = null;
            DataTable tablaDatos = new DataTable();

            //Se realiza la ejecución con un TRY para controlar los errores que puedan surgir
            try
            {
                //Sentencia SQL que se ejecutará en la BD
                string sentencia = "SELECT Id_DD_Empleado, Id_Empleado, Fecha_Registro, Concepto, Valor_Porcentual, Valor_Absoluto";
                sentencia += " FROM T_Deducciones_Devengados INNER JOIN T_Tipos_Deduccion_Devengado";
                sentencia += " ON T_Deducciones_Devengados.Id_Tipo_DD = T_Tipos_Deduccion_Devengado.Id_Tipo_DD";
                sentencia += " WHERE T_Tipos_Deduccion_Devengado.Devengado = 1";

                //Estableciendo parámetros necesarios para realizar la consulta SQL a la BD
                comandoSql = new SqlCommand(sentencia, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                //Se abre la conexión con la base de datos para ejecutar la consulta
                comandoSql.Connection.Open();

                //Se ejecuta la sentencia SQL y los datos obtenidos se almacenan para su posterior lectura
                lectorDatos = comandoSql.ExecuteReader();

                //Se recorre el lector de datos mientras éste contenga información
                tablaDatos.Load(lectorDatos);
            }
            //En caso que la ejecución falle, se utiliza un manejador.
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.ToString());
                throw e;
            }
            //Terminado el intento de ejecución para la consulta SQL, se cierra la conexión a la BD.
            finally
            {
                comandoSql.Connection.Close();
            }

            //Finalmente se devuelve el valor de la variable que informa si hubo exito en la ejecución de la sentencia SQL.
            return tablaDatos;
        }

        //Método personalizado: Devuelve una vista de Deducciones
        //Funciona como Listar() pero en base a una vista para mostrar al usuario final
        public DataTable MostrarDeducciones()
        {
            //Variables locales
            SqlDataReader lectorDatos = null;
            DataTable tablaDatos = new DataTable();

            //Se realiza la ejecución con un TRY para controlar los errores que puedan surgir
            try
            {
                //Sentencia SQL que se ejecutará en la BD
                string sentencia = "SELECT Id_DD_Empleado, Id_Empleado, Fecha_Registro, Concepto, Valor_Porcentual, Valor_Absoluto";
                sentencia += " FROM T_Deducciones_Devengados INNER JOIN T_Tipos_Deduccion_Devengado";
                sentencia += " ON T_Deducciones_Devengados.Id_Tipo_DD = T_Tipos_Deduccion_Devengado.Id_Tipo_DD";
                sentencia += " WHERE T_Tipos_Deduccion_Devengado.Devengado = 0";

                //Estableciendo parámetros necesarios para realizar la consulta SQL a la BD
                comandoSql = new SqlCommand(sentencia, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                //Se abre la conexión con la base de datos para ejecutar la consulta
                comandoSql.Connection.Open();

                //Se ejecuta la sentencia SQL y los datos obtenidos se almacenan para su posterior lectura
                lectorDatos = comandoSql.ExecuteReader();

                //Se recorre el lector de datos mientras éste contenga información
                tablaDatos.Load(lectorDatos);
            }
            //En caso que la ejecución falle, se utiliza un manejador.
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.ToString());
                throw e;
            }
            //Terminado el intento de ejecución para la consulta SQL, se cierra la conexión a la BD.
            finally
            {
                comandoSql.Connection.Close();
            }

            //Finalmente se devuelve el valor de la variable que informa si hubo exito en la ejecución de la sentencia SQL.
            return tablaDatos;
        }

    }
}
