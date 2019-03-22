using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.personal
{
    public partial class agregar_area : System.Web.UI.Page
    {
        private NG_Areas ngArea = NG_Areas.Instanciar();
        protected Area area = null;

        protected string Mensaje = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            Area a = ObtenerDatosInterfaz();
            EjecutarNotificarUsuario(ngArea.Agregar(a));
        }

        private Area ObtenerDatosInterfaz()
        {
            Area a = new Area();
            a.Nombre = areaNombre.Text;
            a.Descripcion = areaDescripcion.Value;
            return a;
        }

        private void EjecutarNotificarUsuario(bool correcto)
        {
            if (correcto)
            {
                Mensaje = "¡Se actualizó correctamente la información organizacional!";
            }
            else
            {
                Mensaje = "¡Ocurrió un error al intentar actualizar la información!";
                panelNotificacion.CssClass = "alert alert-danger alert-dismissable";
            }

            panelNotificacion.Visible = true;
        }
    }
}