using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.catalogos
{
    public partial class editar_estadoc : Page
    {
        private NG_EstadosCiviles ngEstadosCiviles = NG_EstadosCiviles.Instanciar();
        protected EstadoCivil estadoCivil = null;
        private int idEditable = 0;

        protected string Mensaje = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            idEditable = int.Parse(Request.QueryString["id"]);
            estadoCivil = ngEstadosCiviles.Consultar(idEditable);

            if (!Page.IsPostBack)
            {
                CargarInformacion();
            }
        }

        private void CargarInformacion()
        {
            if (estadoCivil != null)
            {
                estadocNombre.Text = estadoCivil.Nombre;
            }
        }

        protected void Editar_click(object sender, EventArgs e)
        {
            this.estadoCivil = ObtenerDatosInterfaz();
            LimpiarFormulario();
            EjecutarNotificarUsuario(ngEstadosCiviles.Editar(estadoCivil));
        }

        private EstadoCivil ObtenerDatosInterfaz()
        {
            EstadoCivil ec = new EstadoCivil();
            ec.Id = this.idEditable;
            ec.Nombre = estadocNombre.Text;
            ec.Estado = true;
            return ec;
        }

        private void LimpiarFormulario()
        {
            estadocNombre.Text = string.Empty;
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