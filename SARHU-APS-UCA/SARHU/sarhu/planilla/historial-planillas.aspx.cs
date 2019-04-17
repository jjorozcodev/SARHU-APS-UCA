using System;
using Negocio;
using Entidades;

namespace SARHU.sarhu.planilla
{
    public partial class historial_planillas : System.Web.UI.Page
    {
        private NG_Planilla ngPlanilla = NG_Planilla.Instanciar();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        protected void CargarDatos()
        {
            rptPlanilla.DataSource = ngPlanilla.ListarPlanillas();
            rptPlanilla.DataBind();
        }
    }
}