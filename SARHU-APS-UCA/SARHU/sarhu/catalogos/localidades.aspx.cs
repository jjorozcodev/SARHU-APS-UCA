using System;
using Negocio;
using Entidades;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace SARHU.sarhu.catalogos
{
    public partial class localidades : Page
    {
        private NG_Localidades ngLocalidades = NG_Localidades.Instanciar();
        protected Localidad localidad = null;

        protected string Mensaje = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarProgramas();
                CargarDepartamentos();
                CargarInformacion();
                
            }
           
        }
        private void CargarInformacion()
        {
            rptTable.DataSource = NG_Localidades.Instanciar().VisualizarLocalidades(); ;
            rptTable.DataBind();
        }

        protected void Borrar_Click(object sender, CommandEventArgs e)
        {
            idSeleccionado.Value = e.CommandArgument.ToString();
            this.localidad = ngLocalidades.Consultar(int.Parse(idSeleccionado.Value));
            Mensaje = "¿Está seguro que desea borrar el registro " + this.localidad.Alias + "?";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "PopupConfirmacion();", true);
        }

        protected void Confirmar_Click(object sender, EventArgs e)
        {
            EjecutarNotificarUsuario(ngLocalidades.Borrar(int.Parse(idSeleccionado.Value)));
            CargarInformacion();
        }


        private void EjecutarNotificarUsuario(bool correcto)
        {
            if (correcto)
            {
                Mensaje = "¡La operación fue completada con éxito!";
            }
            else
            {
                Mensaje = "¡Ocurrió un error al intentar realizar la operación!";
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "PopupNotificacion();", true);
        }

        private void CargarProgramas()
        {
            Programa.DataSource = NG_Programas.Instanciar().Listar();
            Programa.DataTextField = "Nombre";
            Programa.DataValueField = "Id";
            Programa.DataBind();
            Programa.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }

        private void CargarDepartamentos()
        {
            Departamento.DataSource = NG_Departamentos.Instanciar().Listar();
            Departamento.DataTextField = "Nombre";
            Departamento.DataValueField = "Id";
            Departamento.DataBind();
            Departamento.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }

        private void CargarMunicipios(int id)
        {
            Municipio.Items.Clear();
            
            Municipio.Items.Insert(0, new ListItem("Seleccione...", "0"));
            if (id > 0)
            {              
                Municipio.DataSource = NG_Municipios.Instanciar().ObtenerMunicipios(id);
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

            //Idlocalidad.Value = localidad.Id.ToString();
            Alias.Text = localidad.Alias;
            //En busca el valor del Id en el dropdownlist para dejarlo ubicado al momento de cargar la pagina
            Programa.Items.FindByValue(localidad.ProgramaId.ToString()).Selected = true;

            Departamento d = NG_Municipios.Instanciar().ObtenerDepartamento(localidad.MunicipioId);
            Departamento.Items.FindByValue(d.Id.ToString()).Selected = true;

            CargarMunicipios(d.Id);//El setdefault recupera los municipios segun el Departamento para rellenar el dropdownlist

            Municipio.Items.FindByValue(localidad.MunicipioId.ToString()).Selected = true;//Una vez cargados los departamentos se ubica el municipio del departamento

            Empleado emp = ngLocalidades.RecuperarDirectorLocalidad(localidad.Id);

            Director.Text = emp.Nombres;
            textarea.Value = localidad.Direccion;
            Telefono.Text = localidad.Telefono;
        }

        protected void Detalle_Click(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);
            int index = int.Parse(button.CommandArgument);
            ConsultData(index);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "ShowDetail();", true);
        }

        //protected void Delete_Click(object sender, EventArgs e)
        //{
        //    LinkButton b = (LinkButton)sender;

        //    string arguments = b.CommandArgument;
        //    string[] args = arguments.Split(';');

        //    Idelminar.Value = args[0];
        //    nombreLocalidad = args[1];

        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "ShowPopup();", true);
        //}



        //protected void Confirm_Click(object sender, EventArgs e)
        //{
        //    int index = int.Parse(Idelminar.Value);
        //    if (NG_Localidades.Instanciar().Borrar(index))
        //    {
        //        Message = "El registro ha sido borrado.";
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "DeletePopup();", true);
        //    }
        //    else
        //    {
        //        Message = "Error al tratar de borrar éste registro de Programa.";
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "none", "DeletePopup();", true);
        //    }

        //}

    }
}