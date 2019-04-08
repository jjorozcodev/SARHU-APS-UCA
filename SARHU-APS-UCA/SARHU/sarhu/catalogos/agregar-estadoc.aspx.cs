using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.catalogos
{
    public partial class agregar_estadoc : Page
    {
        private NG_EstadosCiviles ngEstadosCiviles = NG_EstadosCiviles.Instanciar();
        protected EstadoCivil estadoCivil = null;

        protected string Mensaje = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            this.estadoCivil = ObtenerDatosInterfaz();
            LimpiarFormulario();
            EjecutarNotificarUsuario(ngEstadosCiviles.Agregar(this.estadoCivil));
        }

        private EstadoCivil ObtenerDatosInterfaz()
        {
            EstadoCivil ec = new EstadoCivil();
            ec.Nombre = estadocNombre.Text;
            return ec;
        }

        private void LimpiarFormulario()
        {
            estadocNombre.Text = string.Empty;
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