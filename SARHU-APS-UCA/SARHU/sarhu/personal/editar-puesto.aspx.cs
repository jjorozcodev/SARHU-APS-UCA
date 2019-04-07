using System;
using System.Collections.Generic;
using System.Linq;
using Negocio;
using Entidades;
using System.Web.UI.WebControls;
using System.Data;

namespace SARHU.sarhu.personal
{
    public partial class editar_puesto : System.Web.UI.Page
    {
        protected string Message = null;
        protected NG_Puestos ngPuesto = NG_Puestos.Instanciar();

        private static List<Funcion> listFunciones = new List<Funcion>();
        private static List<Funcion> funcionesRepeater = new List<Funcion>();
        private static List<int> funcionesId = new List<int>();
        private static DataTable dtFuncion = new DataTable();

        private Funcion funciones = null;
        private Puestos puesto = null;
        private static int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ViewState["IdPuesto"] = Request.QueryString["id"];

                clearList();
                populatedDropdownArea();
                populatedDropdownCuentas();
                ConsultData();
                rellenarListfuncionesRepeater();
                listFunciones = NG_Funciones.Instanciar().Listar();
                filtrarGridview(listFunciones);
                BindGriview(listFunciones);


            }
        }

        private void clearList()
        {
            listFunciones.Clear();
            funcionesRepeater.Clear();
            funcionesId.Clear();
            dtFuncion.Clear();
        }

        private void filtrarGridview(List<Funcion> funciones)
        {
            List<Funcion> funcion = new List<Funcion>(funciones);

            foreach (DataRow row in dtFuncion.Rows)
            {
                foreach (Funcion f in funcion)
                {
                    if (f.Id == int.Parse(row["Id"].ToString()))
                    {
                        listFunciones.RemoveAt(funciones.IndexOf(f));
                    }
                }

            }



        }

        private void rellenarListfuncionesRepeater()
        {
            foreach (DataRow row in dtFuncion.Rows)
            {
                funciones = new Funcion();
                funciones.Id = int.Parse(row["Id"].ToString());
                funciones.Nombre = row["Nombre"].ToString();

           
                funcionesRepeater.Add(funciones);
            }

        }

        private void BindGriview(List<Funcion> lsFuncion)
        {
            FuncionesView.DataSource = lsFuncion;
            FuncionesView.DataBind();
        }

        private void fillRepeater(List<Funcion> lp)
        {
            rptFuncion.DataSource = lp;
            rptFuncion.DataBind();
        }

        private void populatedDropdownArea()
        {

            ddlarea.DataSource = NG_Areas.Instanciar().Listar();
            ddlarea.DataTextField = "Nombre";
            ddlarea.DataValueField = "Id";
            ddlarea.DataBind();
            ddlarea.Items.Insert(0, new ListItem("SELECCIONE...", "0"));

        }
        private void populatedDropdownCuentas()
        {

            ddlCuentas.DataSource = NG_Cuentas.Instanciar().ListarPorEstado(true);
            ddlCuentas.DataTextField = "Descripcion";
            ddlCuentas.DataValueField = "Id";
            ddlCuentas.DataBind();
            ddlCuentas.Items.Insert(0, new ListItem("SELECCIONE...", "0"));

        }


        private Puestos ObtenerDatosInterfaz()
        {
            puesto = new Puestos();
            puesto.Id = id;
            puesto.Nombre = NombrePuesto.Text;
            puesto.Descripcion = textarea.Value;
            puesto.SalarioBase = decimal.Parse(Salario.Text);
            puesto.CuentaId = int.Parse(ddlCuentas.SelectedItem.Value);
            puesto.AreaId = int.Parse(ddlarea.SelectedItem.Value);

            CleanInterface();

            return puesto;
        }

        private void CleanInterface()
        {

            NombrePuesto.Text = "";
            textarea.Value = "";
            Salario.Text = "";
            ddlCuentas.SelectedIndex = 0;
            ddlarea.SelectedIndex = 0;
            funcionesRepeater.Clear();
            rptFuncion.DataSource = funcionesRepeater;
            rptFuncion.DataBind();
        }

       

        private bool GuardarPuesto(Puestos puesto)
        {

            funcionesId.Sort();
            bool resp = ngPuesto.EditarPuesto(puesto);
            if (resp == true)
            {
                ngPuesto.AgregarPuestoFuncion(funcionesId,id);
            }
            else
            {
                resp = false;

            }


            return resp;



        }


        private void ConsultData()
        {
            id = int.Parse(ViewState["IdPuesto"].ToString());

            Puestos puesto = ngPuesto.Consultar(id);

            NombrePuesto.Text = puesto.Nombre;
            textarea.Value = puesto.Descripcion;
            ddlarea.Items.FindByValue(puesto.AreaId.ToString()).Selected = true;
            ddlCuentas.Items.FindByValue(puesto.CuentaId.ToString()).Selected = true;
            Salario.Text = puesto.SalarioBase.ToString();
            dtFuncion = ngPuesto.ListarPuestoFunciones(id);

            rptFuncion.DataSource = dtFuncion;
            rptFuncion.DataBind();
        }



        protected void Guardar_Click(object sender, EventArgs e)
        {
            if (funcionesRepeater.Count() > 0)
            {
                if (GuardarPuesto(ObtenerDatosInterfaz()))
                {
                    Message = "GUARDADO EXITOSAMENTE";

                }
                else
                {
                    Message = "ERROR AL GUARDAR EL REGISTRO";
                    panel.CssClass = "alert alert-danger alert-dismissable";
                }
                panel.Visible = true;
            }
            else
            {
                Message = "Seleccione al menos una función";
                errorTable.Visible = true;
            }
        }

        protected void ElminarFuncion_Click(object sender, EventArgs e)
        {
            LinkButton b = (LinkButton)sender;

            funciones = new Funcion();

            string arguments = b.CommandArgument;
            string[] args = arguments.Split(';');

            int argument = int.Parse(args[0]);

            funciones.Id = int.Parse(args[1]);
            funciones.Nombre = args[2];

            int index = funcionesId.IndexOf(funciones.Id);//Busco el index de lo que necesito borrar
            if (index > 0) {
                funcionesId.RemoveAt(index);
            }        


            funcionesRepeater.RemoveAt(argument);
            fillRepeater(funcionesRepeater);

            ngPuesto.EliminarFuncionPuesto(id, funciones.Id);

            listFunciones.Add(funciones);
            listFunciones = listFunciones.OrderBy(x => x.Id).ToList();

            BindGriview(listFunciones);

        }

        protected void FuncionesView_SelectedIndexChanged(object sender, EventArgs e)
        {
            funciones = new Funcion();
            GridViewRow gr = FuncionesView.SelectedRow;

            funciones.Id = int.Parse(gr.Cells[1].Text);
            funciones.Nombre = gr.Cells[2].Text;
            ///Se añade a un list de ints
            funcionesId.Add(funciones.Id);

            funcionesRepeater.Add(funciones);
            ///Aqui uso linq solo para order por ID ya que el Sort no
            ///los ordena al ser objetos
            funcionesRepeater = funcionesRepeater.OrderBy(x => x.Id).ToList();
            fillRepeater(funcionesRepeater);



            int i = FuncionesView.SelectedRow.RowIndex;
            listFunciones.RemoveAt((FuncionesView.SelectedRow.RowIndex));
            BindGriview(listFunciones);
        }
    }
}