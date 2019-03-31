using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.personal
{
    public partial class editar_area : Page
    {
        private NG_Areas ngAreas = NG_Areas.Instanciar();
        protected Area area = null;
        private int idEditable = 0;

        protected string Mensaje = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            idEditable = int.Parse(Request.QueryString["id"]);
            area = ngAreas.Consultar(idEditable);

            if (!Page.IsPostBack) {
                CargarInformacion();
            }
        }
        
        private void CargarInformacion()
        {
            if (area != null)
            {
                areaNombre.Text = area.Nombre;
                areaDescripcion.Value = area.Descripcion;
            }
        }

        protected void Editar_click(object sender, EventArgs e)
        {
            this.area = ObtenerDatosInterfaz();
            LimpiarFormulario();
            EjecutarNotificarUsuario(ngAreas.Editar(area));
        }

        private Area ObtenerDatosInterfaz()
        {
            Area a = new Area();
            a.Id = this.idEditable;
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