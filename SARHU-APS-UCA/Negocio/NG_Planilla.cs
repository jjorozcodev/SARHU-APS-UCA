using System;
using System.Collections.Generic;
using System.Data;
using Datos;
using System.Linq;
using Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NG_Planilla
    {

        private static NG_Planilla ngPlanilla = null;

        // Llamado a la Capa de Datos
        DT_Planilla dtPlanilla = DT_Planilla.Instanciar();


        //Llamados a la capa de Negocio
        private NG_IR ngIR = NG_IR.Instanciar();
        private NG_Empleados ngEmpleado = NG_Empleados.Instanciar();
        private NG_Puestos ngPuesto = NG_Puestos.Instanciar();
        private NG_INSS ngInss = NG_INSS.Instanciar();
        private NG_Localidades ngLocalidades = NG_Localidades.Instanciar();
        private NG_Adelantos ngAdelantos = NG_Adelantos.Instanciar();
        private NG_Bonos ngBonos = NG_Bonos.Instanciar();
        private NG_Adendums ngAdendums = NG_Adendums.Instanciar();
        private NG_Variables ngVariables = NG_Variables.Instanciar();

        // Lista de Datos
        private List<IR> tablaIR = new List<IR>();
        private List<Empleado> empleados = new List<Empleado>();
        private List<Puesto> puestos = new List<Puesto>();
        private static DataTable Planilla;
        private DataTable vistaPlanilla;
        private List<INSS> inss = new List<INSS>();
        private List<Adelanto> adelanto = new List<Adelanto>();
        private List<Bono> bonos = new List<Bono>();
        private List<Adendum> adendums = new List<Adendum>();
        private List<Planilla_Empleado> planillaEncabezado = new List<Planilla_Empleado>();

        //Variables numericas
        private decimal months = 0m;
        private decimal diasDelMes = 0m;
        private decimal inssAnual = 0m;
        private decimal montoHorasExtra = 0m;
        private decimal Iraplicado = 0m;

        //Variables para DataTable
        private decimal montoinssPatronal = 0m;
        private decimal irMensual = 0m;
        private decimal montoinssLaboral = 0m;
        private static decimal salariototal = 0m;
        private decimal montoingreso = 0m;
        private decimal montodeducciones = 0m;
        private decimal horasExtra = 0m;


        private NG_Planilla()
        {
            //Singleton
            RecuperarVariables();
        }


        public static NG_Planilla Instanciar()
        {
            if (ngPlanilla == null)
            {
                ngPlanilla = new NG_Planilla();
                
            }
            
            return ngPlanilla;
        }

        //Metodos básicos del CRUD
        public DataTable ObtenerPlanilla(int id)
        {
            GenerarPlanilla(id);
            return Planilla;
        }


        public int AgregarPlanilla(Planilla_Empleado Pemp, DataTable dataPlanilla, decimal porcentajeINSSp, decimal porcentajeINSSL, decimal porcentajeInactec, decimal techoSalarial)
        {
            int resp = 0;

            Planilla = dataPlanilla;
            planillaEncabezado = dtPlanilla.Listar();

            foreach (Planilla_Empleado planemp in planillaEncabezado)
            {
                if (planemp.Fecha_elaboracion.Month != Pemp.Fecha_elaboracion.Month)
                {
                    int Idplanilla = dtPlanilla.Agregar(Pemp);
                    if (Idplanilla > 0)
                    {
                        resp = 1;

                        dtPlanilla.AgregarDetallePlanilla(Idplanilla, porcentajeINSSp, porcentajeINSSL, porcentajeInactec, techoSalarial);
                        AgregarDetalleEmpleado(Idplanilla);

                    }
                    else
                    {
                        resp = 0;
                    }
                }
                else
                {
                    resp = 3;
                }

            }
            return resp;
        }

        private void AgregarDetalleEmpleado(int idPlanilla)
        {

            foreach (DataRow row in Planilla.Rows)
            {
                int idEmpleado = Convert.ToInt32(row["Id_Empleado"].ToString());
                decimal salarioBase = Convert.ToDecimal(row["Salario_base"].ToString());
                decimal pagoInssL = Convert.ToDecimal(row["Pago_Inss_Laboral"].ToString());
                decimal pagoInssP = Convert.ToDecimal(row["Pago_Inss_Patronal"].ToString());
                decimal pagoIR = Convert.ToDecimal(row["Pago_IR"].ToString());
                decimal porcentajeAplicado = Convert.ToDecimal(row["Porcentaje_Aplicado"].ToString());
                decimal montoingreso = Convert.ToDecimal(row["Monto_de_Ingreso"].ToString());
                decimal montoDeduccion = Convert.ToDecimal(row["Monto_de_Deducciones"].ToString());
                decimal salarioDevengado = Convert.ToDecimal(row["Salario_Devengado"].ToString());
                decimal horasExtra = Convert.ToDecimal(row["Horas_Extra"].ToString());


                dtPlanilla.GuardarDetalleEmpleado(idPlanilla, idEmpleado, salarioBase, pagoInssP, pagoInssL, pagoIR, porcentajeAplicado, montoingreso, montodeducciones, salarioDevengado, horasExtra);
            }


        }

        public Planilla_Empleado ConsultarPlanillaEmpleado(int id)
        {
            return dtPlanilla.Consultar(id);
        }

        public DataTable ListarPlanillas()
        {
            vistaPlanilla = new DataTable();
            InitVistaPlanilla();

            planillaEncabezado = dtPlanilla.Listar();

            foreach (Planilla_Empleado plan in planillaEncabezado)
            {
                foreach (Localidad local in ngLocalidades.ListarPorEstado(true))
                {
                    if (plan.Idlocalidad == local.Id)
                    {
                        if (plan.Aprobado)
                        {
                            vistaPlanilla.Rows.Add(plan.Id, local.Alias, plan.Fecha_elaboracion, "Sí", plan.Fecha_aprobacion);
                        }
                        else
                        {
                            vistaPlanilla.Rows.Add(plan.Id, local.Alias, plan.Fecha_elaboracion, "No", plan.Fecha_aprobacion);
                        }
                    }
                }
            }
            return vistaPlanilla;
        }

        public bool EditarPlanilla(Planilla_Empleado pemp)
        {
            return dtPlanilla.Editar(pemp);
        }

        public DataTable ConsultarDetallePlanilla(int idPlanilla)
        {
            return dtPlanilla.ConsultarDetallePlanilla(idPlanilla);
        }

        public DataTable ConsultarDetalleEmpleado(int idPlanilla)
        {
            Planilla = new DataTable();
            InitDataTable();
            // Planilla = ngPlanilla.ConsultarDetalleEmpleado(idPlanilla);

            foreach (DataRow row in dtPlanilla.ConsultarDetalleEmpleado(idPlanilla).Rows)
            {
                foreach (Empleado emp in ngEmpleado.ListarPorEstado(true))
                {
                    if (emp.Id == int.Parse(row["empleado_id"].ToString()))
                    {
                        RellenarDataTable(
                            emp.Id,
                            emp.Codigo,
                            emp.Nombres,
                            emp.Apellidos,
                            Convert.ToDecimal(row["salario_base"].ToString()),
                            Convert.ToDecimal(row["horas_extra"].ToString()),
                            Convert.ToDecimal(row["monto_INSS_L"].ToString()),
                            Convert.ToDecimal(row["monto_INSS_P"].ToString()),
                            Convert.ToDecimal(row["monto_IR"].ToString()),
                            Convert.ToDecimal(row["monto_ingresos"].ToString()),
                            Convert.ToDecimal(row["monto_deducciones"].ToString()),
                            Convert.ToDecimal(row["salario_devengado"].ToString()),
                            Convert.ToDecimal(row["porcentaje_IR_aplicado"].ToString())                           
                         );
                    }
                }

            }


            return Planilla;
        }

        public bool EditarDetalleEmpleado(int idPlanilla, DataTable planilla)
        {
            bool resp = false;

            foreach (DataRow row in Planilla.Rows)
            {               
                decimal salarioBase = Convert.ToDecimal(row["Salario_base"].ToString());
                decimal pagoInssL = Convert.ToDecimal(row["Pago_Inss_Laboral"].ToString());
                decimal pagoInssP = Convert.ToDecimal(row["Pago_Inss_Patronal"].ToString());
                decimal pagoIR = Convert.ToDecimal(row["Pago_IR"].ToString());
                decimal porcentajeAplicado = Convert.ToDecimal(row["Porcentaje_Aplicado"].ToString());
                decimal montoingreso = Convert.ToDecimal(row["Monto_de_Ingreso"].ToString());
                decimal montoDeduccion = Convert.ToDecimal(row["Monto_de_Deducciones"].ToString());
                decimal salarioDevengado = Convert.ToDecimal(row["Salario_Devengado"].ToString());
                decimal horasExtra = Convert.ToDecimal(row["Horas_Extra"].ToString());


               resp = dtPlanilla.EditarDetalleEmpleado(idPlanilla,salarioBase, pagoInssP, pagoInssL, pagoIR, porcentajeAplicado, montoingreso, montodeducciones, salarioDevengado, horasExtra);
            }
            return resp;

        }

        //
        private void GenerarPlanilla(int id)
        {
            Planilla = new DataTable();
            InitDataTable();
            RecuperarVariables();

            empleados = ngLocalidades.RecuperarEmpleadosPorLocalidad(id);
            puestos = RecuperarPuestos();
            adendums = RecuperarAdendum();

            // Empleado empleado = new Empleado();

            foreach (Empleado emp in empleados)
            {
                foreach (Puesto puesto in puestos)
                {
                    if (emp.PuestoId == puesto.Id)
                    {
                        if (adendums.Count > 0)
                        {
                            foreach (Adendum adendum in adendums)
                            {
                                if (emp.Id == adendum.EmpleadoId)
                                {
                                    CalcularMontoIngreso((puesto.SalarioBase + adendum.IncrementoSalarial));
                                    CalcularMontoDeduccion(emp.Id, (puesto.SalarioBase + adendum.IncrementoSalarial));///Calculo de Deducciones
                                    CalcularIR((puesto.SalarioBase + adendum.IncrementoSalarial)); ///Calculo de IR
                                    CalcularSalarioDevengado((puesto.SalarioBase + adendum.IncrementoSalarial));

                                    RellenarDataTable(emp.Id, emp.Codigo, emp.Nombres, emp.Apellidos, puesto.SalarioBase + adendum.IncrementoSalarial, horasExtra, montoinssLaboral, montoinssPatronal,
                                                      irMensual, montoingreso, montodeducciones, salariototal, Iraplicado);
                                }
                                else
                                {
                                    CalcularMontoIngreso(puesto.SalarioBase);
                                    CalcularMontoDeduccion(emp.Id, puesto.SalarioBase);///Calculo de Deducciones
                                    CalcularIR(puesto.SalarioBase); ///Calculo de IR
                                    CalcularSalarioDevengado(puesto.SalarioBase);

                                    RellenarDataTable(emp.Id, emp.Codigo, emp.Nombres, emp.Apellidos, puesto.SalarioBase, horasExtra, montoinssLaboral, montoinssPatronal,
                                                      irMensual, montoingreso, montodeducciones, salariototal, Iraplicado);
                                }

                            }
                        }
                        else
                        {
                            CalcularMontoIngreso(puesto.SalarioBase);
                            CalcularMontoDeduccion(emp.Id, puesto.SalarioBase);///Calculo de Deducciones
                            CalcularIR(puesto.SalarioBase); ///Calculo de IR
                            CalcularSalarioDevengado(puesto.SalarioBase);

                            RellenarDataTable(emp.Id, emp.Codigo, emp.Nombres, emp.Apellidos, puesto.SalarioBase, horasExtra, montoinssLaboral, montoinssPatronal,
                                              irMensual, montoingreso, montodeducciones, salariototal, Iraplicado);
                        }


                    }


                }
            }
        }

        private void RellenarDataTable(int idEmpleado, string codigoEmpleado, string nombresEmpleado, string apellidoEmpleado, decimal salarioBase, decimal horasExtra,
                                       decimal montoInssLaboral, decimal montoInssPatronal, decimal montoIR, decimal montoIngreso, decimal montoDeducciones,
                                       decimal salarioTotal, decimal IrAplicado)
        {

            Planilla.Rows.Add(idEmpleado, codigoEmpleado, nombresEmpleado, apellidoEmpleado, salarioBase, horasExtra, montoInssLaboral, montoInssPatronal,
                               montoIR, montoIngreso, montoDeducciones, salarioTotal, IrAplicado);


        }
        //Inicialización de DataTables
        private void InitDataTable()
        {
            Planilla.Columns.Add("Id_Empleado", typeof(Int32));
            Planilla.Columns.Add("Codigo_Empleado", typeof(string));
            Planilla.Columns.Add("Nombres_Empleado", typeof(string));
            Planilla.Columns.Add("Apellidos_Empleado", typeof(string));
            Planilla.Columns.Add("Salario_base", typeof(decimal));
            Planilla.Columns.Add("Horas_Extra", typeof(decimal));
            Planilla.Columns.Add("Pago_Inss_Laboral", typeof(decimal));
            Planilla.Columns.Add("Pago_Inss_Patronal", typeof(decimal));
            Planilla.Columns.Add("Pago_IR", typeof(decimal));
            Planilla.Columns.Add("Monto_de_Ingreso", typeof(decimal));
            Planilla.Columns.Add("Monto_de_Deducciones", typeof(decimal));
            Planilla.Columns.Add("Salario_Devengado", typeof(decimal));
            Planilla.Columns.Add("Porcentaje_Aplicado", typeof(decimal));
        }

        private void InitVistaPlanilla()
        {
            vistaPlanilla.Columns.Add("Id", typeof(Int32));
            vistaPlanilla.Columns.Add("Localidad", typeof(string));
            vistaPlanilla.Columns.Add("Fecha_de_Elaboración", typeof(DateTime));
            vistaPlanilla.Columns.Add("Aprobado", typeof(string));
            vistaPlanilla.Columns.Add("Fecha_de_Aprobación", typeof(DateTime));
        }



        // Recupera Datos necesarios para elaboración de planilla

        private void RecuperarVariables()
        {
            foreach (Variable var in ngVariables.Listar())
            {
                if (var.Id == 2)
                {
                    months = var.Valor;
                }
                else if (var.Id == 3)
                {
                    diasDelMes = var.Valor;
                }
            }
        }

        private List<IR> RecuperarIR()
        {

            return ngIR.Listar();
        }

        private List<INSS> RecuperarINSS()
        {
            return ngInss.Listar();

        }

        private List<Puesto> RecuperarPuestos()
        {
            return ngPuesto.ListarPuesto(true);
        }

     /*   private List<Empleado> RecuperarEmpleados(int idLocalidad)
        {
            List<Empleado> tempEmpleados = new List<Empleado>();
            empleados = ngEmpleado.ListarPorEstado(true);

            foreach (Empleado e in empleados)
            {
                if (idLocalidad == e.LocalidadId)
                {
                    tempEmpleados.Add(e);
                }
            }


            return tempEmpleados;
        }*/

        private List<Bono> RecuperarBonos()
        {
            return ngBonos.ListarPorEstado(true);
        }

        private List<Adelanto> RecuperarAdelantos()
        {
            return ngAdelantos.ListarPorEstado(true);
        }

        private List<Adendum> RecuperarAdendum()
        {
            return ngAdendums.ListarPorEstado(true);
        }

        //Cálculos necesarios para elaboración de planilla

        private void calcularINSS(decimal salarioB, decimal salarioProyectado)
        {
            inss = RecuperarINSS();
            foreach (INSS Inss in inss)
            {
                if (Inss.Patronal)
                {
                    //Calculo de INSS Patronal
                    montoinssPatronal = salarioB * (Inss.Porcentaje / 100);
                    montoinssPatronal = Decimal.Round(montoinssPatronal, 2);
                }
                else
                {
                    montoinssLaboral = salarioB * (Inss.Porcentaje / 100); // inss mensual por que se usa el salario base que gana el empleado
                    montoinssLaboral = Decimal.Round(montoinssLaboral, 2);

                    inssAnual = salarioProyectado * (Inss.Porcentaje / 100);//Inss Anual, por que se esta usando el salario proyectado por 12 meses
                }

            }
        }


        /*
         En el Calcular IR se proyecta el salario base del empleado a 12 meses, y se trabaja con la tabla del IR anual para una mayor precisión
        */

        private void CalcularIR(decimal salarioB)
        {

            tablaIR = RecuperarIR();


            decimal salarioProyectado = salarioB * months; //Proyección del salario

            calcularINSS(salarioB, salarioProyectado);


            decimal salarioConInss = salarioProyectado - inssAnual;



            foreach (IR ir in tablaIR) //Se recorre la lista para comparar el salario del empleado
            {
                if ((salarioConInss > ir.Desde) && (salarioConInss < ir.Hasta)) //Se compara si el salario esta entre los rangos de la tabla del IR
                {

                    decimal irAnual = (salarioConInss - ir.Exceso) * ir.PorcentajeAplicable;
                    irAnual = irAnual + ir.Base;
                    Iraplicado = ir.PorcentajeAplicable;
                    irMensual = irAnual / months; // Se divide el IR anual entre los meses para obtener el IR mensual
                    irMensual = Decimal.Round(irMensual, 2); // Se da una precisión de 2 digitos de decimales                                       

                }

            }

        }

        private void CalcularSalarioDevengado(decimal salarioB)
        {

            salariototal = salarioB + montoingreso; 
            salariototal = salariototal - montodeducciones;
            salariototal = salariototal - montoinssLaboral;
            salariototal = salariototal - irMensual;
            salariototal = Decimal.Round(salariototal, 2);
        }

        private void CalcularMontoDeduccion(int id, decimal salarioBase)
        {
            adelanto = RecuperarAdelantos();

            foreach (Adelanto adelantos in adelanto)
            {
                if (adelantos.EmpleadoId == id)
                {
                    montodeducciones = salarioBase - adelantos.Monto;
                    montodeducciones = Decimal.Round(montodeducciones, 2);
                }
            }
        }

        private void CalcularMontoIngreso(decimal salarioBase)
        {
            bonos = RecuperarBonos();
            foreach (Bono bono in bonos)
            {
                if (DateTime.Now == bono.fecha_Aplicación)
                {
                    montoingreso = salarioBase + bono.Monto;
                    montoingreso = Decimal.Round(montoingreso, 2);
                }

            }
        }

        public decimal CalcularHorasExtras(decimal horasExtra, decimal salarioBase)
        {
            montoingreso = montoingreso - montoHorasExtra;
            decimal salarioDiario = salarioBase / diasDelMes;
            decimal salarioPorHora = salarioDiario / 8;
            decimal valorHoraExtra = salarioPorHora * 2;
            montoHorasExtra = valorHoraExtra * horasExtra;

            return montoingreso = Decimal.Round(montoingreso + montoHorasExtra, 2);
        }



    }
}
