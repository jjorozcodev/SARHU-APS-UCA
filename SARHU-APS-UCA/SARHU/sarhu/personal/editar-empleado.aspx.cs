using System;
using Entidades;
using Negocio;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SARHU.sarhu.personal
{
    public partial class editar_empleado : Page
    {
        private NG_Empleados ngEmpleados = NG_Empleados.Instanciar();
        protected Empleado empleado = null;
        private int idEditable = 0;

        protected string Mensaje = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            idEditable = int.Parse(Request.QueryString["id"]);
            empleado = ngEmpleados.Consultar(idEditable);

            if (!Page.IsPostBack)
            {
                CargarCatalogos();
                CargarInformacion();
            }
        }

        private void CargarCatalogos()
        {
            ///Rellenar Dropdown De Estados Civiles
            ddlEstadosCiviles.DataSource = NG_EstadosCiviles.Instanciar().Listar();
            ddlEstadosCiviles.DataTextField = "Nombre";
            ddlEstadosCiviles.DataValueField = "Id";
            ddlEstadosCiviles.DataBind();
            ddlEstadosCiviles.Items.Insert(0, new ListItem("Seleccione...", "0"));

            ///Rellenar Dropdown de Niveles Académicos
            ddlNivelesAcademicos.DataSource = NG_NivelesAcademicos.Instanciar().Listar();
            ddlNivelesAcademicos.DataTextField = "Nombre";
            ddlNivelesAcademicos.DataValueField = "Id";
            ddlNivelesAcademicos.DataBind();
            ddlNivelesAcademicos.Items.Insert(0, new ListItem("Seleccione...", "0"));

            ///Rellenar Dropdown de Puestos
            ddlPuestos.DataSource = NG_Puestos.Instanciar().Listar();
            ddlPuestos.DataTextField = "Nombre";
            ddlPuestos.DataValueField = "Id";
            ddlPuestos.DataBind();
            ddlPuestos.Items.Insert(0, new ListItem("Seleccione...", "0"));

            ///Rellenar Dropdown de Localidades
            ddlLocalidades.DataSource = NG_Localidades.Instanciar().Listar();
            ddlLocalidades.DataTextField = "Alias";
            ddlLocalidades.DataValueField = "Id";
            ddlLocalidades.DataBind();
            ddlLocalidades.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }

        private void CargarInformacion()
        {

            if (empleado != null)
            {
                EmpNombres.Text = empleado.Nombres;
                EmpApellidos.Text = empleado.Apellidos;
                if(empleado.Sexo)
                {
                    rdM.Checked = true;
                }
                else
                {
                    rdF.Checked = true;
                }
                EmpCedula.Text = empleado.Cedula;
                EmpFechaNac.Text = empleado.FechaNacimiento.ToString("yyyy-MM-dd");
                EmpTelefono.Text = empleado.Telefono;
                EmpDireccion.Value = empleado.Direccion;
                ddlEstadosCiviles.SelectedIndex = -1;
                ddlEstadosCiviles.Items.FindByValue(empleado.EstadoCivilId.ToString()).Selected = true;
                ddlNivelesAcademicos.SelectedIndex = -1;
                ddlNivelesAcademicos.Items.FindByValue(empleado.NivelAcademicoId.ToString()).Selected = true;
                EmpSeguroSocial.Text = empleado.SeguroSocial;
                EmpFechaIngreso.Text = empleado.FechaIngreso.ToString("yyyy-MM-dd");
                ddlLocalidades.SelectedIndex = -1;
                ddlLocalidades.Items.FindByValue(empleado.LocalidadId.ToString()).Selected = true;
                ddlPuestos.SelectedIndex = -1;
                ddlPuestos.Items.FindByValue(empleado.PuestoId.ToString()).Selected = true;
                rdBancoSi.Checked = empleado.Banco;
                EmpCuentaBancaria.Text = empleado.CuentaBanco;
                EmpObservaciones.Value = empleado.Observaciones;
                EmpCodigo.Text = empleado.Codigo;
            }
        }

        protected void Editar_click(object sender, EventArgs e)
        {
            this.empleado = ObtenerDatosInterfaz();
            LimpiarFormulario();
            EjecutarNotificarUsuario(ngEmpleados.Editar(empleado));
        }

        protected void Puestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(ddlPuestos.SelectedItem.Value);

            if (id > 0)
            {
                Puesto p = NG_Puestos.Instanciar().Consultar(id);
                SalarioEmpleado.Value = p.SalarioBase.ToString("0.##");
            }
            else
            {
                SalarioEmpleado.Value = string.Empty;
            }
        }

        protected void EmpFechaIngreso_TextChanged(object sender, EventArgs e)
        {
            DateTime fIngreso = DateTime.Parse(EmpFechaIngreso.Text);
            int antig = DateTime.Today.AddTicks(-fIngreso.Ticks).Year - 1;
            antiguedad.Value = antig.ToString();
        }

        protected void EmpFechaNac_TextChanged(object sender, EventArgs e)
        {
            DateTime fIngreso = DateTime.Parse(EmpFechaNac.Text);
            int edad = DateTime.Today.AddTicks(-fIngreso.Ticks).Year - 1;
            EmpEdad.Text = edad.ToString();
        }

        private Empleado ObtenerDatosInterfaz()
        {
            Empleado e = new Empleado();

            e.Id = this.idEditable;
            //e.Codigo = EmpCodigo.Text;
            e.Nombres = EmpNombres.Text;
            e.Apellidos = EmpApellidos.Text;
            e.Sexo = rdM.Checked;
            e.Cedula = EmpCedula.Text;
            e.FechaNacimiento = DateTime.Parse(EmpFechaNac.Text);
            e.Telefono = EmpTelefono.Text;
            e.Direccion = EmpDireccion.Value;
            e.EstadoCivilId = int.Parse(ddlEstadosCiviles.SelectedItem.Value);
            e.NivelAcademicoId = int.Parse(ddlNivelesAcademicos.SelectedItem.Value);
            e.SeguroSocial = EmpSeguroSocial.Text;
            e.FechaIngreso = DateTime.Parse(EmpFechaIngreso.Text);
            e.LocalidadId = int.Parse(ddlLocalidades.SelectedItem.Value);
            e.PuestoId = int.Parse(ddlPuestos.SelectedItem.Value);
            e.Banco = rdBancoSi.Checked;
            e.CuentaBanco = EmpCuentaBancaria.Text;
            e.Observaciones = EmpObservaciones.Value;

            e.Codigo = ngEmpleados.GenerarCodigoEmpleado(e.FechaIngreso, e.Nombres, e.Apellidos, e.Cedula);

            return e;
        }

        private void LimpiarFormulario()
        {
            EmpCodigo.Text = string.Empty;
            EmpNombres.Text = string.Empty;
            EmpApellidos.Text = string.Empty;
            rdM.Checked = true;
            EmpCedula.Text = string.Empty;
            EmpFechaNac.Text = string.Empty;
            EmpTelefono.Text = string.Empty;
            EmpDireccion.Value = string.Empty;
            ddlEstadosCiviles.SelectedIndex = 0;
            ddlNivelesAcademicos.SelectedIndex = 0;
            ddlLocalidades.SelectedIndex = 0;
            ddlPuestos.SelectedIndex = 0;
            EmpSeguroSocial.Text = string.Empty;
            EmpFechaIngreso.Text = string.Empty;
            rdBancoSi.Checked = false;
            EmpCuentaBancaria.Text = string.Empty;
            EmpObservaciones.Value = string.Empty;
        }

        private void EjecutarNotificarUsuario(bool correcto)
        {
            if (correcto)
            {
                Mensaje = "¡La operación fue completada con éxito!";
            }
            else
            {
                Mensaje = "¡Ocurrió un error al intentar realizar la operación!";
                panelNotificacion.CssClass = "alert alert-danger alert-dismissable";
            }

            panelNotificacion.Visible = true;
        }
    }
}