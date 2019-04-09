using System;
using System.Collections.Generic;
using System.Linq;
using Negocio;
using Entidades;

using System.Web.UI.WebControls;

namespace SARHU.sarhu.personal
{
    public partial class agregar_puesto : System.Web.UI.Page
    {
        private static List<Funcion> listFunciones = new List<Funcion>();
        private static List<Funcion> funcionesRepeater = new List<Funcion>();
        private static List<int> funcionesId = new List<int>();
        Funcion funciones = null;
        private NG_Puestos ngPuesto = NG_Puestos.Instanciar();
        public string Message = null;
        private Puesto puesto = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clearList();
                populatedDropdownArea();
                populatedDropdownCuentas();
                listFunciones = NG_Funciones.Instanciar().Listar();
                BindGriview(listFunciones);
                fillRepeater(funcionesRepeater);
            }
        }

        private void clearList()
        {
            listFunciones.Clear();
            funcionesRepeater.Clear();
            funcionesId.Clear();
        }

        private void BindGriview(List<Funcion> lsFuncion)
        {
            FuncionesView.DataSource = lsFuncion;
            FuncionesView.DataBind();
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


        private Puesto ObtenerDatosInterfaz()
        {
            puesto = new Puesto();
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
        }


        private bool GuardarPuesto(Puesto puesto)
        {
            bool resp = false;
            int idObtenido = ngPuesto.AgregarPuesto(puesto);
            if (idObtenido > 0)
            {
                ngPuesto.AgregarPuestoFuncion(funcionesId, idObtenido);
                resp = true;
            }
            else
            {
                resp = false;

            }


            return resp;



        }

        private void fillRepeater(List<Funcion> lp)
        {
            rptFuncion.DataSource = lp;
            rptFuncion.DataBind();
        }

        protected void Guardar_Click(object sender, EventArgs e) {
            if (funcionesId.Count() > 0)
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
            funcionesId.RemoveAt(index);


            funcionesRepeater.RemoveAt(argument);
            fillRepeater(funcionesRepeater);

            listFunciones.Add(funciones);
            listFunciones = listFunciones.OrderBy(x => x.Id).ToList();

            BindGriview(listFunciones);
            
        }
    }
}