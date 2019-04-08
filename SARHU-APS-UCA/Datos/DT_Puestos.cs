using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Collections.Generic;
using System;

namespace Datos
{
    public class DT_Puestos : I_CRUD<Puestos>
    {
        List<Puestos> puestos = new List<Puestos>();

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionDB();
        private SqlCommand comandoSql = new SqlCommand();
        private SqlDataAdapter adaptadorSql = null;
     

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




        public List<Puestos> Listar()
        {
            puestos.Clear();
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PuestoListar;

            comandoSql.Parameters.Clear();

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();


            while (reader.Read())
            {
                Puestos p = new Puestos();
                p.Id = reader.GetInt32(0);
                p.Nombre = reader.GetString(1);
                p.Descripcion = reader.GetString(2);
                p.CuentaId = reader.GetInt32(3);
                p.AreaId = reader.GetInt32(4);
                p.SalarioBase = reader.GetDecimal(5);

                puestos.Add(p);
            }
            reader.Close();

            conexionSql.Close();

            return puestos;
        }

        public Puestos Consultar(int id)
        {
        
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PuestoConsultar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@puesto_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
            Puestos puesto = new Puestos();

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

        public int Agregar(Puestos obj)
        {
          
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PuestoAgregar;

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

        public bool Editar(Puestos obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PuestoEditar;


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
            comandoSql.CommandText = Procedimientos.PuestoDelete;

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
            comandoSql.CommandText = Procedimientos.PuestoFuncionAgregar;

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
            comandoSql.CommandText = Procedimientos.PuestoFuncionListar;
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
            comandoSql.CommandText = Procedimientos.PuestoFuncionBorrar;

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


        public void EliminarFuncionesPuestoTodo(int idPuesto)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PuestoFuncionBorrarTodo;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@puesto_id", SqlDbType.Int).Value = idPuesto;
           

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int borrado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();
        }

    }
}
