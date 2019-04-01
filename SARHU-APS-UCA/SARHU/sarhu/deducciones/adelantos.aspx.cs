using System;
using Negocio;
using Entidades;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace SARHU.sarhu.deducciones
{
    public partial class adelantos : Page
    {
        private NG_Adelantos ngAdelantos = NG_Adelantos.Instanciar();
        protected Adelanto adelanto = null;

        protected string Mensaje = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarInformacion();
            }

        }
        private void CargarInformacion()
        {
            rptTable.DataSource = NG_Adelantos.Instanciar().VisualizarAdelantos(); ;
            rptTable.DataBind();
        }

        protected void Borrar_Click(object sender, CommandEventArgs e)
        {
            idSeleccionado.Value = e.CommandArgument.ToString();
            this.adelanto = ngAdelantos.Consultar(int.Parse(idSeleccionado.Value));
            Mensaje = "¿Está seguro que desea borrar el registro " + this.adelanto.Id + "?";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "PopupConfirmacion();", true);
        }

        protected void Confirmar_Click(object sender, EventArgs e)
        {
            EjecutarNotificarUsuario(ngAdelantos.Borrar(int.Parse(idSeleccionado.Value)));
            CargarInformacion();
        }

        protected void VerDetalle_Click(object sender, CommandEventArgs e)
        {
            LinkButton button = (sender as LinkButton);
            int index = int.Parse(button.CommandArgument);
            ConsultData(index);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "ShowDetail();", true);
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

        private void CargarEmpleados()
        {
            Empleado.DataSource = NG_Empleados.Instanciar().Listar();
            Empleado.DataTextField = "Nombre";
            Empleado.DataValueField = "Id";
            Empleado.DataBind();
            Empleado.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }

        private void ConsultData(int ID)
        {
            adelanto = NG_Adelantos.Instanciar().Consultar(ID);

            Empleado.ClearSelection();

            //IdAdelanto.Value = adelanto.Id.ToString();
            idFechaEntrega.Value = string.Format("{0:yyyy-MM-dd}", adelanto.FechaEntrega);
            idFechaDeduccion.Value = string.Format("{0:yyyy-MM-dd}", adelanto.FechaDeduccion);
            Monto.Text = adelanto.Monto.ToString();

            //En busca el valor del Id en el dropdownlist para dejarlo ubicado al momento de cargar la pagina
            Empleado.Items.FindByValue(adelanto.EmpleadoId.ToString()).Selected = true;

            textarea.Value = adelanto.Descripcion;
        }

    }
}