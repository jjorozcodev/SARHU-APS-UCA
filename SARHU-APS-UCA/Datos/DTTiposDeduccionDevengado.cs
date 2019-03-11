using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using Entidades;

namespace Datos
{
    public class DTTiposDeduccionDevengado : IDatos<TipoDeduccionDevengado>
    {
        //VARIABLES GLOBALES
        private SqlConnection conexionSql = Conexion.Instanciar().ConexionDB();
        private SqlCommand comandoSql = new SqlCommand();

        #region "Patrón Singleton"
        private static DTTiposDeduccionDevengado dtTiposDeduccionDevengado = null;
        private DTTiposDeduccionDevengado()
        {

        }

        public static DTTiposDeduccionDevengado Instanciar()
        {
            if (dtTiposDeduccionDevengado == null)
            {
                dtTiposDeduccionDevengado = new DTTiposDeduccionDevengado();
            }
            return dtTiposDeduccionDevengado;
        }
        #endregion

        public bool Crear(TipoDeduccionDevengado tipoDeduccionDevengado)
        {
            //Variable tipo booleano que informará si el método se ejecutó con éxito.
            bool creado = false;

            //Se realiza la ejecución con un TRY para controlar los errores que puedan surgir
            try
            {
                //Sentencia SQL que se ejecutará en la BD
                string sentencia = "INSERT INTO T_Tipos_Deduccion_Devengado (Concepto, Devengado)";
                sentencia += " VALUES(@concepto, @devengado)";

                //Estableciendo parámetros necesarios para realizar la consulta SQL a la BD
                using (comandoSql = new SqlCommand(sentencia, conexionSql))
                {
                    //Los parámetros deben corresponderse con la sentencia SQL y los valores de su entidad.
                    comandoSql.Parameters.AddWithValue("@concepto", tipoDeduccionDevengado.Concepto);
                    comandoSql.Parameters.AddWithValue("@devengado", tipoDeduccionDevengado.Devengado);

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

        public List<TipoDeduccionDevengado> Listar()
        {
            //Variables locales
            SqlDataReader lectorDatos = null;
            List<TipoDeduccionDevengado> listaTiposDeduccionDevengado = new List<TipoDeduccionDevengado>();

            //Se realiza la ejecución con un TRY para controlar los errores que puedan surgir
            try
            {
                //Sentencia SQL que se ejecutará en la BD
                string sentencia = "SELECT * FROM T_Tipos_Deduccion_Devengado";

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
                    TipoDeduccionDevengado tipoDeduccionDevengado = new TipoDeduccionDevengado();

                    //Se asignan los valores correspondientes a las propiedades del objeto
                    tipoDeduccionDevengado.IdTipoDD = Convert.ToInt32(lectorDatos["Id_Tipo_DD"].ToString());
                    tipoDeduccionDevengado.Concepto = lectorDatos["Concepto"].ToString();
                    tipoDeduccionDevengado.Devengado = Convert.ToBoolean(lectorDatos["Devengado"].ToString());

                    //Se agrega el objeto instanciado a la lista
                    listaTiposDeduccionDevengado.Add(tipoDeduccionDevengado);
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
            return listaTiposDeduccionDevengado;
        }

        public bool Actualizar(TipoDeduccionDevengado tipoDeduccionDevengado)
        {
            //Variable tipo booleano que informará si el método se ejecutó con éxito.
            bool actualizado = false;

            //Se realiza la ejecución con un TRY para controlar los errores que puedan surgir
            try
            {
                //Sentencia SQL que se ejecutará en la BD
                string sentencia = "UPDATE T_Tipos_Deduccion_Devengado";
                sentencia += " SET Concepto=@concepto, Devengado=@devengado";
                sentencia += " WHERE Id_Tipo_DD=@idTipoDD";

                //Estableciendo parámetros necesarios para realizar la consulta SQL a la BD
                using (comandoSql = new SqlCommand(sentencia, conexionSql))
                {
                    //Los parámetros deben corresponderse con la sentencia SQL y los valores de su entidad.
                    comandoSql.Parameters.AddWithValue("@concepto", tipoDeduccionDevengado.Concepto);
                    comandoSql.Parameters.AddWithValue("@devengado", tipoDeduccionDevengado.Devengado);
                    comandoSql.Parameters.AddWithValue("@idTipoDD", tipoDeduccionDevengado.IdTipoDD);

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

        public bool Borrar(int idTipoDeduccionDevengado)
        {
            //Variable tipo booleano que informará si el método se ejecutó con éxito.
            bool borrado = false;

            //Se realiza la ejecución con un TRY para controlar los errores que puedan surgir
            try
            {
                //Sentencia SQL que se ejecutará en la BD
                string sentencia = "DELETE FROM T_Tipos_Deduccion_Devengado";
                sentencia += " WHERE Id_Tipo_DD=@idTipoDD";

                //Estableciendo parámetros necesarios para realizar la consulta SQL a la BD
                using (comandoSql = new SqlCommand(sentencia, conexionSql))
                {
                    //Los parámetros deben corresponderse con la sentencia SQL y los valores de su entidad.
                    comandoSql.Parameters.AddWithValue("@idTipoDD", idTipoDeduccionDevengado);

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

        //Método personalizado: Devuelve la lista de Tipos de Devengados
        //Funciona igual que Listar(), pero un criterio
        public List<TipoDeduccionDevengado> ListarTiposDevengado()
        {
            //Variables locales
            SqlDataReader lectorDatos = null;
            List<TipoDeduccionDevengado> listaTiposDevengado = new List<TipoDeduccionDevengado>();

            //Se realiza la ejecución con un TRY para controlar los errores que puedan surgir
            try
            {
                //Sentencia SQL que se ejecutará en la BD
                string sentencia = "SELECT * FROM T_Tipos_Deduccion_Devengado WHERE Devengado=1";

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
                    TipoDeduccionDevengado tipoDeduccionDevengado = new TipoDeduccionDevengado();

                    //Se asignan los valores correspondientes a las propiedades del objeto
                    tipoDeduccionDevengado.IdTipoDD = Convert.ToInt32(lectorDatos["Id_Tipo_DD"].ToString());
                    tipoDeduccionDevengado.Concepto = lectorDatos["Concepto"].ToString();
                    tipoDeduccionDevengado.Devengado = Convert.ToBoolean(lectorDatos["Devengado"].ToString());

                    //Se agrega el objeto instanciado a la lista
                    listaTiposDevengado.Add(tipoDeduccionDevengado);
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
            return listaTiposDevengado;
        }
        
        //Método personalizado: Devuelve la lista de Tipos de Deducciones
        //Funciona igual que Listar(), pero un criterio
        public List<TipoDeduccionDevengado> ListarTiposDeduccion()
        {
            //Variables locales
            SqlDataReader lectorDatos = null;
            List<TipoDeduccionDevengado> listaTiposDeduccion = new List<TipoDeduccionDevengado>();

            //Se realiza la ejecución con un TRY para controlar los errores que puedan surgir
            try
            {
                //Sentencia SQL que se ejecutará en la BD
                string sentencia = "SELECT * FROM T_Tipos_Deduccion_Devengado WHERE Devengado=0";

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
                    TipoDeduccionDevengado tipoDeduccionDevengado = new TipoDeduccionDevengado();

                    //Se asignan los valores correspondientes a las propiedades del objeto
                    tipoDeduccionDevengado.IdTipoDD = Convert.ToInt32(lectorDatos["Id_Tipo_DD"].ToString());
                    tipoDeduccionDevengado.Concepto = lectorDatos["Concepto"].ToString();
                    tipoDeduccionDevengado.Devengado = Convert.ToBoolean(lectorDatos["Devengado"].ToString());

                    //Se agrega el objeto instanciado a la lista
                    listaTiposDeduccion.Add(tipoDeduccionDevengado);
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
            return listaTiposDeduccion;
        }

    }
}
