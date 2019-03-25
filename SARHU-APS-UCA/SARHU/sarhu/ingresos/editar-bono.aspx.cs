using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.ingresos
{
    public partial class editar_bono : Page
    {
        private NG_Bonos ngBonos = NG_Bonos.Instanciar();
        protected Bono bono = null;
        private int idEditable = 0;

        protected string Mensaje = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            idEditable = int.Parse(Request.QueryString["id"]);
            bono = ngBonos.Consultar(idEditable);

            if (!Page.IsPostBack)
            {
                CargarInformacion();
            }
        }

        private void CargarInformacion()
        {
            if (bono != null)
            {
                bonoNombre.Text = bono.Nombre;
                bonoDescripcion.Value = bono.Descripcion;
                bonoMonto.Text = bono.Monto.ToString();
            }
        }

        protected void Editar_click(object sender, EventArgs e)
        {
            this.bono = ObtenerDatosInterfaz();
            LimpiarFormulario();
            EjecutarNotificarUsuario(ngBonos.Editar(bono));
        }

        private Bono ObtenerDatosInterfaz()
        {
            Bono b = new Bono();
            b.Id = this.idEditable;
            b.Nombre = bonoNombre.Text;
            b.Descripcion = bonoDescripcion.Value;
            b.Monto = decimal.Parse(bonoMonto.Text);
            b.Estado = true;
            return b;
        }

        private void LimpiarFormulario()
        {
            bonoNombre.Text = string.Empty;
            bonoDescripcion.Value = string.Empty;
            bonoMonto.Text = string.Empty;
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