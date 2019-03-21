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
            textarea.Value = programa.Descripcion;
        }


        private Programa ObtenerDatosInterfaz()
        {
            programa.Id = int.Parse(idPrograma.Value);
            programa.Nombre = Nombre.Text;
            programa.Descripcion = textarea.Value;
            Nombre.Text = "";
            textarea.Value = "";
            System.Diagnostics.Debug.WriteLine(programa.Nombre + " " + programa.Descripcion);
            return programa;
        }

        protected void btnEditar_programa(object sender, EventArgs e)
        {
            if (NG_Programas.Instanciar().Editar(ObtenerDatosInterfaz()))
            {
                Message = "Guardado Exitosamente";
                panel.Visible = true;
            }
            else
            {
                Message = "Error al editar registro";
                panel.CssClass = "alert alert-danger alert-dismissable";
                panel.Visible = true;
            }

        }
    }














}
