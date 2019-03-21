using System;
using Negocio;

using System.Web.UI.WebControls;
using System.Web.UI;

namespace SARHU.sarhu.personal
{
    public partial class areas : System.Web.UI.Page
    {
        protected string nombreArea { get; set; }
        protected string Message { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();

            }
        }


        private void LoadData()
        {
            rptTable.DataSource = NG_Areas.Instanciar().ListarPorEstado(true);
            rptTable.DataBind();

        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton b = (LinkButton)sender;

            string arguments = b.CommandArgument;
            string[] args = arguments.Split(';');

            Idelminar.Value = args[0];
            nombreArea = args[1];

            ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "ShowPopup();", true);
        }

        protected void Confirm_Click(object sender, EventArgs e)
        {
            int index = int.Parse(Idelminar.Value);
            if (NG_Areas.Instanciar().Borrar(index))
            {
                Message = "El registro ha sido borrado.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "DeletePopup();", true);
            }
            else
            {
                Message = "Error al tratar de borrar éste registro de Programa.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "DeletePopup();", true);
            }

            LoadData();
        }
    }
}