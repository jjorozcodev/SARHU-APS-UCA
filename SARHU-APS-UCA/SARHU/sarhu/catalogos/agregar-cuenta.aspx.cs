using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.catalogos
{
    public partial class agregar_cuenta : Page
    {
        private NG_Cuentas ngCuentas = NG_Cuentas.Instanciar();
        protected Cuenta cuenta = null;

        protected string Mensaje = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            this.cuenta = ObtenerDatosInterfaz();
            LimpiarFormulario();
            EjecutarNotificarUsuario(ngCuentas.Agregar(this.cuenta));
        }

        private Cuenta ObtenerDatosInterfaz()
        {
            Cuenta c = new Cuenta();
            c.CodigoContable = codigoContable.Text;
            c.CuentaSalario = cuentaSalario.Text;
            c.CuentaImpuestos = cuentaImpuestos.Text;
            c.CuentaSeguros = cuentaSeguro.Text;
            c.Planilla = cuentaPlanilla.Checked;
            c.Descripcion = cuentaDescripcion.Value;
            return c;
        }

        private void LimpiarFormulario()
        {
            codigoContable.Text = string.Empty;
            cuentaSalario.Text = string.Empty;
            cuentaImpuestos.Text = string.Empty;
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