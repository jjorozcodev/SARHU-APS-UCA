using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.catalogos
{
    public partial class agregar_programa : System.Web.UI.Page
    {
        public string Value { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {


        }


        private Programa GetEntity()
        {

            Programa prog = new Programa();

            
            prog.Nombre = nombreprog.Text;
            prog.Descripcion = descripcionprog.Text;

            return prog;

        }



        protected void btnGuardar_programa(object sender, EventArgs e)
        {

            Programa prog = GetEntity();//Recupero el valor regresado por GetEntity

            if (prog != null)// Valido si el objeto no es nulo
            {
                //Si el objeto no es nulo se llama a la capa de negocio y se le pasa el objeto

                bool resp = NG_Programas.Instanciar().Agregar(prog);
                if (resp == true)//Se valida la respuesta de la capa de negocio
                {
                    //Si la respuesta es TRUE se procede a ejecutar un JavaScript que muestra un MODAL que 
                    //muestra al usuario un mensaje de confirmacion
                    Value = "REGISTRO GUARDADO EXITOSAMENTE!!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "ShowPopup();", true);


                    nombreprog.Text = "";
                    nombreprog.BorderColor = System.Drawing.Color.LightGray;
                    descripcionprog.Text = "";
                    descripcionprog.BorderColor = System.Drawing.Color.LightGray;
                    Response.Redirect("programas.aspx");

                }
                else
                {
                    //Si la respuesta es FALSE se procede a ejecutar un JavaScript que muestra un MODAL que 
                    //muestra al usuario un mensaje de error
                    Value = "NO SE PUEDO GUARDAR EL REGISTRO";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "ShowPopup();", true);
                }

            }
            else
            {
                //Si el objeto es nulo se muestra un SNACKBAR o TOAST que indica al usuario que no se pueden dejar campos nulos
                ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "snackbar();", true);
            }


        }





    }
}