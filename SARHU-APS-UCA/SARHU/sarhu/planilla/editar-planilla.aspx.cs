using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Negocio;
using Entidades;
using System.Web.UI.WebControls;
using System.Data;


namespace SARHU.sarhu.planilla
{
    public partial class editar_planilla : System.Web.UI.Page
    {
        private NG_Variables ngVariables = NG_Variables.Instanciar();
        private NG_Programas ngProgramas = NG_Programas.Instanciar();
        private NG_Localidades ngLocalidades = NG_Localidades.Instanciar();
        private NG_Empleados ngEmpleado = NG_Empleados.Instanciar();
        private NG_Planilla ngPlanilla = NG_Planilla.Instanciar();
        private NG_INSS ngInss = NG_INSS.Instanciar();
        private static DataTable planilla = new DataTable();
        private static decimal monto = 0m;
        private static int idDirector;
        private static int idLocalidad;
        public static string Message;
        private static int Idplanilla;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["IdPlanilla"] = Request.QueryString["id"];                
               
                CargarDatos();
                DeshabilitarControles();
                RellenarGridView();
            }
           
        }

        protected void DeshabilitarControles()
        {
            inssLaboral.Enabled = false;
            inssPatronal.Enabled = false;
            inatec.Enabled = false;
            programas.Enabled = false;
            localidad.Enabled = false;
            techoSalarial.Enabled = false;
        } 

        protected void CargarDatos()
        {
            Idplanilla = int.Parse(ViewState["IdPlanilla"].ToString());

            Planilla_Empleado pemp = ngPlanilla.ConsultarPlanillaEmpleado(Idplanilla);

            if (pemp != null)
            {

                foreach (Localidad local in ngLocalidades.ListarPorEstado(true))
                {
                    if (pemp.Iddirector == local.DirectorId)
                    {
                        if (pemp.Idlocalidad == local.Id)
                        {
                            foreach (Programa programa in ngProgramas.ListarPorEstado(true))
                            {
                                if (local.ProgramaId == programa.Id)
                                {
                                    Empleado emp = ngLocalidades.RecuperarDirectorLocalidad(pemp.Idlocalidad);
                                    director.Text = emp.Nombres;
                                    localidad.Text = local.Alias;
                                    textarea.Value = pemp.Observacion;
                                    programas.Text = programa.Nombre;
                                }
                            }

                        }
                    }
                }



            }



            foreach (DataRow row in ngPlanilla.ConsultarDetallePlanilla(Idplanilla).Rows)
            {
                inssPatronal.Text = row["porcentaje_INSS_P"].ToString();
                inssLaboral.Text = row["porcentaje_INSS_L"].ToString();
                inatec.Text = row["porcentaje_INATEC"].ToString();
                techoSalarial.Text = row["techo_salarial"].ToString();

            }


        }

        protected void RellenarGridView()
        {
            planilla = ngPlanilla.ConsultarDetalleEmpleado(Idplanilla);
            GridView1.DataSource = planilla;
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void Guardar_Click(object sender, EventArgs e)
        {

        }
    }
}