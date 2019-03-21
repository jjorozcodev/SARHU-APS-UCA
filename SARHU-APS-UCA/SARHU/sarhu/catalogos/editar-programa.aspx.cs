using System;
using Entidades;

using Negocio;
using System.Web.UI;
using System.Web.Services.Description;

namespace SARHU.sarhu.catalogos
{
    public partial class editar_programa : System.Web.UI.Page
    {



        protected Programa programa = new Programa();
        protected string Value { get; set; }
        protected string Message { get; set; }
     

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                idPrograma.Value = Request.QueryString["id"];

                ConsultData(int.Parse(idPrograma.Value));
            }

        }
        private void ConsultData(int ID)
        {
            programa = NG_Programas.Instanciar().Consultar(ID);

            Nombre.Text = programa.Nombre;
            Value = programa.Descripcion;
        }


        private Programa ObtenerDatosInterfaz()
        {
            programa.Id = int.Parse(idPrograma.Value);
            programa.Nombre = Nombre.Text;
            programa.Descripcion = Request.Form["textarea"];
            Nombre.Text = "";
            return programa;
        }

        protected void btnEditar_programa(object sender, EventArgs e)
        {
            if (NG_Programas.Instanciar().Editar(ObtenerDatosInterfaz()))
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
