using System;
using Negocio;
using Entidades;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace SARHU.sarhu.personal
{
    public partial class areas : Page
    {
        private NG_Areas ngAreas = NG_Areas.Instanciar();
        protected Area area = null;

        protected string Mensaje = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarInformacion();
            }
        }
        
        private void CargarInformacion()
        {
            rptTable.DataSource = ngAreas.ListarPorEstado(true);
            rptTable.DataBind();
        }
        
        protected void Borrar_Click(object sender, CommandEventArgs e)
        {
            idSeleccionado.Value = e.CommandArgument.ToString();
            this.area = ngAreas.Consultar(int.Parse(idSeleccionado.Value));
            Mensaje = "¿Está seguro que desea borrar el registro " + this.area.Nombre + "?";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "PopupConfirmacion();", true);
        }

        protected void Confirmar_Click(object sender, EventArgs e)
        {
            EjecutarNotificarUsuario(ngAreas.Borrar(int.Parse(idSeleccionado.Value)));
            CargarInformacion();
        }

        private void EjecutarNotificarUsuario(bool correcto)
        {
            if (correcto)
            {
                Mensaje = "¡La operación fue completada con éxito!";
            }
            else
            {
                Mensaje = "¡Ocurrió un error al intentar realizar la operación!";
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "PopupNotificacion();", true);
        }
    }
}