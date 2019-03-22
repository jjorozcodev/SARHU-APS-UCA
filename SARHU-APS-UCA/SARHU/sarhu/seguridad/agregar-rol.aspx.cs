using System;
using Negocio;
using Entidades;

namespace SARHU.sarhu.seguridad
{
    public partial class agregar_rol : System.Web.UI.Page
    {

        protected string Message { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {


        }


        private Rol ObtenerDatosInterfaz()
        {
            Rol r = new Rol();

            r.Nombre = Nombre.Text;
            r.Descripcion = Request.Form["textarea"];
            Nombre.Text = "";

            return r;
        }



        protected void Guardar_Click(object sender, EventArgs e)
        {
            if (NG_Roles.Instanciar().Agregar(ObtenerDatosInterfaz()))
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