using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.seguridad
{
    public partial class agregar_rol : Page
    {
        private NG_Roles ngRoles = NG_Roles.Instanciar();
        protected Rol rol = null;

        protected string Mensaje = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            this.rol = ObtenerDatosInterfaz();
            LimpiarFormulario();
            EjecutarNotificarUsuario(ngRoles.Agregar(this.rol));
        }

        private Rol ObtenerDatosInterfaz()
        {
            Rol r = new Rol();
            r.Nombre = rolNombre.Text;
            r.Descripcion = rolDescripcion.Value;
            return r;
        }

        private void LimpiarFormulario()
        {
            rolNombre.Text = string.Empty;
            rolDescripcion.Value = string.Empty;
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