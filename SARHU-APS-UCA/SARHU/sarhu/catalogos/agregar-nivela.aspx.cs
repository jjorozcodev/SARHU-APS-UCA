using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.catalogos
{
    public partial class agregar_nivela : Page
    {
        private NG_NivelesAcademicos ngNivelesAcademicos = NG_NivelesAcademicos.Instanciar();
        protected NivelAcademico nivelAcademico = null;

        protected string Mensaje = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            this.nivelAcademico = ObtenerDatosInterfaz();
            LimpiarFormulario();
            EjecutarNotificarUsuario(ngNivelesAcademicos.Agregar(this.nivelAcademico));
        }

        private NivelAcademico ObtenerDatosInterfaz()
        {
            NivelAcademico na = new NivelAcademico();
            na.Nombre = nivelaNombre.Text;
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