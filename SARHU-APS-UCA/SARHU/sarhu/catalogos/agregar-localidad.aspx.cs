using System;
using Entidades;
using Negocio;
using System.Web.UI.WebControls;


namespace SARHU.sarhu.catalogos
{
    public partial class agregar_localidad : System.Web.UI.Page
    {
        protected string Message { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadContent();

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
            Departamento.Items.Insert(0, new ListItem("SELECCIONE...", "0"));

            ///Se Deshabilita el Dropdown
            setDefault();
        }

        private void setDefault()
        {
            Municipio.Enabled = false;
            Municipio.Items.Insert(0, new ListItem("SELECCIONE...", "0"));
        }

        private Localidad ObtenerDatosInterfaz()
        {
            Localidad localidad = new Localidad();
            localidad.ProgramaId = int.Parse(Programa.SelectedItem.Value);
            localidad.MunicipioId = int.Parse(Municipio.SelectedItem.Value);
            localidad.DepartamentoId = int.Parse(Departamento.SelectedItem.Value);
            localidad.Telefono = Telefono.Text;
            localidad.Alias = Alias.Text;
            localidad.DirectorId = 0111;
            localidad.Direccion = textarea.Value;




            Alias.Text = "";
            Programa.SelectedIndex = 0;
            setDefault();
            Municipio.SelectedIndex = 0;
            Departamento.SelectedIndex = 0;
            Director.Text = "";
            Telefono.Text = "";
            textarea.Value = "";

            return localidad;
        }

        protected void Departamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(Departamento.SelectedItem.Value);
            Municipio.Items.Clear();
            setDefault();
            if (id > 0)
            {
                Municipio.Enabled = true;
                Municipio.DataSource = NG_Municipios.Instanciar().ObtenerMunicipios(id);
                Municipio.DataTextField = "Nombre";
                Municipio.DataValueField = "Id";
                Municipio.DataBind();
            }

        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            Localidad localidades = ObtenerDatosInterfaz();

            if (NG_Localidades.Instanciar().Agregar(localidades))
            {
                Message = "GUARDADO EXITOSAMENTE";
                panel.Visible = true;
            }
            else
            {
                Message = "ERROR AL GUARDAR EL REGISTRO";
                panel.CssClass = "alert alert-danger alert-dismissable";
                panel.Visible = true;
            }
        }
    }
}