using System;
using Entidades;
using Negocio;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SARHU.sarhu.personal
{
    public partial class agregar_empleado : System.Web.UI.Page
    {
        private NG_Empleados ngEmpleados = NG_Empleados.Instanciar();
        protected Empleado empleado = null;

        protected string Mensaje = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCatalogos();
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

        protected void Guardar_Click(object sender, EventArgs e)
        {
            this.empleado = ObtenerDatosInterfaz();
            LimpiarFormulario();
            EjecutarNotificarUsuario(ngEmpleados.Agregar(this.empleado));
        }

        private Empleado ObtenerDatosInterfaz()
        {
            Empleado e = new Empleado();

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