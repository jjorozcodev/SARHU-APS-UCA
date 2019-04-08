<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion.Master" AutoEventWireup="true" CodeBehind="impuestos.aspx.cs" Inherits="SARHU.sarhu.parametros.impuestos" %>
<asp:Content ID="ContentImpuestos" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
   
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <div id="page-wrapper"> 
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Parametrización de Impuestos</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
         <div class="row">
            <div class="col-lg-12">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-10 col-lg-offset-1">
                            <div class="panel panel-formulario">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-12" id="tabs">
                                           <ul class="nav nav-tabs">


                                                <li class="active"><a href="#inss" data-toggle="tab">INSS</a></li>
                                                <li ><a href="#ir" data-toggle="tab">IR</a></li>
                                                <li><a href="#inatec" data-toggle="tab">INATEC</a></li>
                                           
                                           </ul>
                                                <div class="tab-content">

                                                     <div class="tab-pane fade col-lg-6 col-md-offset-3 active in" id="inss">
                                                         
                                                         <br />
                                                            <div>
                                                                <label>Laboral</label>
                                                            </div>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                       <asp:TextBox ID="porcentajeL" type="number" runat="server" Text='<%#Eval("Porcentaje")%>' CssClass="form-control"></asp:TextBox>
                                                                
                                                                <span class="input-group-addon">%</span>
                                                            </div>

                                                            <div>
                                                                <label>Patronal</label>
                                                            </div>
                                                            <div class="form-group input-group" style="width: 100%;">

                                                           <asp:TextBox ID="porcentajeP" type="number" runat="server" Text='<%#Eval("Porcentaje")%>' CssClass="form-control"></asp:TextBox>    
                                                               
                                                                <span class="input-group-addon">%</span>
                                                            </div>
            
                                                            <div>
                                                                <label>Techo Salarial</label>
                                                            </div>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <span class="input-group-addon">C$</span>

                                                          <asp:TextBox ID="techoSalaralInss" type="number" runat="server" Text='<%#Eval("Valor")%>' CssClass="form-control"></asp:TextBox>
                                                                
                                                            </div>

                                                         
                                                             <div class="form-group" align="center">

                                                   <asp:Button ID="btnActualizarInss" Text="Actualizar" runat="server" CssClass="btn btn-success  fondo-verde-aldeas" align="center" OnClick="ActualizarINSS_click"></asp:Button>
                                                               
                                                            </div>
                                                         
                                                    </div>
                                                                                                         
                                                     <div class="tab-pane fade " id="ir">  

                                                 
                                                            <table class="table">
                                                                <thead>
                                                                  <tr>
                                                                    <th>Desde</th>
                                                                    <th>Hasta</th>
                                                                    <th>Base</th>
                                                                    <th>Exceso</th>
                                                                    <th>Porcentaje</th>
                                                                  </tr>
                                                                </thead>
                                                                <tbody>

                                                    
                                                                  <tr>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <span class="input-group-addon">C$</span>
                                                                                                                  
                                                                            <asp:TextBox ID="impDesde1" type="number" runat="server" Text='<%#Eval("Desde")%>' CssClass="form-control"></asp:TextBox>
                                                                                                                                             
                                                                        </div>
                                                                    </td>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <span class="input-group-addon">C$</span>

                                                                          
                                                                               <asp:TextBox ID="impHasta1" type="number" runat="server" Text='<%#Eval("Hasta")%>' CssClass="form-control"></asp:TextBox>
                                                                            
                                                                        </div>
                                                                    </td>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <span class="input-group-addon">C$</span>

                                                                              <asp:TextBox ID="impBase1" type="number" runat="server" Text='<%#Eval("Base")%>' CssClass="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </td>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <span class="input-group-addon">C$</span>

                                                                               <asp:TextBox ID="impExceso1" type="number" runat="server" Text='<%#Eval("Exceso")%>' CssClass="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </td>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">

                                                                          <asp:TextBox ID="impPorcentaje1" type="number" runat="server" Text='<%#Eval("PorcentajeAplicable")%>' CssClass="form-control"></asp:TextBox>
                                                                           
                                                                            <span class="input-group-addon">%</span>
                                                                           
                                                                        </div>
                                                                    </td>
                                                                  </tr>
                                                 


                                                                    
                                                                  <tr>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <span class="input-group-addon">C$</span>
                                                                                                                  
                                                                            <asp:TextBox ID="impDesde2" type="number" runat="server" Text='<%#Eval("Desde")%>' CssClass="form-control"></asp:TextBox>
                                                                                                                                             
                                                                        </div>
                                                                    </td>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <span class="input-group-addon">C$</span>

                                                                          
                                                                               <asp:TextBox ID="impHasta2" type="number" runat="server" Text='<%#Eval("Hasta")%>' CssClass="form-control"></asp:TextBox>
                                                                            
                                                                        </div>
                                                                    </td>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <span class="input-group-addon">C$</span>

                                                                              <asp:TextBox ID="impBase2" type="number" runat="server" Text='<%#Eval("Base")%>' CssClass="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </td>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <span class="input-group-addon">C$</span>

                                                                               <asp:TextBox ID="impExceso2" type="number" runat="server" Text='<%#Eval("Exceso")%>' CssClass="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </td>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">

                                                                          <asp:TextBox ID="impPorcentaje2" type="number" runat="server" Text='<%#Eval("PorcentajeAplicable")%>' CssClass="form-control"></asp:TextBox>
                                                                           
                                                                            <span class="input-group-addon">%</span>
                                                                           
                                                                        </div>
                                                                    </td>
                                                                  </tr>


                                                                    
                                                                  <tr>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <span class="input-group-addon">C$</span>
                                                                                                                  
                                                                            <asp:TextBox ID="impDesde3" type="number" runat="server" Text='<%#Eval("Desde")%>' CssClass="form-control"></asp:TextBox>
                                                                                                                                             
                                                                        </div>
                                                                    </td>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <span class="input-group-addon">C$</span>

                                                                          
                                                                               <asp:TextBox ID="impHasta3" type="number" runat="server" Text='<%#Eval("Hasta")%>' CssClass="form-control"></asp:TextBox>
                                                                            
                                                                        </div>
                                                                    </td>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <span class="input-group-addon">C$</span>

                                                                              <asp:TextBox ID="impBase3" type="number" runat="server" Text='<%#Eval("Base")%>' CssClass="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </td>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <span class="input-group-addon">C$</span>

                                                                               <asp:TextBox ID="impExceso3" type="number" runat="server" Text='<%#Eval("Exceso")%>' CssClass="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </td>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">

                                                                          <asp:TextBox ID="impPorcentaje3" type="number" runat="server" Text='<%#Eval("PorcentajeAplicable")%>' CssClass="form-control"></asp:TextBox>
                                                                           
                                                                            <span class="input-group-addon">%</span>
                                                                           
                                                                        </div>
                                                                    </td>
                                                                  </tr>




                                                                    
                                                                  <tr>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <span class="input-group-addon">C$</span>
                                                                                                                  
                                                                            <asp:TextBox ID="impDesde4" type="number" runat="server" Text='<%#Eval("Desde")%>' CssClass="form-control"></asp:TextBox>
                                                                                                                                             
                                                                        </div>
                                                                    </td>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <span class="input-group-addon">C$</span>

                                                                          
                                                                               <asp:TextBox ID="impHasta4" type="number" runat="server" Text='<%#Eval("Hasta")%>' CssClass="form-control"></asp:TextBox>
                                                                            
                                                                        </div>
                                                                    </td>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <span class="input-group-addon">C$</span>

                                                                              <asp:TextBox ID="impBase4" type="number" runat="server" Text='<%#Eval("Base")%>' CssClass="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </td>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <span class="input-group-addon">C$</span>

                                                                               <asp:TextBox ID="impExceso4" type="number" runat="server" Text='<%#Eval("Exceso")%>' CssClass="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </td>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">

                                                                          <asp:TextBox ID="impPorcentaje4" type="number" runat="server" Text='<%#Eval("PorcentajeAplicable")%>' CssClass="form-control"></asp:TextBox>
                                                                           
                                                                            <span class="input-group-addon">%</span>
                                                                           
                                                                        </div>
                                                                    </td>
                                                                  </tr>




                                                                    
                                                                  <tr>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <span class="input-group-addon">C$</span>
                                                                                                                  
                                                                            <asp:TextBox ID="impDesde5" type="number" runat="server" Text='<%#Eval("Desde")%>' CssClass="form-control"></asp:TextBox>
                                                                                                                                             
                                                                        </div>
                                                                    </td>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <span class="input-group-addon">C$</span>

                                                                          
                                                                               <asp:TextBox ID="impHasta5" type="number" runat="server" Text='<%#Eval("Hasta")%>' CssClass="form-control"></asp:TextBox>
                                                                            
                                                                        </div>
                                                                    </td>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <span class="input-group-addon">C$</span>

                                                                              <asp:TextBox ID="impBase5" type="number" runat="server" Text='<%#Eval("Base")%>' CssClass="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </td>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">
                                                                            <span class="input-group-addon">C$</span>

                                                                               <asp:TextBox ID="impExceso5" type="number" runat="server" Text='<%#Eval("Exceso")%>' CssClass="form-control"></asp:TextBox>
                                                                        </div>
                                                                    </td>
                                                                    <td> 
                                                                        <div class="form-group input-group" style="width: 100%;">

                                                                          <asp:TextBox ID="impPorcentaje5" type="number" runat="server" Text='<%#Eval("PorcentajeAplicable")%>' CssClass="form-control"></asp:TextBox>
                                                                           
                                                                            <span class="input-group-addon">%</span>
                                                                           
                                                                        </div>
                                                                    </td>
                                                                  </tr>


                                                                                                                                        
                                                           
                                                                </tbody>
                                                              </table>
                                                       

                                                             <div class="form-group" align="center">

                                        <asp:Button ID="btnActualizarIr" Text="Actualizar" runat="server" CssClass="btn btn-success  fondo-verde-aldeas" align="center" OnClick="ActualizarIR_click"></asp:Button>

                                                            </div>                                                         
                                                          </div>
                                                    
                                                    
                                                     
                                         <div class="tab-pane fade col-lg-6 col-md-offset-3" id="inatec">
                                                <div>
                                                    <br />

                                                    <label>Porcentaje</label>
                                                </div>
                                                <div class="form-group input-group" style="width: 100%;">
                                                      <asp:TextBox ID="porcentajeIna" type="number" runat="server" Text='<%#Eval("Valor")%>' CssClass="form-control"></asp:TextBox>
                                                      <span class="input-group-addon">%</span>                               
                                                </div>

                                                 <div class="form-group" align="center">
                                            <asp:Button ID="btnActualizarInatec" Text="Actualizar" runat="server" CssClass="btn btn-success  fondo-verde-aldeas" align="center" OnClick="ActualizarInatec_click"></asp:Button>
    
                                                  
                                                </div>
                                        </div> 


                                    <!-- /.row (nested) -->
                                      </div>
                                      
                                <!-- /.panel-body -->
                                        </div>
                                    </div>

                        <!-- /.col-lg-6 (nested) -->
                                </div>
                    <!-- /.row (nested) -->
                            </div>
                <!-- /.panel-body -->
                        </div>
            <!-- /.panel -->
                   </div>
                 </div>
            </div>
         </div>
    </div>

        <script>
        $(function () {
            $("#tabs").tabs();
        });
        </script>

     <script>      
        function validatenumerics1(key) {
            //getting key code of pressed key
            var keycode = (key.which) ? key.which : key.keyCode;
            //comparing pressed keycodes
            if (keycode > 31 && (keycode < 48 || keycode > 57)) {
                if ((keycode > 31 && keycode <= 43) || (keycode > 43 && keycode <= 45) || keycode > 57 || keycode == 47) {
                    if ((keycode > 31 && keycode <= 43) || (keycode > 45 && keycode <= 47) || keycode > 57 || keycode == 45) {
                        snackbarNumber();
                        return false;
                    }
                }
            }
            else return true;
        }
    </script>


        <script>
        function PopupConfirmacion() {
            $('#myModal').modal({ backdrop: 'static', keyboard: false }, 'show');
        }

        function PopupNotificacion() {
            $('#delete').modal({ backdrop: 'static', keyboard: false }, 'show');
        }
        
        $('#closemodal').click(function () {
            $('#mymodal').modal('hide');

        });

        $(document).ready(function () {
            $('#dataTables-datos').DataTable({
                responsive: true
            });
        });
    </script>

       
</asp:Content>
