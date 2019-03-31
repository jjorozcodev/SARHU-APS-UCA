using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.personal
{
    public partial class agregar_area : Page
    {
        private NG_Areas ngAreas = NG_Areas.Instanciar();
        protected Area area = null;

        protected string Mensaje = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            this.area = ObtenerDatosInterfaz();
            LimpiarFormulario();
            EjecutarNotificarUsuario(ngAreas.Agregar(this.area));
        }

        private Area ObtenerDatosInterfaz()
        {
            Area a = new Area();
            a.Nombre = areaNombre.Text;
            a.Descripcion = areaDescripcion.Value;
            return a;
        }

        private void LimpiarFormulario()
        {
            areaNombre.Text = string.Empty;
            areaDescripcion.Value = string.Empty;
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