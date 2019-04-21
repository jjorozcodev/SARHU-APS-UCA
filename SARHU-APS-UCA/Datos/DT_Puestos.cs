using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Collections.Generic;
using System;

namespace Datos
{
    public class DT_Puestos : I_CRUD<Puesto>
    {
        //GLOBALES

       
        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();
        private SqlDataAdapter adaptadorSql = null;
        List<Puesto> puestos = new List<Puesto>();

        private static DT_Puestos dtPuestos = null;
        
        private DT_Puestos()
        {
            //Singleton
        }

        public static DT_Puestos Instanciar()
        {
            if (dtPuestos == null)
            {
                dtPuestos = new DT_Puestos();
            }
            return dtPuestos;
        }

        // METODOS

        /// <summary>
        /// El método permite agregar un registro de la entidad [Puesto].
        /// Recibe como parámetro un objeto [Puesto] con la información a agregar a la base de datos (Código Contable, Descripción, Cuenta de Salario, de Impuestos y de Seguros).
        /// Devuelve un valor entero con el id generado.
        /// </summary>
        public int Agregar(Puesto obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PuestosAgregar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@puesto_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@puesto_descripcion", SqlDbType.VarChar).Value = obj.Descripcion;
            comandoSql.Parameters.Add("@cuenta_id", SqlDbType.Int).Value = obj.CuentaId;
            comandoSql.Parameters.Add("@area_id", SqlDbType.Int).Value = obj.AreaId;
            comandoSql.Parameters.Add("@puesto_salario_base", SqlDbType.Decimal).Value = obj.SalarioBase;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }


            //int agregado = comandoSql.ExecuteNonQuery();
            int idPuesto = Convert.ToInt32(comandoSql.ExecuteScalar());
            conexionSql.Close();

            return idPuesto;
        }

        public List<Puesto> Listar()
        {
            puestos.Clear();
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PuestosListar;

            comandoSql.Parameters.Clear();

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();


            while (reader.Read())
            {
                Puesto p = new Puesto();
                p.Id = reader.GetInt32(0);
                p.Nombre = reader.GetString(1);
                p.Descripcion = reader.GetString(2);
                p.CuentaId = reader.GetInt32(3);
                p.AreaId = reader.GetInt32(4);
                p.SalarioBase = reader.GetDecimal(5);
                p.Estado = reader.GetBoolean(6);
                puestos.Add(p);
            }
            reader.Close();

            conexionSql.Close();

            return puestos;
        }

        public List<Puesto> ListarPorEstado(bool Estado)
        {
            Listar();
            List<Puesto> PuestosActivos = new List<Puesto>();
            foreach (Puesto p in puestos)
            {
                if (p.Estado == Estado)
                {
                    PuestosActivos.Add(p);
                }
            }

            return PuestosActivos;

        }

        public Puesto Consultar(int id)
        {
        
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PuestosConsultar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@puesto_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
            Puesto puesto = new Puesto();

            while (reader.Read())
            {                
                puesto.Nombre = reader.GetString(0);
                puesto.Descripcion = reader.GetString(1);
                puesto.CuentaId = reader.GetInt32(2);
                puesto.AreaId = reader.GetInt32(3);
                puesto.SalarioBase = reader.GetDecimal(4);
            }
            reader.Close();

            conexionSql.Close();

            return puesto;
        }

        public bool Editar(Puesto obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PuestosEditar;


            comandoSql.Parameters.Clear();

            comandoSql.Parameters.Add("@puesto_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@puesto_descripcion", SqlDbType.VarChar).Value = obj.Descripcion;
            comandoSql.Parameters.Add("@cuenta_id", SqlDbType.Int).Value = obj.CuentaId;
            comandoSql.Parameters.Add("@area_id", SqlDbType.Int).Value = obj.AreaId;
            comandoSql.Parameters.Add("@puesto_salario_base", SqlDbType.Decimal).Value = obj.SalarioBase;
            comandoSql.Parameters.Add("@puesto_id", SqlDbType.Int).Value = obj.Id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int editado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (editado > 0);
        }

        public bool Borrar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PuestosBorrar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@puesto_id", SqlDbType.Int).Value = id;
            

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int borrado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();
            return (borrado > 0);
        }

        public void AgregarPuestoFunciones(int FuncionId, int idpuesto)
        {


            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PuestoFuncionesAgregar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@puesto_id", SqlDbType.VarChar).Value = idpuesto;
            comandoSql.Parameters.Add("@funcion_id", SqlDbType.VarChar).Value = FuncionId;


            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int agregado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();
        }

        public DataTable ListarPuestosFunciones()
        {
            // TODO: Para mostrar en la tabla.
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PuestoFuncionesListar;
            comandoSql.Parameters.Clear();
            adaptadorSql = new SqlDataAdapter(comandoSql);
            DataTable dt = new DataTable();
            adaptadorSql.Fill(dt);
            adaptadorSql.Dispose();
            return dt;
        }


        public void EliminarFuncionesPuesto(int idPuesto, int idFuncion)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PuestoFuncionesBorrar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@puesto_id", SqlDbType.Int).Value = idPuesto;
            comandoSql.Parameters.Add("@funcion_id", SqlDbType.Int).Value = idFuncion;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int borrado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();
        }


     

    }
}
