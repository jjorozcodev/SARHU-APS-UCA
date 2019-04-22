﻿using System;
using Entidades;
using Negocio;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace SARHU.sarhu.catalogos
{
    public partial class agregar_localidad : System.Web.UI.Page
    {
        protected string Mensaje { get; set; }
        private static List<Empleado> TableEmpleado = new List<Empleado>();
        private NG_Empleados ngEmpleado = NG_Empleados.Instanciar();
        private NG_Municipios ngMunicipios = NG_Municipios.Instanciar();
        private static int idDirector;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadContent();
            }

        }

        private void LoadContent()
        {
            ///Rellenar Dropdown De Programas
            ddlProgramas.DataSource = NG_Programas.Instanciar().ListarPorEstado(true);
            ddlProgramas.DataTextField = "Nombre";
            ddlProgramas.DataValueField = "Id";
            ddlProgramas.DataBind();
            ddlProgramas.Items.Insert(0, new ListItem("Seleccione...", "0"));

            ///Rellenar Dropdown de Departamentos
            ddlDepartamentos.DataSource = NG_Departamentos.Instanciar().Listar();
            ddlDepartamentos.DataTextField = "Nombre";
            ddlDepartamentos.DataValueField = "Id";
            ddlDepartamentos.DataBind();
            ddlDepartamentos.Items.Insert(0, new ListItem("Seleccione...", "0"));

            ///Se Deshabilita el Dropdown
            setDefault();

            ///Carga del View Para los empleados
            EmpleadosView.DataSource = ngEmpleado.ListarPorEstado(true);
            EmpleadosView.DataBind();
        }

        private void setDefault()
        {
            ddlMunicipios.Enabled = false;
            ddlMunicipios.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }

        private Localidad ObtenerDatosInterfaz(bool f = false)
        {
            Localidad localidad = new Localidad();
            localidad.ProgramaId = int.Parse(ddlProgramas.SelectedItem.Value);
            localidad.MunicipioId = int.Parse(ddlMunicipios.SelectedItem.Value);
          
            localidad.Telefono = Telefono.Text;
            localidad.Alias = Alias.Text;
            localidad.DirectorId = idDirector;
            localidad.Direccion = textarea.Value;
            
            Alias.Text = "";
            ddlProgramas.SelectedIndex = 0;
            setDefault();
            ddlMunicipios.SelectedIndex = 0;
            ddlDepartamentos.SelectedIndex = 0;
            Director.Text = "";
            Telefono.Text = "";
            textarea.Value = "";

            return localidad;
        }

        protected void Departamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(ddlDepartamentos.SelectedItem.Value);
            ddlMunicipios.Items.Clear();
            setDefault();
            if (id > 0)
            {
                ddlMunicipios.Enabled = true;
                ddlMunicipios.DataSource = ngMunicipios.ObtenerMunicipios(id);
                ddlMunicipios.DataTextField = "Nombre";
                ddlMunicipios.DataValueField = "Id";
                ddlMunicipios.DataBind();
            }
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            Localidad localidades = ObtenerDatosInterfaz();

            if (NG_Localidades.Instanciar().Agregar(localidades))
            {
                Mensaje = "¡La operación fue completada con éxito!";
                panelNotificacion.Visible = true;
            }
            else
            {
                Mensaje = "¡Ocurrió un error al intentar realizar la operación!";
                panelNotificacion.CssClass = "alert alert-danger alert-dismissable";
                panelNotificacion.Visible = true;
            }
        }

        
        protected void EmpleadosView_SelectedIndexChanged1(object sender, EventArgs e)
        {
            GridViewRow gr = EmpleadosView.SelectedRow;
             idDirector = int.Parse(gr.Cells[1].Text);
            Director.Text = gr.Cells[2].Text;
        }
    }
}