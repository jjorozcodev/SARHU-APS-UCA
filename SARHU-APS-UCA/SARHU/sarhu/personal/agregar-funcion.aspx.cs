using System;
using Negocio;
using Entidades;
using System.Web.UI;

namespace SARHU.sarhu.personal
{
    public partial class agregar_funcion : Page
    {
        private NG_Funciones ngFunciones = NG_Funciones.Instanciar();
        protected Funcion funcion = null;

        protected string Mensaje = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            this.funcion = ObtenerDatosInterfaz();
            LimpiarFormulario();
            EjecutarNotificarUsuario(ngFunciones.Agregar(this.funcion));
        }

        private Funcion ObtenerDatosInterfaz()
        {
            Funcion f = new Funcion();
            f.Nombre = funcionNombre.Text;
            f.Descripcion = funcionDescripcion.Value;
            return f;
        }

        private void LimpiarFormulario()
        {
            funcionNombre.Text = string.Empty;
            funcionDescripcion.Value = string.Empty;
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