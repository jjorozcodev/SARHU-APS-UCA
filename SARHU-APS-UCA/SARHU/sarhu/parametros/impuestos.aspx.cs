using System;
using Entidades;
using Negocio;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SARHU.sarhu.parametros
{
    public partial class impuestos : System.Web.UI.Page
    {

        private NG_IR ngIR = NG_IR.Instanciar();
        private NG_INSS ngINSS = NG_INSS.Instanciar();
        private NG_Variables ngVariable = NG_Variables.Instanciar();

        protected INSS ins1, ins2 = null;
        private int idinnss = 1, idinss2 = 2;

        protected Variable va = null;
        private int idVariable = 6;

        protected IR ir1, ir2, ir3, ir4, ir5 = null;
        private int idActualizar1 = 1, idActualizar2 = 2, idActualizar3 = 3, idActualizar4 = 4, idActualizar5 = 5;
   

        protected string Mensaje = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            ins1 = ngINSS.Consultar(idinnss);
            ins2 = ngINSS.Consultar(idinss2);

            va = ngVariable.Consultar(idVariable);
            
            ir1 = ngIR.Consultar(idActualizar1);
            ir2 = ngIR.Consultar(idActualizar2);
            ir3 = ngIR.Consultar(idActualizar3);
            ir4 = ngIR.Consultar(idActualizar4);
            ir5 = ngIR.Consultar(idActualizar5);
            
            if (!Page.IsPostBack)
            {
                CargarInformacionINSS();
                CargarInformacionIR();
                CargarInformacionInatec();
              
            }
        }


        private void CargarInformacionINSS()
        {
            if (ins1 != null)
            {
                porcentajeL.Text = ins1.Porcentaje.ToString();          
          
            }

            if (ins2 != null)
            {
                porcentajeP.Text = ins2.Porcentaje.ToString();
   
            }
        }
        
        //------------------------------------------------------------------------------------------------
         
                private void CargarInformacionInatec()
                {
                    if (va != null)
                    {
                        porcentajeIna.Text = va.Valor.ToString();

                    }
                }
                

        private void CargarInformacionIR()
        {
            if (ir1 != null)
            {
                impDesde1.Text = ir1.Desde.ToString();               
                impHasta1.Text = ir1.Hasta.ToString();
                impBase1.Text = ir1.Base.ToString();
                impExceso1.Text = ir1.Exceso.ToString();
                impPorcentaje1.Text = ir1.PorcentajeAplicable.ToString();                                     
                
            }

            if (ir2 != null)
            {

                impDesde2.Text = ir2.Desde.ToString();
                impHasta2.Text = ir2.Hasta.ToString();
                impBase2.Text = ir2.Base.ToString();
                impExceso2.Text = ir2.Exceso.ToString();
                impPorcentaje2.Text= ir2.PorcentajeAplicable.ToString();
            }

            if (ir3 != null)
            {
                impDesde3.Text = ir3.Desde.ToString();
                impHasta3.Text = ir3.Hasta.ToString();
                impBase3.Text = ir3.Base.ToString();
                impExceso3.Text = ir3.Exceso.ToString();
                impPorcentaje3.Text = ir3.PorcentajeAplicable.ToString();
            }

            if (ir4 != null)
            {
                impDesde4.Text = ir4.Desde.ToString();
                impHasta4.Text = ir4.Hasta.ToString();
                impBase4.Text = ir4.Base.ToString();
                impExceso4.Text = ir4.Exceso.ToString();
                impPorcentaje4.Text = ir4.PorcentajeAplicable.ToString();
            }
            if (ir5 != null)
            {
                impDesde5.Text = ir5.Desde.ToString();
                impHasta5.Text = ir5.Hasta.ToString();
                impBase5.Text = ir5.Base.ToString();
                impExceso5.Text = ir5.Exceso.ToString();
                impPorcentaje5.Text = ir5.PorcentajeAplicable.ToString();
            }
            
        }
        
        /*
                private void CargarInformacion()
                {
                    rptTable.DataSource = ngIR.Listar();
                    rptTable.DataBind();

                }
                */
        // List<IR> listaIR = NG_IR.Instanciar().Listar(true);
        // Control myControl1 = FindControl("impDesde");


        private IR ObtenerDatosInterfazIR()
        {
            IR i = new IR();

            i.Id = this.idActualizar1;
            i.Desde = decimal.Parse(impDesde1.Text);
            i.Hasta = decimal.Parse(impHasta1.Text);
            i.Base = decimal.Parse(impBase1.Text);
            i.Exceso = decimal.Parse(impExceso1.Text);
            i.PorcentajeAplicable = decimal.Parse(impPorcentaje1.Text);
            i.UltimaActualizacion = DateTime.Now;
               
                return i;
        }



        private IR ObtenerDatosInterfazIR2()
        {
            

            IR i = new IR();

            i.Id = this.idActualizar2;
            i.Desde = decimal.Parse(impDesde2.Text);
            i.Hasta = decimal.Parse(impHasta2.Text);
            i.Base = decimal.Parse(impBase2.Text);
            i.Exceso = decimal.Parse(impExceso2.Text);
            i.PorcentajeAplicable = decimal.Parse(impPorcentaje2.Text);
            i.UltimaActualizacion = DateTime.Now;

            return i;
        }



        private IR ObtenerDatosInterfazIR3()
        {


            IR i = new IR();

           
            i.Id = this.idActualizar3;
            i.Desde = decimal.Parse(impDesde3.Text);
            i.Hasta = decimal.Parse(impHasta3.Text);
            i.Base = decimal.Parse(impBase3.Text);
            i.Exceso = decimal.Parse(impExceso3.Text);
            i.PorcentajeAplicable = decimal.Parse(impPorcentaje3.Text);
            i.UltimaActualizacion = DateTime.Now;

            return i;
        }


        private IR ObtenerDatosInterfazIR4()
        {


            IR i = new IR();

            i.Id = this.idActualizar4;
            i.Desde = decimal.Parse(impDesde4.Text);
            i.Hasta = decimal.Parse(impHasta4.Text);
            i.Base = decimal.Parse(impBase4.Text);
            i.Exceso = decimal.Parse(impExceso4.Text);
            i.PorcentajeAplicable = decimal.Parse(impPorcentaje4.Text);
            i.UltimaActualizacion = DateTime.Now;

            return i;
        }


        private IR ObtenerDatosInterfazIR5()
        {


            IR i = new IR();          

            i.Id = this.idActualizar5;
            i.Desde = decimal.Parse(impDesde5.Text);
            i.Hasta = decimal.Parse(impHasta5.Text);
            i.Base = decimal.Parse(impBase5.Text);
            i.Exceso = decimal.Parse(impExceso5.Text);
            i.PorcentajeAplicable = decimal.Parse(impPorcentaje5.Text);
            i.UltimaActualizacion = DateTime.Now;


            return i;
        }
        //--------------------------------------------------------------------

        private INSS ObtenerDatosInterfazINSS()
        {
            INSS ins = new INSS();

            int id = 1;
            ins.Id = id;
            ins.Patronal = false;
            ins.Porcentaje = decimal.Parse(porcentajeL.Text);
            ins.UltimaActualizacion = DateTime.Now;

            return ins;
        }

        private INSS ObtenerDatosInterfazINSS2()
        {
            INSS i = new INSS();
            int id = 2;
            i.Id = id;
            i.Patronal = true;
            i.Porcentaje = decimal.Parse(porcentajeP.Text);
            i.UltimaActualizacion = DateTime.Now;

            return i;
        }



        private Variable ObtenerDatosInterfazInatec()
        {
            Variable v = new Variable();
            int id = 6;
            v.Id = id;
            string n = "Techo salarial inss";
            v.Nombre = n;
            v.Valor = decimal.Parse(porcentajeIna.Text);
            v.UltimaActualizacion = DateTime.Now;

            return v;
        }


        protected void ActualizarInatec_click(object sender, EventArgs e)
        {
            this.va = ObtenerDatosInterfazInatec();

            EjecutarNotificarUsuario(ngVariable.Editar(va));

        }



        protected void ActualizarINSS_click(object sender, EventArgs e)
        {
            this.ins1 = ObtenerDatosInterfazINSS();
            this.ins2 = ObtenerDatosInterfazINSS2();

            EjecutarNotificarUsuario(ngINSS.Editar(ins1));
            EjecutarNotificarUsuario(ngINSS.Editar(ins2));
            

        }



        protected void Editar_click(object sender, EventArgs e)
        {
            this.ir1 = ObtenerDatosInterfazIR();
            this.ir2 = ObtenerDatosInterfazIR2();
            this.ir3 = ObtenerDatosInterfazIR3();
            this.ir4 = ObtenerDatosInterfazIR4();
            this.ir5 = ObtenerDatosInterfazIR5();

            EjecutarNotificarUsuario(ngIR.Editar(ir1));
            EjecutarNotificarUsuario(ngIR.Editar(ir2));
            EjecutarNotificarUsuario(ngIR.Editar(ir3));
            EjecutarNotificarUsuario(ngIR.Editar(ir4));
            EjecutarNotificarUsuario(ngIR.Editar(ir5));
            
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
       //        panelNotificacion.CssClass = "alert alert-danger alert-dismissable";
            }

      //      panelNotificacion.Visible = true;
        }


    }
}