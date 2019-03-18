using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.personal
{
    public partial class editar_area : System.Web.UI.Page
    {
        protected Area area = new Area();
        protected string Value { get; set; }
        protected string Message { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                idArea.Value = Request.QueryString["id"];
                
                ConsultData(int.Parse(idArea.Value));
            }
             
        }


        private void ConsultData(int ID)
        {
            area = NG_Areas.Instanciar().Consultar(ID);
           
            Nombre.Text = area.Nombre;
            Value = area.Descripcion;
        }


        private Area ObtenerDatosInterfaz()
        {
            area.Id = int.Parse(idArea.Value);
            area.Nombre = Nombre.Text;
            area.Descripcion = Request.Form["textarea"];
            Nombre.Text = "";
            return area;
        }

        protected void Editar_click(object sender, EventArgs e)
        {
            if (NG_Areas.Instanciar().Editar(ObtenerDatosInterfaz()))
            {
                
                Message = "GUARDADO EXITOSAMENTE";
                panel.Visible = true;
            }
            else
            {
                Message = "ERROR AL EDITAR EL REGISTRO";
                panel.CssClass = "alert alert-danger alert-dismissable";
                panel.Visible = true;
            }

        }
    }
}