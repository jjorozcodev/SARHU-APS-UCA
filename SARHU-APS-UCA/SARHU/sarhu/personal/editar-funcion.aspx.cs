using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.personal
{
    public partial class editar_funcion : System.Web.UI.Page
    {
        protected Funcion funcion = new Funcion();
        protected string Value { get; set; }
        protected string Message { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                idFuncion.Value = Request.QueryString["id"];

                ConsultData(int.Parse(idFuncion.Value));
            }

        }


        private void ConsultData(int ID)
        {
            funcion = NG_Funciones.Instanciar().Consultar(ID);

            Nombre.Text = funcion.Nombre;
            Value = funcion.Descripcion;
        }


        private Funcion ObtenerDatosInterfaz()
        {
            funcion.Id = int.Parse(idFuncion.Value);
            funcion.Nombre = Nombre.Text;
            funcion.Descripcion = Request.Form["textarea"];
            Nombre.Text = "";
            return funcion;
        }

        protected void Editar_click(object sender, EventArgs e)
        {
            if (NG_Funciones.Instanciar().Editar(ObtenerDatosInterfaz()))
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