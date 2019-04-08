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

        protected INSS inssLaboral, inssPatronal = null;
        private int idInnssL = 1, idInssP = 2;

        protected Variable variableTechoSalarial, variableINATEC = null;
        private int idVariableTS = 6, idVariableINATEC = 8;

        protected IR ir0_100K, ir100_200k, ir200_100k, ir350_500k, ir500_999mill = null;
        private int idActualizar1 = 1, idActualizar2 = 2, idActualizar3 = 3, idActualizar4 = 4, idActualizar5 = 5;
   

        protected string Mensaje = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            inssLaboral = ngINSS.Consultar(idInnssL);
            inssPatronal = ngINSS.Consultar(idInssP);

            variableTechoSalarial = ngVariable.Consultar(idVariableTS);
            variableINATEC = ngVariable.Consultar(idVariableINATEC);

            ir0_100K = ngIR.Consultar(idActualizar1);
            ir100_200k = ngIR.Consultar(idActualizar2);
            ir200_100k = ngIR.Consultar(idActualizar3);
            ir350_500k = ngIR.Consultar(idActualizar4);
            ir500_999mill = ngIR.Consultar(idActualizar5);



            if (!Page.IsPostBack)
            {
                CargarInformacionINSS();
                CargarInformacionIR();
                CargarInformacionInatec();
              
            }
        }


        private void CargarInformacionINSS()
        {
            if (inssLaboral != null)
            {
                porcentajeL.Text = inssLaboral.Porcentaje.ToString();          
          
            }

            if (inssPatronal != null)
            {
                porcentajeP.Text = inssPatronal.Porcentaje.ToString();
   
            }

            if (variableTechoSalarial != null)
            {
                techoSalaralInss.Text = variableTechoSalarial.Valor.ToString();

            }



        }

        //------------------------------------------------------------------------------------------------

        private void CargarInformacionInatec()
                {
                    if (variableINATEC != null)
                    {
                        porcentajeIna.Text = variableINATEC.Valor.ToString();


                    }
                }
                

        private void CargarInformacionIR()
        {
            if (ir0_100K != null)
            {
                impDesde1.Text = ir0_100K.Desde.ToString();               
                impHasta1.Text = ir0_100K.Hasta.ToString();
                impBase1.Text = ir0_100K.Base.ToString();
                impExceso1.Text = ir0_100K.Exceso.ToString();
                impPorcentaje1.Text = ir0_100K.PorcentajeAplicable.ToString();                                     
                
            }

            if (ir100_200k != null)
            {

                impDesde2.Text = ir100_200k.Desde.ToString();
                impHasta2.Text = ir100_200k.Hasta.ToString();
                impBase2.Text = ir100_200k.Base.ToString();
                impExceso2.Text = ir100_200k.Exceso.ToString();
                impPorcentaje2.Text= ir100_200k.PorcentajeAplicable.ToString();
            }

            if (ir200_100k != null)
            {
                impDesde3.Text = ir200_100k.Desde.ToString();
                impHasta3.Text = ir200_100k.Hasta.ToString();
                impBase3.Text = ir200_100k.Base.ToString();
                impExceso3.Text = ir200_100k.Exceso.ToString();
                impPorcentaje3.Text = ir200_100k.PorcentajeAplicable.ToString();
            }

            if (ir350_500k != null)
            {
                impDesde4.Text = ir350_500k.Desde.ToString();
                impHasta4.Text = ir350_500k.Hasta.ToString();
                impBase4.Text = ir350_500k.Base.ToString();
                impExceso4.Text = ir350_500k.Exceso.ToString();
                impPorcentaje4.Text = ir350_500k.PorcentajeAplicable.ToString();
            }
            if (ir500_999mill != null)
            {
                impDesde5.Text = ir500_999mill.Desde.ToString();
                impHasta5.Text = ir500_999mill.Hasta.ToString();
                impBase5.Text = ir500_999mill.Base.ToString();
                impExceso5.Text = ir500_999mill.Exceso.ToString();
                impPorcentaje5.Text = ir500_999mill.PorcentajeAplicable.ToString();
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


        private IR ObtenerDatosInterfazIR0_100K()
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



        private IR ObtenerDatosInterfazIR100_200K()
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



        private IR ObtenerDatosInterfazIR200_100K()
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


        private IR ObtenerDatosInterfazIR350_500K()
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


        private IR ObtenerDatosInterfazIR500K_999Mill()
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

        private INSS ObtenerDatosInterfazINSSLaboral()
        {
            INSS ins = new INSS();

            int id = 1;
            ins.Id = id;
            ins.Patronal = false;
            ins.Porcentaje = decimal.Parse(porcentajeL.Text);
            ins.UltimaActualizacion = DateTime.Now;

            return ins;
        }

        private INSS ObtenerDatosInterfazINSSPatronal()
        {
            INSS i = new INSS();
            int id = 2;
            i.Id = id;
            i.Patronal = true;
            i.Porcentaje = decimal.Parse(porcentajeP.Text);
            i.UltimaActualizacion = DateTime.Now;

            return i;
        }

        private Variable ObtenerDatosInterfazINSSTechoSaralial()
        {
            Variable v = new Variable();
            int id = 6;
            v.Id = id;
            string n = "Techo salarial inss";
            v.Nombre = n;
            v.Valor = decimal.Parse(techoSalaralInss.Text);
            v.UltimaActualizacion = DateTime.Now;

            return v;
        }




        private Variable ObtenerDatosInterfazInatec()
        {
            Variable v = new Variable();
            int id = 8;
            v.Id = id;
            string n = "INATEC";
            v.Nombre = n;
            v.Valor = decimal.Parse(porcentajeIna.Text);
            v.UltimaActualizacion = DateTime.Now;

            return v;
        }


        protected void ActualizarInatec_click(object sender, EventArgs e)
        {
            this.variableINATEC = ObtenerDatosInterfazInatec();

            EjecutarNotificarUsuario(ngVariable.Editar(variableINATEC));

        }



        protected void ActualizarINSS_click(object sender, EventArgs e)
        {
            this.inssLaboral = ObtenerDatosInterfazINSSLaboral();
            this.inssPatronal = ObtenerDatosInterfazINSSPatronal();
            this.variableTechoSalarial = ObtenerDatosInterfazINSSTechoSaralial();

            EjecutarNotificarUsuario(ngINSS.Editar(inssLaboral));
            EjecutarNotificarUsuario(ngINSS.Editar(inssPatronal));
            EjecutarNotificarUsuario(ngVariable.Editar(variableTechoSalarial));


        }



        protected void ActualizarIR_click(object sender, EventArgs e)
        {
            this.ir0_100K = ObtenerDatosInterfazIR0_100K();
            this.ir100_200k = ObtenerDatosInterfazIR100_200K();
            this.ir200_100k = ObtenerDatosInterfazIR200_100K();
            this.ir350_500k = ObtenerDatosInterfazIR350_500K();
            this.ir500_999mill = ObtenerDatosInterfazIR500K_999Mill();

            EjecutarNotificarUsuario(ngIR.Editar(ir0_100K));
            EjecutarNotificarUsuario(ngIR.Editar(ir100_200k));
            EjecutarNotificarUsuario(ngIR.Editar(ir200_100k));
            EjecutarNotificarUsuario(ngIR.Editar(ir350_500k));
            EjecutarNotificarUsuario(ngIR.Editar(ir500_999mill));
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