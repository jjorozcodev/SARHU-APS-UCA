using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.seguridad
{
    public partial class editar_rol : System.Web.UI.Page
    {
        private NG_Roles ngRoles = NG_Roles.Instanciar();
        protected Rol rol = null;
        private int idEditable = 0;

        protected string Mensaje = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            idEditable = int.Parse(Request.QueryString["id"]);
            rol = ngRoles.Consultar(idEditable);

            if (!Page.IsPostBack)
            {
                CargarInformacion();
            }
        }

        private void CargarInformacion()
        {
            if (rol != null)
            {
                rolNombre.Text = rol.Nombre;
                rolDescripcion.Value = rol.Descripcion;
            }
        }

        protected void Editar_click(object sender, EventArgs e)
        {
            this.rol = ObtenerDatosInterfaz();
            LimpiarFormulario();
            EjecutarNotificarUsuario(ngRoles.Editar(rol));
        }

        private Rol ObtenerDatosInterfaz()
        {
            Rol r = new Rol();
            r.Id = this.idEditable;
            r.Nombre = rolNombre.Text;
            r.Descripcion = rolDescripcion.Value;
            r.Estado = true;
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