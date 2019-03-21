using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.personal
{
    public partial class agregar_area : System.Web.UI.Page
    {
        protected string Message { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private Area ObtenerDatosInterfaz()
        {
            Area area = new Area();
            area.Nombre = Nombre.Text;
            area.Descripcion = Request.Form["textarea"];
            Nombre.Text = "";
            return area;
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            if (NG_Areas.Instanciar().Agregar(ObtenerDatosInterfaz()))
            {
                Message = "GUARDADO EXITOSAMENTE";
                panel.Visible = true;
            }
            else
            {
                Message = "ERROR AL GUARDAR EL REGISTRO";
                panel.CssClass = "alert alert-danger alert-dismissable";
                panel.Visible = true;
            }


        }
    }
}