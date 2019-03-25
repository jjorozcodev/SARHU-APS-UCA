using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.personal
{
    public partial class editar_funcion : Page
    {
        private NG_Funciones ngFunciones = NG_Funciones.Instanciar();
        protected Funcion funcion = null;
        private int idEditable = 0;

        protected string Mensaje = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            idEditable = int.Parse(Request.QueryString["id"]);
            funcion = ngFunciones.Consultar(idEditable);

            if (!Page.IsPostBack)
            {
                CargarInformacion();
            }
        }

        private void CargarInformacion()
        {
            if (funcion != null)
            {
                funcionNombre.Text = funcion.Nombre;
                funcionDescripcion.Value = funcion.Descripcion;
            }
        }

        protected void Editar_click(object sender, EventArgs e)
        {
            this.funcion = ObtenerDatosInterfaz();
            LimpiarFormulario();
            EjecutarNotificarUsuario(ngFunciones.Editar(funcion));
        }

        private Funcion ObtenerDatosInterfaz()
        {
            Funcion f = new Funcion();
            f.Id = this.idEditable;
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