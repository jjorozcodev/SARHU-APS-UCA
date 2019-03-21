using System;
using Negocio;
using Entidades;
using System.Web.UI;

namespace SARHU.sarhu.personal
{
    public partial class agregar_funcion : System.Web.UI.Page
    {
        protected string Message { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private Funcion ObtenerDatosInterfaz()
        {
            Funcion funcion = new Funcion();
            funcion.Nombre = Nombre.Text;
            funcion.Descripcion = Request.Form["textarea"];
            Nombre.Text = "";
            return funcion;
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            if (NG_Funciones.Instanciar().Agregar(ObtenerDatosInterfaz()))
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