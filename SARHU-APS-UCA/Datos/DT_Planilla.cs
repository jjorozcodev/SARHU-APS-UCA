using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class DT_Planilla : I_CRUD<Planilla_Empleado>
    {
        private List<Planilla_Empleado> ListPe = new List<Planilla_Empleado>();
        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();
        private SqlDataAdapter adaptadorSql = null;



        private static DT_Planilla dtPlanilla = null;


        private DT_Planilla()
        {
            //Singleton
        }

        public static DT_Planilla Instanciar()
        {
            if (dtPlanilla == null)
            {
                dtPlanilla = new DT_Planilla();

            }
            return dtPlanilla;
        }


        public int Agregar(Planilla_Empleado obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PlanillasAgregar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@localidad_id", SqlDbType.Int).Value = obj.Idlocalidad;
            comandoSql.Parameters.Add("@director_id", SqlDbType.Int).Value = obj.Iddirector;
            comandoSql.Parameters.Add("@fecha_elaboracion", SqlDbType.Date).Value = obj.Fecha_elaboracion;
            comandoSql.Parameters.Add("@responsable_id", SqlDbType.Int).Value = obj.Idresponsable;
            comandoSql.Parameters.Add("@fecha_aprobacion", SqlDbType.Date).Value = obj.Fecha_aprobacion;
            comandoSql.Parameters.Add("@observaciones", SqlDbType.VarChar).Value = obj.Observacion;
            comandoSql.Parameters.Add("@guardado", SqlDbType.Bit).Value = obj.Guardado;
            comandoSql.Parameters.Add("@aprobado", SqlDbType.Bit).Value = obj.Aprobado;
            comandoSql.Parameters.Add("@estado", SqlDbType.Bit).Value = obj.Estado;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }


            //int agregado = comandoSql.ExecuteNonQuery();
            int idPlanilla = Convert.ToInt32(comandoSql.ExecuteScalar());
            conexionSql.Close();


            return idPlanilla;
        }

        public bool Borrar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PlanillasBorrar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@planilla_id", SqlDbType.Int).Value = id;


            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int borrado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();
            return (borrado > 0);
        }

        public Planilla_Empleado Consultar(int id)
        {                     

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PlanillasConsultar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@planilla_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
            Planilla_Empleado Pe = new Planilla_Empleado();

            while (reader.Read())
            {
                Pe.Id = id;
                Pe.Idlocalidad = reader.GetInt32(0);
                Pe.Iddirector = reader.GetInt32(1);
                Pe.Fecha_elaboracion = reader.GetDateTime(2);
                Pe.Idresponsable = reader.GetInt32(3);
                Pe.Fecha_aprobacion = reader.GetDateTime(4);
                Pe.Observacion = reader.GetString(5);
                Pe.Guardado = reader.GetBoolean(6);
                Pe.Aprobado = reader.GetBoolean(7);
                Pe.Estado = reader.GetBoolean(8);
            }
            reader.Close();

            conexionSql.Close();

            return Pe;
        }

        public bool Editar(Planilla_Empleado obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PlanillasEditar;


            comandoSql.Parameters.Clear();

            comandoSql.Parameters.Add("@planilla_id", SqlDbType.VarChar).Value = obj.Id;
            comandoSql.Parameters.Add("@localidad_id", SqlDbType.Int).Value = obj.Idlocalidad;
            comandoSql.Parameters.Add("@director_id", SqlDbType.Int).Value = obj.Iddirector;
            comandoSql.Parameters.Add("@fecha_elaboracion", SqlDbType.Date).Value = obj.Fecha_elaboracion;
            comandoSql.Parameters.Add("@responsable_id", SqlDbType.Int).Value = obj.Idresponsable;
            comandoSql.Parameters.Add("@fecha_aprobacion", SqlDbType.Date).Value = obj.Fecha_aprobacion;
            comandoSql.Parameters.Add("@observaciones", SqlDbType.VarChar).Value = obj.Observacion;
            comandoSql.Parameters.Add("@guardado", SqlDbType.Bit).Value = obj.Guardado;
            comandoSql.Parameters.Add("@aprobado", SqlDbType.Bit).Value = obj.Aprobado;
            comandoSql.Parameters.Add("@estado", SqlDbType.Bit).Value = obj.Estado;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int editado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (editado > 0);
        }

        public List<Planilla_Empleado> Listar()
        {
            ListPe.Clear();
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PlanillasListar;

            comandoSql.Parameters.Clear();

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();


            while (reader.Read())
            {
                Planilla_Empleado Pe = new Planilla_Empleado();
                Pe.Id = reader.GetInt32(0);
                Pe.Idlocalidad = reader.GetInt32(1);
                Pe.Iddirector = reader.GetInt32(2);
                Pe.Fecha_elaboracion = reader.GetDateTime(3);
                Pe.Idresponsable = reader.GetInt32(4);
                Pe.Fecha_aprobacion = reader.GetDateTime(5);
                Pe.Observacion = reader.GetString(6);
                Pe.Guardado = reader.GetBoolean(7);
                Pe.Aprobado = reader.GetBoolean(8);
                Pe.Estado = reader.GetBoolean(9);
                ListPe.Add(Pe);
            }
            reader.Close();

            conexionSql.Close();

            return ListPe;
        }

        ///METODOS PARA EL DETALLE DE LA PLANILLA
        public void AgregarDetallePlanilla(int idPlanilla, decimal porcentajeINSSP, decimal porcentajeINSSL, decimal Inatec, decimal techoSalarial)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PlanillasDetalleAgregar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@planilla_id", SqlDbType.Int).Value = idPlanilla;
            comandoSql.Parameters.Add("@porcentaje_INSS_P", SqlDbType.Decimal).Value = porcentajeINSSP;
            comandoSql.Parameters.Add("@porcentaje_INSS_L", SqlDbType.Decimal).Value = porcentajeINSSL;
            comandoSql.Parameters.Add("@porcentaje_INATEC", SqlDbType.Decimal).Value = Inatec;
            comandoSql.Parameters.Add("@techo_salarial", SqlDbType.Decimal).Value = techoSalarial;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }


            int agregado = comandoSql.ExecuteNonQuery();
            //int idPlanilla = Convert.ToInt32(comandoSql.ExecuteScalar());
            conexionSql.Close();

        }

        public void EditarDetallePlanilla(int idPlanilla, decimal porcentajeINSSP, decimal porcentajeINSSL, decimal Inatec, decimal techoSalarial)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PlanillasDetalleEditar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@planilla_id", SqlDbType.Int).Value = idPlanilla;
            comandoSql.Parameters.Add("@porcentaje_INSS_P", SqlDbType.Int).Value = porcentajeINSSP;
            comandoSql.Parameters.Add("@porcentaje_INSS_L", SqlDbType.Date).Value = porcentajeINSSL;
            comandoSql.Parameters.Add("@porcentaje_INATEC", SqlDbType.Int).Value = Inatec;
            comandoSql.Parameters.Add("@techo_salarial", SqlDbType.Int).Value = techoSalarial;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }


            int editado = comandoSql.ExecuteNonQuery();
            //int idPlanilla = Convert.ToInt32(comandoSql.ExecuteScalar());
            conexionSql.Close();

        }

        public DataTable ConsultarDetallePlanilla(int idPlanilla)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PlanillasDetalleConsultar;
            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@planilla_id", SqlDbType.Int).Value = idPlanilla;
            adaptadorSql = new SqlDataAdapter(comandoSql);
            DataTable dt = new DataTable();
            adaptadorSql.Fill(dt);
            adaptadorSql.Dispose();
            return dt;
        }

        public DataTable ListarDetallePlanilla()
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PlanillasDetalleListar;
            comandoSql.Parameters.Clear();

            adaptadorSql = new SqlDataAdapter(comandoSql);
            DataTable dt = new DataTable();
            adaptadorSql.Fill(dt);
            adaptadorSql.Dispose();
            return dt;
        }
        ///METODOS PARA EL PLANILLA DEL EMPLEADO
        public void GuardarDetalleEmpleado(int Idplanilla, int Idempleado, decimal salarioBase, decimal montoInssPatronal, decimal montoInssLaboral,
                                            decimal montoIR, decimal porcentajeAplicado, decimal montoIngreso, decimal montoDeducciones, decimal salarioDevengado, decimal horasExtra)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PlanillasEmpleadoAgregar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@planilla_id", SqlDbType.Int).Value = Idplanilla;
            comandoSql.Parameters.Add("@empleado_id", SqlDbType.Int).Value = Idempleado;
            comandoSql.Parameters.Add("@salario_base", SqlDbType.Decimal).Value = salarioBase;
            comandoSql.Parameters.Add("@monto_INSS_P", SqlDbType.Decimal).Value = montoInssPatronal;
            comandoSql.Parameters.Add("@monto_INSS_L", SqlDbType.Decimal).Value = montoInssLaboral;
            comandoSql.Parameters.Add("@monto_IR", SqlDbType.Decimal).Value = montoIR;
            comandoSql.Parameters.Add("@porcentaje_IR_aplicado", SqlDbType.Decimal).Value = porcentajeAplicado;
            comandoSql.Parameters.Add("@monto_ingresos", SqlDbType.Decimal).Value = montoIngreso;
            comandoSql.Parameters.Add("@monto_deducciones", SqlDbType.Decimal).Value = montoDeducciones;
            comandoSql.Parameters.Add("@salario_devengado", SqlDbType.Decimal).Value = salarioDevengado;
            comandoSql.Parameters.Add("@horas_extra", SqlDbType.Decimal).Value = horasExtra;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }


            int agregado = comandoSql.ExecuteNonQuery();
            //int idPlanilla = Convert.ToInt32(comandoSql.ExecuteScalar());
            conexionSql.Close();


        }

        public DataTable ConsultarDetalleEmpleado(int idPlanilla)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PlanillasEmpleadoConsultar;
            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@planilla_id", SqlDbType.Int).Value = idPlanilla;
            adaptadorSql = new SqlDataAdapter(comandoSql);
            DataTable dt = new DataTable();
            adaptadorSql.Fill(dt);
            adaptadorSql.Dispose();
            return dt;
        }

        public DataTable ListarDetalleEmpleado()
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PlanillasEmpleadoListar;
            comandoSql.Parameters.Clear();
          
            adaptadorSql = new SqlDataAdapter(comandoSql);
            DataTable dt = new DataTable();
            adaptadorSql.Fill(dt);
            adaptadorSql.Dispose();
            return dt;
        }

        public void EditarDetalleEmpleado(int Idplanilla, decimal salarioBase, decimal montoInssPatronal, decimal montoInssLaboral,
                                           decimal montoIR, decimal porcentajeAplicado, decimal montoIngreso, decimal montoDeducciones, decimal salarioDevengado)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.PlanillasEmpleadoEditar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@planilla_id", SqlDbType.Int).Value = Idplanilla;           
            comandoSql.Parameters.Add("@salario_base", SqlDbType.Date).Value = salarioBase;
            comandoSql.Parameters.Add("@monto_INSS_P", SqlDbType.Int).Value = montoInssPatronal;
            comandoSql.Parameters.Add("@monto_INSS_L", SqlDbType.Date).Value = montoInssLaboral;
            comandoSql.Parameters.Add("@monto_IR", SqlDbType.VarChar).Value = montoIR;
            comandoSql.Parameters.Add("@porcentaje_IR_aplicado", SqlDbType.Bit).Value = porcentajeAplicado;
            comandoSql.Parameters.Add("@monto_ingresos", SqlDbType.Bit).Value = montoIngreso;
            comandoSql.Parameters.Add("@monto_deducciones", SqlDbType.Bit).Value = montoDeducciones;
            comandoSql.Parameters.Add("@salario_devengado", SqlDbType.Bit).Value = salarioDevengado;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }


            int Editado = comandoSql.ExecuteNonQuery();
            //int idPlanilla = Convert.ToInt32(comandoSql.ExecuteScalar());
            conexionSql.Close();


        }

    }
}
