using Entidades;
using Negocio;
using System;

namespace SARHU.sarhu
{
    public partial class principal : System.Web.UI.Page
    {
        private NG_Organizacion ngOrg = NG_Organizacion.Instanciar();
        protected Organizacion org = null;

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
            org = ngOrg.Obtener();

            orgNombre.Text = org.Nombre;
            textareaV.Value = org.Vision;
            textareaM.Value = org.Mision;
            textareaD.Value = org.Descripcion;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Organizacion o = ObtenerDatosInterfaz();

            EjecutarNotificarUsuario(ngOrg.Editar(o));

            CargarInformacion();
        }

        private Organizacion ObtenerDatosInterfaz()
        {
            Organizacion o = new Organizacion();
            o.Nombre = orgNombre.Text;
            o.Mision = textareaM.Value;
            o.Vision = textareaV.Value;
            o.Descripcion = textareaD.Value;
            return o;
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