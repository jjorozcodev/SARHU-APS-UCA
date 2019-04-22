using System;
using Entidades;
using Negocio;
using System.Web.UI.WebControls;

namespace SARHU.sarhu.catalogos
{
    public partial class editar_localidad : System.Web.UI.Page
    {
        protected Localidad localidad = new Localidad();
        protected string Message { get; set; }
        private NG_Empleados ngEmpleado = NG_Empleados.Instanciar();
        private NG_Localidades ngLocalidad = NG_Localidades.Instanciar();
        private static int idDirector;

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

            ///Rellenar Dropdown De Programas
            Programa.DataSource = NG_Programas.Instanciar().Listar();
            Programa.DataTextField = "Nombre";
            Programa.DataValueField = "Id";
            Programa.DataBind();
            Programa.Items.Insert(0, new ListItem("SELECCIONE...", "0"));

            ///Rellenar Dropdown de Departamentos
            Departamento.DataSource = NG_Departamentos.Instanciar().Listar();
            Departamento.DataTextField = "Nombre";
            Departamento.DataValueField = "Id";
            Departamento.DataBind();
            Departamento.Items.Insert(0, new ListItem("Seleccione...", "0"));

            EmpleadosView.DataSource = ngEmpleado.ListarPorEstado(true);
            EmpleadosView.DataBind();
        }

        private void LoadMunicipio(int id)
        {            
            Municipio.Items.Clear();
            Municipio.Enabled = false;
            Municipio.Items.Insert(0, new ListItem("Seleccione...", "0"));

            if (id > 0)
            {
                Municipio.Enabled = true;
                Municipio.DataSource = NG_Municipios.Instanciar().ObtenerMunicipios(id);
                Municipio.DataTextField = "Nombre";
                Municipio.DataValueField = "Id";
                Municipio.DataBind();
            }
        }

        private void ConsultData(int ID)
        {
            localidad = ngLocalidad.Consultar(ID);

            Idlocalidad.Value =  localidad.Id.ToString();
            Alias.Text = localidad.Alias;
            //En busca el valor del Id en el dropdownlist para dejarlo ubicado al momento de cargar la pagina
            Programa.Items.FindByValue(localidad.ProgramaId.ToString()).Selected = true;
            
            Departamento d = NG_Municipios.Instanciar().ObtenerDepartamento(localidad.MunicipioId);
            Departamento.Items.FindByValue(d.Id.ToString()).Selected = true;
            LoadMunicipio(d.Id);//El setdefault recupera los municipios segun el Departamento para rellenar el dropdownlist

            Municipio.Items.FindByValue(localidad.MunicipioId.ToString()).Selected = true;//Una vez cargados los departamentos se ubica el municipio del departamento
            Empleado emp = ngLocalidad.RecuperarDirectorLocalidad(localidad.Id);

            Director.Text = emp.Nombres;
            textarea.Value = localidad.Direccion;
            Telefono.Text = localidad.Telefono; 
        }

        private Localidad ObtenerDatosInterfaz()
        {           
            localidad.ProgramaId = int.Parse(Programa.SelectedItem.Value);
            localidad.MunicipioId = int.Parse(Municipio.SelectedItem.Value);
            //localidad.DepartamentoId = int.Parse(Departamento.SelectedItem.Value);
            localidad.Telefono = Telefono.Text;
            localidad.Alias = Alias.Text;
            localidad.DirectorId = idDirector;
            localidad.Direccion = textarea.Value;
            localidad.Id = int.Parse( Idlocalidad.Value);

            return localidad;
        }

        protected void Departamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMunicipio(int.Parse(Departamento.SelectedItem.Value));
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            Localidad localidades = ObtenerDatosInterfaz();

            if (NG_Localidades.Instanciar().Editar(localidades))
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

        protected void EmpleadosView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = EmpleadosView.SelectedRow;
            idDirector = int.Parse(gr.Cells[1].Text);
            Director.Text = gr.Cells[2].Text;
        }
    }
}