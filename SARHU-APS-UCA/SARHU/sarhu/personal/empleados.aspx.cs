using System;
using Negocio;
using Entidades;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace SARHU.sarhu.personal
{
    public partial class empleados : Page
    {
        private NG_Empleados ngEmpleados = NG_Empleados.Instanciar();
        private NG_Programas ngProgramas = NG_Programas.Instanciar();

        protected Empleado empleado = null;

        protected string Mensaje = null;
        protected string NombreCompleto = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarInformacion();
            }
        }

        private void CargarInformacion()
        {
            rptEmpleados.DataSource = ngEmpleados.ListarEmpleadosProgramas();
            rptEmpleados.DataBind();
        }

        protected void Borrar_Click(object sender, CommandEventArgs e)
        {
            idSeleccionado.Value = e.CommandArgument.ToString();
            this.empleado = ngEmpleados.Consultar(int.Parse(idSeleccionado.Value));
            this.NombreCompleto = this.empleado.Nombres + " " + this.empleado.Apellidos;
            Mensaje = "¿Está seguro que desea borrar el registro " + this.NombreCompleto + "?";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "PopupConfirmacion();", true);
        }

        protected void Confirmar_Click(object sender, EventArgs e)
        {
            EjecutarNotificarUsuario(ngEmpleados.Borrar(int.Parse(idSeleccionado.Value)));
            CargarInformacion();
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
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "PopupNotificacion();", true);
        }
    }
}