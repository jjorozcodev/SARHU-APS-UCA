using System;
using Negocio;
using Entidades;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace SARHU.sarhu.catalogos
{
    public partial class estado_civil : Page
    {
        private NG_EstadosCiviles ngEstadosCiviles = NG_EstadosCiviles.Instanciar();
        protected EstadoCivil estadoCivil = null;

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
            rptTable.DataSource = ngEstadosCiviles.ListarPorEstado(true);
            rptTable.DataBind();
        }

        protected void Borrar_Click(object sender, CommandEventArgs e)
        {
            idSeleccionado.Value = e.CommandArgument.ToString();
            this.estadoCivil = ngEstadosCiviles.Consultar(int.Parse(idSeleccionado.Value));
            Mensaje = "¿Está seguro que desea borrar el registro " + this.estadoCivil.Nombre + "?";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "PopupConfirmacion();", true);
        }

        protected void Confirmar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(idSeleccionado.Value);
            bool borrado = ngEstadosCiviles.Borrar(id);
            EjecutarNotificarUsuario(borrado);
            CargarInformacion();
        }

        private void EjecutarNotificarUsuario(bool correcto)
        {
            //Mensaje = correcto ? "¡La operación fue completada con éxito!" : "¡Ocurrió un error al intentar realizar la operación!";
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