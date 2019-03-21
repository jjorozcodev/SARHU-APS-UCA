using System;
using Negocio;
using Entidades;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace SARHU.sarhu.catalogos
{
    public partial class programas : System.Web.UI.Page
    {
        protected string Message { get; set; }
        protected string nombreFuncion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                LoadData();
            }

        }
        
        private void LoadData()
        {
            List<Programa> listaprog = NG_Programas.Instanciar().ListarPorEstado(true);
   
            rptTable.DataSource = listaprog;
            rptTable.DataBind();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton b = (LinkButton)sender;

            string arguments = b.CommandArgument;
            string[] args = arguments.Split(';');

            eliminar.Value = args[0];
            nombreFuncion = args[1];

            ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "ShowPopup();", true);
        }

        protected void Confirm_Click(object sender, EventArgs e)
        {
            int index = int.Parse(eliminar.Value);

            System.Diagnostics.Debug.WriteLine("Entró en evento eliminar programa. Valor: " + index);

            if (NG_Programas.Instanciar().Borrar(index))
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