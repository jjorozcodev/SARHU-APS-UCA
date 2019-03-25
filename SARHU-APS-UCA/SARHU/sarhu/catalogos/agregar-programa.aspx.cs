using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.catalogos
{
    public partial class agregar_programa : Page
    {
        private NG_Programas ngProgramas = NG_Programas.Instanciar();
        protected Programa programa = null;

        protected string Mensaje = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            this.programa = ObtenerDatosInterfaz();
            LimpiarFormulario();
            EjecutarNotificarUsuario(ngProgramas.Agregar(this.programa));
        }

        private Programa ObtenerDatosInterfaz()
        {
            Programa p = new Programa();
            p.Nombre = programaNombre.Text;
            p.Descripcion = programaDescripcion.Value;
            return p;
        }

        private void LimpiarFormulario()
        {
            programaNombre.Text = string.Empty;
            programaDescripcion.Value = string.Empty;
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