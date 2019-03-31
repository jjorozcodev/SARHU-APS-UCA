using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.catalogos
{
    public partial class editar_programa : Page
    {
        private NG_Programas ngProgramas = NG_Programas.Instanciar();
        protected Programa programa = null;
        private int idEditable = 0;

        protected string Mensaje = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            idEditable = int.Parse(Request.QueryString["id"]);
            programa = ngProgramas.Consultar(idEditable);

            if (!Page.IsPostBack)
            {
                CargarInformacion();
            }
        }

        private void CargarInformacion()
        {
            if (programa != null)
            {
                programaNombre.Text = programa.Nombre;
                programaDescripcion.Value = programa.Descripcion;
            }
        }

        protected void Editar_click(object sender, EventArgs e)
        {
            this.programa = ObtenerDatosInterfaz();
            LimpiarFormulario();
            EjecutarNotificarUsuario(ngProgramas.Editar(programa));
        }

        private Programa ObtenerDatosInterfaz()
        {
            Programa p = new Programa();
            p.Id = this.idEditable;
            p.Nombre = programaNombre.Text;
            p.Descripcion = programaDescripcion.Value;
            p.Estado = true;
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
