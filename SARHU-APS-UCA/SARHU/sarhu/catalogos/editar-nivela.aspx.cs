using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.catalogos
{
    public partial class editar_nivela : Page
    {
        private NG_NivelesAcademicos ngNivelesAcademicos = NG_NivelesAcademicos.Instanciar();
        protected NivelAcademico nivelAcademico = null;
        private int idEditable = 0;

        protected string Mensaje = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            idEditable = int.Parse(Request.QueryString["id"]);
            nivelAcademico = ngNivelesAcademicos.Consultar(idEditable);

            if (!Page.IsPostBack)
            {
                CargarInformacion();
            }
        }

        private void CargarInformacion()
        {
            if (nivelAcademico != null)
            {
                nivelaNombre.Text = nivelAcademico.Nombre;
            }
        }

        protected void Editar_click(object sender, EventArgs e)
        {
            this.nivelAcademico = ObtenerDatosInterfaz();
            LimpiarFormulario();
            EjecutarNotificarUsuario(ngNivelesAcademicos.Editar(nivelAcademico));
        }

        private NivelAcademico ObtenerDatosInterfaz()
        {
            NivelAcademico na = new NivelAcademico();
            na.Id = this.idEditable;
            na.Nombre = nivelaNombre.Text;
            na.Estado = true;
            return na;
        }

        private void LimpiarFormulario()
        {
            nivelaNombre.Text = string.Empty;
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
                panelNotificacion.CssClass = "alert alert-danger alert-dismissable";
            }

            panelNotificacion.Visible = true;
        }
    }
}