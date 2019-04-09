using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.catalogos
{
    public partial class editar_cuenta : Page
    {
        private NG_Cuentas ngCuentas = NG_Cuentas.Instanciar();
        protected Cuenta cuenta = null;
        private int idEditable = 0;

        protected string Mensaje = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            idEditable = int.Parse(Request.QueryString["id"]);
            cuenta = ngCuentas.Consultar(idEditable);

            if (!Page.IsPostBack)
            {
                CargarInformacion();
            }
        }

        private void CargarInformacion()
        {
            if (cuenta != null)
            {
                codigoContable.Text = cuenta.CodigoContable;
                cuentaSalario.Text = cuenta.CuentaSalario;
                cuentaImpuesto.Text = cuenta.CuentaImpuestos;
                cuentaSeguro.Text = cuenta.CuentaSeguros;
                cuentaPlanilla.Checked = cuenta.Planilla;
                cuentaDescripcion.Value = cuenta.Descripcion;
            }
        }

        protected void Editar_click(object sender, EventArgs e)
        {
            this.cuenta = ObtenerDatosInterfaz();
            LimpiarFormulario();
            EjecutarNotificarUsuario(ngCuentas.Editar(cuenta));
        }

        private Cuenta ObtenerDatosInterfaz()
        {
            Cuenta c = new Cuenta();
            c.Id = this.idEditable;
            c.CodigoContable = codigoContable.Text;
            c.CuentaSalario = cuentaSalario.Text;
            c.CuentaImpuestos = cuentaImpuesto.Text;
            c.Planilla = cuentaPlanilla.Checked;
            c.CuentaSeguros = cuentaSeguro.Text;
            c.Descripcion = cuentaDescripcion.Value;
            c.Estado = true;
            return c;
        }

        private void LimpiarFormulario()
        {
            codigoContable.Text = string.Empty;
            cuentaSalario.Text = string.Empty;
            cuentaImpuesto.Text = string.Empty;
            cuentaSeguro.Text = string.Empty;
            cuentaPlanilla.Checked = false;
            cuentaDescripcion.Value = string.Empty;
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