using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Entidades;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NG_Planilla
    {

        private static NG_Planilla ngPlanilla = null;


        //Variables que se usan
        ///Llamados a la capa de Negocio
        private NG_IR ngIR = NG_IR.Instanciar();
        private NG_Empleados ngEmpleado = NG_Empleados.Instanciar();
        private NG_Puestos ngPuesto = NG_Puestos.Instanciar();
        private NG_INSS ngInss = NG_INSS.Instanciar();
        private NG_Adelantos ngAdelantos = NG_Adelantos.Instanciar();
        private NG_Bonos ngBonos = NG_Bonos.Instanciar();
        private NG_Adendums ngAdendums = NG_Adendums.Instanciar();
        private NG_Variables ngVariables = NG_Variables.Instanciar();
        /// Lista de Datos
        private List<IR> tablaIR = new List<IR>();
        private List<Empleado> empleados = new List<Empleado>();
        private List<Puesto> puestos = new List<Puesto>();
        private DataTable Planilla;
        private List<INSS> inss = new List<INSS>();
        private List<Adelanto> adelanto = new List<Adelanto>();
        private List<Bono> bonos = new List<Bono>();
        private List<Adendum> adendums = new List<Adendum>();
        ///Variables numericas
        private decimal months = 0m;
        private decimal diasDelMes = 0m;
        private decimal inssAnual = 0m;
        decimal montoHorasExtra = 0m;

        ///Variables para DataTable
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
        }


        public static NG_Planilla Instanciar()
        {
            if (ngPlanilla == null)
            {
                ngPlanilla = new NG_Planilla();
            }
            return ngPlanilla;
        }

        public DataTable ObtenerPlanilla()
        {
            GenerarPlanilla();
            return Planilla;
        }

        private void GenerarPlanilla()
        {
            Planilla = new DataTable();
            InitDataTable();
            RecuperarVariables();
            
            empleados = RecuperarEmpleados();
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
                                                      irMensual, montoingreso, montodeducciones, salariototal);
                                }
                                else
                                {
                                    CalcularMontoIngreso(puesto.SalarioBase);
                                    CalcularMontoDeduccion(emp.Id, puesto.SalarioBase);///Calculo de Deducciones
                                    CalcularIR(puesto.SalarioBase); ///Calculo de IR
                                    CalcularSalarioDevengado(puesto.SalarioBase);

                                    RellenarDataTable(emp.Id, emp.Codigo, emp.Nombres, emp.Apellidos, puesto.SalarioBase, horasExtra, montoinssLaboral, montoinssPatronal,
                                                      irMensual, montoingreso, montodeducciones, salariototal);
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
                                              irMensual, montoingreso, montodeducciones, salariototal);
                        }


                    }


                }
            }
        }

        private void RellenarDataTable(int idEmpleado, string codigoEmpleado, string nombresEmpleado, string apellidoEmpleado, decimal salarioBase, decimal horasExtra,
                                       decimal montoInssLaboral, decimal montoInssPatronal, decimal montoIR, decimal montoIngreso, decimal montoDeducciones,
                                       decimal salarioTotal)
        {

            Planilla.Rows.Add(idEmpleado, codigoEmpleado, nombresEmpleado, apellidoEmpleado, salarioBase, horasExtra, montoInssLaboral, montoInssPatronal,
                               montoIR, montoIngreso, montoDeducciones, salarioTotal);


        }

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
        }

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

        private List<Empleado> RecuperarEmpleados()
        {

            return ngEmpleado.ListarPorEstado(true);
        }

        private List<Bono> RecuperarBonos()
        {
            return ngBonos.ListarPorEstado(true);
        }

        /*
            private List<Empleado> RecuperarEmpleados(int idLocalidad)
        {
            List<Empleado> tempEmpleados = new List<Empleado>();

            foreach (Empleado e in  ngEmpleado.ListarPorEstado(true))
            {
                if(idLocalidad == e.localidad){
                
                }
            }

            return;
        }
         */

        private List<Adelanto> RecuperarAdelantos()
        {
            return ngAdelantos.ListarPorEstado(true);
        }

        private List<Adendum> RecuperarAdendum()
        {
            return ngAdendums.ListarPorEstado(true);
        }

        private void calcularINSS(decimal salarioB, decimal salarioProyectado)
        {
            inss = RecuperarINSS();
            foreach (INSS Inss in inss)
            {
                if (Inss.Patronal)
                {
                    montoinssPatronal = salarioB * (Inss.Porcentaje / 100);
                    montoinssPatronal = Decimal.Round(montoinssPatronal, 2);
                }
                else
                {
                    montoinssLaboral = salarioB * (Inss.Porcentaje / 100); //Este es el inss mensual por que se usa el salario base que gana el empleado
                    montoinssLaboral = Decimal.Round(montoinssLaboral, 2);

                    inssAnual = salarioProyectado * (Inss.Porcentaje / 100);//Inss Anual, por que se esta usando el salario proyectado por 12 meses
                }

            }
        }

        private void CalcularIR(decimal salarioB)
        {

            tablaIR = RecuperarIR();


            decimal salarioProyectado = salarioB * months;

            calcularINSS(salarioB, salarioProyectado);


            decimal salarioConInss = salarioProyectado - inssAnual;



            foreach (IR ir in tablaIR)///Con un foreach se recorre el datatable
            {
                if ((salarioConInss > ir.Desde) && (salarioConInss < ir.Hasta))
                {

                    decimal irAnual = (salarioConInss - ir.Exceso) * ir.PorcentajeAplicable;
                    irAnual = irAnual + ir.Base;

                    irMensual = irAnual / months;
                    irMensual = Decimal.Round(irMensual, 2);

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
