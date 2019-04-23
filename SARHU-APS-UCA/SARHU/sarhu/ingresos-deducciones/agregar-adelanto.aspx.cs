using System;
using Entidades;
using Negocio;
using System.Web.UI.WebControls;


namespace SARHU.sarhu.ingresos
{
    public partial class agregar_adelanto : System.Web.UI.Page
    {
        protected string Mensaje { get; set; }

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
            ddlEmpleados.DataSource = NG_Empleados.Instanciar().ListarPorEstado(true);
            ddlEmpleados.DataTextField = "Nombres";
            ddlEmpleados.DataValueField = "Id";
            ddlEmpleados.DataBind();
            ddlEmpleados.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }

        private Adelanto ObtenerDatosInterfaz(bool f = false)
        {
            Adelanto adelanto = new Adelanto();
            adelanto.EmpleadoId = int.Parse(ddlEmpleados.SelectedItem.Value);
            //pendiente fecha entrega & fecha deduccion
            adelanto.FechaEntrega = DateTime.Parse(idFechaEntrega.Value);
            adelanto.FechaDeduccion = DateTime.Parse(idFechaDeduccion.Value);
            adelanto.Monto = decimal.Parse(Monto.Text);
            adelanto.Descripcion = textarea.Value;

            Monto.Text = "";
            ddlEmpleados.SelectedIndex = 0; ;
            textarea.Value = "";

            return adelanto;
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            Adelanto adelantos = ObtenerDatosInterfaz();

            if (NG_Adelantos.Instanciar().Agregar(adelantos))
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
    }
}