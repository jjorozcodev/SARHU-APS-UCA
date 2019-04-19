using System;
using Negocio;
using Entidades;
using System.Web.UI.WebControls;
using System.Data;
using System.Linq;
using System.Web.UI;

namespace SARHU.sarhu.planilla
{
    public partial class historial_planillas : System.Web.UI.Page
    {
        private NG_Planilla ngPlanilla = NG_Planilla.Instanciar();
        public string aliasLocalidad;
        private static int IdLocalidad;
        private static DataTable dataPlanilla = new DataTable();
        public static string Message;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
                DeshabilitarBoton();
            }
        }

        protected void CargarDatos()
        {
            dataPlanilla = ngPlanilla.ListarPlanillas();
            rptPlanilla.DataSource = dataPlanilla;
            rptPlanilla.DataBind();
        }

        protected void DeshabilitarBoton()
        {
            LinkButton aprobar;
            foreach (DataRow row in dataPlanilla.Rows)
            {
                if (row["Aprobado"].ToString()=="Sí")
                {
                    foreach (RepeaterItem item in rptPlanilla.Items)
                    {
                      aprobar = (LinkButton)item.FindControl("Aprobar");
                        if (aprobar != null)
                        {
                            aprobar.Visible = false;
                        }
                    }

                }                
            }
        }

        protected bool AprobarPlanilla(int id)
        {
            Planilla_Empleado Planemp = new Planilla_Empleado();
            Planilla_Empleado pemp = ngPlanilla.ConsultarPlanillaEmpleado(id);

            DataRow dr = dataPlanilla.Select("Id=" + id).FirstOrDefault();

            if (id == pemp.Id)
            {
                Planemp.Id = pemp.Id;
                Planemp.Idlocalidad = pemp.Idlocalidad;
                Planemp.Iddirector = pemp.Iddirector;
                Planemp.Idresponsable = pemp.Idresponsable;
                Planemp.Fecha_elaboracion = pemp.Fecha_elaboracion;
                Planemp.Fecha_aprobacion = DateTime.Now;
                aliasLocalidad = dr["Localidad"].ToString();
                dr["Fecha_de_Aprobación"] = DateTime.Now;
                dr["Aprobado"] = "Sí";
                Planemp.Aprobado = true;
                Planemp.Guardado = pemp.Guardado;
                Planemp.Estado = pemp.Estado;
                Planemp.Observacion = pemp.Observacion;

                rptPlanilla.DataSource = dataPlanilla;
                rptPlanilla.DataBind();
            }

            return ngPlanilla.EditarPlanilla(Planemp);            
        }


        protected void Aprobar_Click(object sender, EventArgs e)
        {
            LinkButton b = (LinkButton)sender;
            IdLocalidad = int.Parse(b.CommandArgument);          

            ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "ShowPopup();", true);
        }

        protected void Confirmar_Click(object sender, EventArgs e)
        {
            if (AprobarPlanilla(IdLocalidad))
            {
                Message = "Aprobado correctamente";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "AprobarPopup();", true);
            }
            else
            {
                Message = "No se puedo aprobado";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "AprobarPopup();", true);
            }
        }
    }
}