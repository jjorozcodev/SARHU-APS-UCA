﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Negocio;
using Entidades;
using System.Web.UI.WebControls;
using System.Data;

namespace SARHU.sarhu.planilla
{
    public partial class procesar : System.Web.UI.Page
    {
        private NG_Variables ngVariables = NG_Variables.Instanciar();
        private NG_Programas ngProgramas = NG_Programas.Instanciar();
        private NG_Localidades ngLocalidades = NG_Localidades.Instanciar();
        private NG_Empleados ngEmpleado = NG_Empleados.Instanciar();
        private NG_Planilla ngPlanilla = NG_Planilla.Instanciar();
        private NG_INSS ngInss = NG_INSS.Instanciar();
        private List<Localidad> localidad = new List<Localidad>();
        private static DataTable planilla = new DataTable();
        private static decimal monto = 0m;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
                GenerarPlanilla();
            }
        }

        protected void CargarDatos()
        {
            foreach (Variable var in ngVariables.Listar())
            {
                if (var.Id== 9)
                {
                    inatec.Text = var.Valor.ToString();
                }
                else if (var.Id == 10)
                {
                    techoSalarial.Text = var.Valor.ToString();
                }
            }

            ///DropdownList
            ddlProgramas.DataSource = ngProgramas.ListarPorEstado(true);
            ddlProgramas.DataTextField = "Nombre";
            ddlProgramas.DataValueField = "Id";
            ddlProgramas.DataBind();
            ddlProgramas.Items.Insert(0, new ListItem("Seleccione...", "0"));

            localidad = ngLocalidades.ListarPorEstado(true);
            ddlLocalidad.DataSource = localidad;
            ddlLocalidad.DataTextField = "Alias";
            ddlLocalidad.DataValueField = "Id";
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("Seleccione...", "0"));

            ///INSS
            foreach (INSS i in ngInss.Listar())
            {
                if (i.Patronal)
                {
                    inssPatronal.Text = i.Porcentaje.ToString();
                }
                else
                {
                    inssLaboral.Text = i.Porcentaje.ToString();
                }
            }

            foreach (Localidad local in localidad)
            {
                foreach (Empleado emp in ngEmpleado.ListarPorEstado(true))
                {
                    if (local.DirectorId == emp.Id)
                    {
                        director.Text = emp.Nombres;
                    }
                }
               
            }

        }

        protected void GenerarPlanilla()
        {
            
            planilla = ngPlanilla.ObtenerPlanilla();
            GridView1.DataSource = planilla;
            GridView1.DataBind();
        }
        
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = planilla;
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex]; //Find the row that was clicked for updating.         

            TextBox horas = (TextBox)row.Cells[5].FindControl("horas");
            decimal salarioB = Convert.ToDecimal(row.Cells[4].Text);
            decimal salarioDevengado = Convert.ToDecimal(row.Cells[11].Text);
            salarioDevengado = salarioDevengado - monto;
           // decimal montoIngreso = Convert.ToDecimal(row.Cells[9].Text);
            planilla.Rows[e.RowIndex].BeginEdit();
            if(horas.Text != string.Empty)
            {
                monto = ngPlanilla.CalcularHorasExtras(int.Parse(horas.Text), salarioB);
                planilla.Rows[e.RowIndex]["Horas_Extra"] = horas.Text;
                planilla.Rows[e.RowIndex]["Monto_de_Ingreso"] = monto;
                planilla.Rows[e.RowIndex]["Salario_Devengado"] = salarioDevengado + monto;

            }
           
           

            planilla.Rows[e.RowIndex].EndEdit();
            planilla.AcceptChanges();

            GridView1.EditIndex = -1;
            GridView1.DataSource = planilla;
            GridView1.DataBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataSource = planilla;
            GridView1.DataBind();
        }
    }
}