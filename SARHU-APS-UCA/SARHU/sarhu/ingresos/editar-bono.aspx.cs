using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.ingresos
{
    public partial class editar_bono : System.Web.UI.Page
    {
        protected Bono bono = new Bono();
        protected string Value { get; set; }
        protected string Message { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                idBono.Value = Request.QueryString["id"];

                ConsultData(int.Parse(idBono.Value));
            }
        }

        private void ConsultData(int ID)
        {
            bono = NG_Bonos.Instanciar().Consultar(ID);

            Nombre.Text = bono.Nombre;
            Value = bono.Descripcion;
            Monto.Text = Convert.ToString(bono.Monto);
        }


        private Bono ObtenerDatosInterfaz()
        {
            bono.Id = int.Parse(idBono.Value);
            bono.Nombre = Nombre.Text;
            bono.Descripcion = Request.Form["textarea"];
            Nombre.Text = "";
            bono.Monto = Convert.ToDecimal(Monto.Text);
            return bono;
        }

        protected void Editar_click(object sender, EventArgs e)
        {
            if (NG_Bonos.Instanciar().Editar(ObtenerDatosInterfaz()))
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