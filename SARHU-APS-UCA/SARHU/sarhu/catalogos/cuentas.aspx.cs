using System;
using Negocio;
using Entidades;
using System.Web.UI.WebControls;
using System.Web.UI;


namespace SARHU.sarhu.catalogos
{
    public partial class cuentas : Page
    {
        private NG_Cuentas ngCuentas = NG_Cuentas.Instanciar();
        protected Cuenta cuenta = null;

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
            rptTable.DataSource = ngCuentas.ListarPorEstado(true);
            rptTable.DataBind();
        }



        public void ConsultData(int id)
        {

            Cuenta cuenta = ngCuentas.Consultar(id);

            codigoContable.Text = cuenta.CodigoContable;
            cuentaSalario.Text = cuenta.CuentaSalario;
            cuentaImpuesto.Text = cuenta.CuentaImpuestos;
            cuentaSeguro.Text = cuenta.CuentaSeguros;
            cuentaPlanilla.Checked = cuenta.Planilla;
            cuentaDescripcion.Value = cuenta.Descripcion;

        }


        protected void Borrar_Click(object sender, CommandEventArgs e)
        {
            idSeleccionado.Value = e.CommandArgument.ToString();
            this.cuenta = ngCuentas.Consultar(int.Parse(idSeleccionado.Value));
            Mensaje = "¿Está seguro que desea borrar el registro " + this.cuenta.CodigoContable + "?";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "PopupConfirmacion();", true);
        }

        protected void Confirmar_Click(object sender, EventArgs e)
        {
            EjecutarNotificarUsuario(ngCuentas.Borrar(int.Parse(idSeleccionado.Value)));
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

        protected void Detalle_Click(object sender, EventArgs e)
        {
            LinkButton b = (LinkButton)sender;
            string arguments = b.CommandArgument;

            ConsultData(int.Parse(arguments));

            ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "ShowDetail();", true);
        }
    }
}