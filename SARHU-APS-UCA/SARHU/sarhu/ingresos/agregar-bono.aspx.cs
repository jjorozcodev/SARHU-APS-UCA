using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.ingresos
{
    public partial class agregar_bono : System.Web.UI.Page
    {
        protected string Message { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private Bono ObtenerDatosInterfaz()
        {
            Bono bono = new Bono();
            bono.Nombre = Nombre.Text;
            bono.Descripcion = Request.Form["textarea"];
            Nombre.Text = "";
            bono.Monto = Convert.ToDecimal(Monto.Text);
            return bono;
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            if (NG_Bonos.Instanciar().Agregar(ObtenerDatosInterfaz()))
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