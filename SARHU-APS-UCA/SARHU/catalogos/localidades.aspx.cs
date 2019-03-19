using System;
using Negocio;
using Entidades;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace SARHU.sarhu.catalogos
{
    public partial class localidades : System.Web.UI.Page
    {
        protected string nombreLocalidad { get; set; }
        protected string Message { get; private set; }
        protected Localidad localidad = new Localidad();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
                LoadContent();
               

            }
           
        }
        private void LoadData()
        {
            rptTable.DataSource = NG_Localidades.Instanciar().Listar(); ;
            rptTable.DataBind();

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

        }

        private void LoadMunicipio(int id)
        {
            Municipio.Items.Clear();
            
            Municipio.Items.Insert(0, new ListItem("SELECCIONE...", "0"));
            if (id > 0)
            {              
                Municipio.DataSource = NG_Municipios.Instanciar().Listar(id);
                Municipio.DataTextField = "Nombre";
                Municipio.DataValueField = "Id";
                Municipio.DataBind();

            }

        }

        private void ConsultData(int ID)
        {
            localidad = NG_Localidades.Instanciar().Consultar(ID);

            Programa.ClearSelection();
            Departamento.ClearSelection();

            Idlocalidad.Value = localidad.Id.ToString();
            Alias.Text = localidad.Alias;
            //En busca el valor del Id en el dropdownlist para dejarlo ubicado al momento de cargar la pagina
            Programa.Items.FindByValue(localidad.ProgramaId.ToString()).Selected = true;
            Departamento.Items.FindByValue(localidad.DepartamentoId.ToString()).Selected = true;

            LoadMunicipio(localidad.DepartamentoId);//El setdefault recupera los municipios segun el Departamento para rellenar el dropdownlist

            Municipio.Items.FindByValue(localidad.MunicipioId.ToString()).Selected = true;//Una vez cargados los departamentos se ubica el municipio del departamento

            Director.Text = localidad.DirectorName;
            textarea.Value = localidad.Direccion;
            Telefono.Text = localidad.Telefono;
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton b = (LinkButton)sender;

            string arguments = b.CommandArgument;
            string[] args = arguments.Split(';');

            Idelminar.Value = args[0];
            nombreLocalidad = args[1];

            ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "ShowPopup();", true);
        }

      

        protected void Confirm_Click(object sender, EventArgs e)
        {
            int index = int.Parse(Idelminar.Value);
            if (NG_Localidades.Instanciar().Borrar(index))
            {
                Message = "BORRADO EXITOSAMENTE";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "DeletePopup();", true);
            }
            else
            {
                Message = "ERROR AL BORRAR EL REGISTRO";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "DeletePopup();", true);
            }

        }

        protected void Detail_Click(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);
            int index = int.Parse(button.CommandArgument);
            ConsultData(index);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "ShowDetail();", true);
            
        }

    }
}