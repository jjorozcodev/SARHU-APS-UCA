using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.personal
{
    public partial class editar_area : System.Web.UI.Page
    {
        private NG_Areas ngAreas = NG_Areas.Instanciar();
        protected Area area = null;
        private int idAreaEditable = 0;

        protected string Mensaje = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                idAreaEditable = int.Parse(Request.QueryString["id"]);
                CargarInformacion(idAreaEditable);
            }
        }
        
        private void CargarInformacion(int idArea)
        {
            area = ngAreas.Consultar(idArea);
           
            if(area != null)
            {
                areaNombre.Text = area.Nombre;
                areaDescripcion.Value = area.Descripcion;
            }
        }

        protected void Editar_click(object sender, EventArgs e)
        {
            Area a = ObtenerDatosInterfaz();
            EjecutarNotificarUsuario(ngAreas.Editar(a));
        }

        private Area ObtenerDatosInterfaz()
        {
            Area a = new Area();
            a.Id = this.idAreaEditable;
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