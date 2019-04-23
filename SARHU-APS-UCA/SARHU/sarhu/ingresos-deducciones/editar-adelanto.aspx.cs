using System;
using Entidades;
using Negocio;
using System.Web.UI.WebControls;

namespace SARHU.sarhu.ingresos
{
    public partial class editar_adelanto : System.Web.UI.Page
    {
        protected Adelanto adelanto = new Adelanto();
        protected string Message { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadContent();
                ConsultData(int.Parse(Request.QueryString["id"]));
            }
        }

        private void LoadContent()
        {

            ///Rellenar Dropdown De Empleados
            Empleado.DataSource = NG_Empleados.Instanciar().Listar();
            Empleado.DataTextField = "Nombres";
            Empleado.DataValueField = "Id";
            Empleado.DataBind();
            Empleado.Items.Insert(0, new ListItem("Seleccione...", "0"));

        }

        private void ConsultData(int ID)
        {
            adelanto = NG_Adelantos.Instanciar().Consultar(ID);

            Idadelanto.Value = adelanto.Id.ToString();

            idFechaEntrega.Value = string.Format("{0:yyyy-MM-dd}", adelanto.FechaEntrega);
            idFechaDeduccion.Value = string.Format("{0:yyyy-MM-dd}", adelanto.FechaDeduccion);
            Monto.Text = adelanto.Monto.ToString();

            //En busca el valor del Id en el dropdownlist para dejarlo ubicado al momento de cargar la pagina
            Empleado.Items.FindByValue(adelanto.EmpleadoId.ToString()).Selected = true;

            textarea.Value = adelanto.Descripcion;
        }

        private Adelanto ObtenerDatosInterfaz()
        {
            adelanto.EmpleadoId = int.Parse(Empleado.SelectedItem.Value);
            //localidad.DepartamentoId = int.Parse(Departamento.SelectedItem.Value);
            adelanto.FechaEntrega = DateTime.Parse(idFechaEntrega.Value);
            adelanto.FechaDeduccion = DateTime.Parse(idFechaDeduccion.Value);
            adelanto.Monto = decimal.Parse(Monto.Text);
            adelanto.Descripcion = textarea.Value;
            adelanto.Id = int.Parse(Idadelanto.Value);

            return adelanto;
        }


        protected void Guardar_Click(object sender, EventArgs e)
        {
            Adelanto adelantos = ObtenerDatosInterfaz();

            if (NG_Adelantos.Instanciar().Editar(adelantos))
            {
                Message = "¡La operación fue completada con éxito!";
                panel.Visible = true;
            }
            else
            {
                Message = "¡Ocurrió un error al intentar realizar la operación!";
                panel.CssClass = "alert alert-danger alert-dismissable";
                panel.Visible = true;
            }
        }
    }
}