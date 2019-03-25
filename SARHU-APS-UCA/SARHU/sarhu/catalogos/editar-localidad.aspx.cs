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
            localidad = NG_Localidades.Instanciar().Consultar(ID);

            Idlocalidad.Value =  localidad.Id.ToString();
            Alias.Text = localidad.Alias;
            //En busca el valor del Id en el dropdownlist para dejarlo ubicado al momento de cargar la pagina
            Programa.Items.FindByValue(localidad.ProgramaId.ToString()).Selected = true;
            //Departamento.Items.FindByValue(localidad.DepartamentoId.ToString()).Selected = true;

            //LoadMunicipio(localidad.DepartamentoId);//El setdefault recupera los municipios segun el Departamento para rellenar el dropdownlist

            Municipio.Items.FindByValue(localidad.MunicipioId.ToString()).Selected = true;//Una vez cargados los departamentos se ubica el municipio del departamento

            //Director.Text = localidad.DirectorName;
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
            localidad.DirectorId = 0111;
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
                Message = "GUARDADO EXITOSAMENTE";
                panel.Visible = true;
            }
            else
            {
                Message = "ERROR AL EDITAR EL REGISTRO";
                panel.CssClass = "alert alert-danger alert-dismissable";
                panel.Visible = true;
            }
        }
    }
}