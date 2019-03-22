using System;
using Entidades;
using Negocio;
using System.Web.UI;


namespace SARHU.sarhu.seguridad
{
    public partial class editar_rol : System.Web.UI.Page
    {

        protected Rol rol = new Rol();
        protected string Value { get; set; }
        protected string Message { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                idRol.Value = Request.QueryString["id"];

                ConsultData(int.Parse(idRol.Value));
            }



        }

        private void ConsultData(int ID)
        {
            rol = NG_Roles.Instanciar().Consultar(ID);

            Nombre.Text = rol.Nombre;
            Value = rol.Descripcion;
        }

        private Rol ObtenerDatosInterfaz()
        {
            rol.Id = int.Parse(idRol.Value);
            rol.Nombre = Nombre.Text;
            rol.Descripcion = Request.Form["textarea"];
            Nombre.Text = "";
            return rol;
        }




        protected void Editar_click(object sender, EventArgs e)
        {
            if (NG_Roles.Instanciar().Editar(ObtenerDatosInterfaz()))
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