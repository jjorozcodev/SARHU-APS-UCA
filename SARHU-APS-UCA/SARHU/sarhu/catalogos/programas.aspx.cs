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

            List<Programa> listaprog = NG_Programas.Instanciar().Listar();

            
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




        protected void Button_EliminarPrograma(object sender, EventArgs e)
        {

            int index = int.Parse(eliminar.Value);            

            if (NG_Programas.Instanciar().Borrar(index))
            {
                Message = "REGISTRO BORRADO EXITOSAMENTE!!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "ShowPopup();", true);
            }
            else
            {
                Message = "ERROR AL TRATAR DE ELIMINAR";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "ShowPopup();", true);
            }
        }






    }
}