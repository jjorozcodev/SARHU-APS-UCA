using System;
using Entidades;
using Negocio;
using System.Web.UI;

namespace SARHU.sarhu.ingresos
{
    public partial class agregar_bono : Page
    {
        private NG_Bonos ngBonos = NG_Bonos.Instanciar();
        protected Bono bono = null;

        protected string Mensaje = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            this.bono = ObtenerDatosInterfaz();
            LimpiarFormulario();
            EjecutarNotificarUsuario(ngBonos.Agregar(this.bono));
        }

        private Bono ObtenerDatosInterfaz()
        {
            Bono b = new Bono();
            b.Nombre = bonoNombre.Text;
            b.Descripcion = bonoDescripcion.Value;
            b.Monto = decimal.Parse(bonoMonto.Text);
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