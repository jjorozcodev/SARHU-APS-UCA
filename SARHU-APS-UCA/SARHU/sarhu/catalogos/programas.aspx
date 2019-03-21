<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion.Master" AutoEventWireup="true" CodeBehind="programas.aspx.cs" Inherits="SARHU.sarhu.catalogos.programas" %>
<asp:Content ID="ContentProgramas" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="page-wrapper">
      <div class="row">
           <div class="col-lg-12">
                <h1 class="page-header">Listado de Programas</h1>
                <a href="agregar-programa.aspx" id="Generar" type="button" class="btn btn-success fondo-verde-aldeas" style="margin-bottom: 10px"><i class="fa fa-plus fa-fw"></i>Agregar Programa</a>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default2">
                    <div class="panel-body tooltip-demo">



                         <asp:HiddenField ID="eliminar" runat="server"/>
                        
                            <asp:Repeater ID="rptTable" runat="server">

                                <HeaderTemplate>
                                    <table width="100%" class="table table-striped table-bordered table-hover" id="dataTables-example">
                                        <thead>
                                            <tr>
                                               <th>Nombre</th>
                                               <th>Descripcion</th>
                                               
                                               <th width="200px">Operaciones</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>                                  
                                    <tr class="even gradeC" style='border: inset 0pt'>

                                        <%--El EVAl funciona para recuperar el dato según la columna--%>
                                        <td><%#Eval("Nombre")%></td>
                                        <td><%#Eval("Descripcion")%></td>
                                       
                                        <td>
                                         
                                          
                                            <%--<button type="button" class="btn btn-default" data-toggle="modal" data-target="#mediumModal" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Detalle"><i class="fa fa-eye fa-fw"></i></span></button>--%>

                                            <%--en este lado es el pegon del modificar ya que al mandar a llamar a otro aspx, tengo que mandar el ID del registro para que sea precargado
                                           pero con el href se puede mandar un ID de la manera que sale acontinuación--%>
                                    
                                       <a href="editar-programa.aspx?id=<%# Eval("Id")%>" type="button" class="btn btn-default" style="margin-right: 10px"><span data-toggle="tooltip" data-placement="top" title="Editar Datos Programa"><i class="fa fa-edit fa-fw"></i></span></a>
                                    
                                                                             
                                       <asp:LinkButton ID="Delete" runat="server" OnClick="Delete_Click" CommandArgument='<%#Eval("Id")+ ";" + Eval("Nombre")%>' class="btn btn-default"><span data-toggle="tooltip" data-placement="top" title="Borrar Datos Programa"><i class="fa fa-trash-o fa-fw"></i></span></asp:LinkButton>


                                             </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                             </table>
                                </FooterTemplate>
                            </asp:Repeater>







                        <!-- /.table-responsive -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-12 -->
        </div>

    </div>

    <div class="modal fade" id="mediumModal" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                     <button style="font-size:35px" type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h2 class="modal-title" id="mediumModalLabel">Detalle de Programa</h2>
                   
                </div>
                <div class="modal-body">

                    <div id="page-wrapper1">
                        <div class="row">
                        <div class="col-md-6 col-md-offset-6">
        <div class="panel panel-formulario">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12">
                            <label>Nombre</label>
                            <div class="form-group input-group" style="width: 100%;">
                                <input type="text" class="form-control" value="Programa de Fortalecimiento Familiar Somoto" disabled="" >
                            </div>
                            <div class="form-group" style="width: 100%;">
                                <label>Descripción</label>
                                <textarea style="resize:none" id="textarea" rows="5" cols="5" class="form-control" maxlength="150" name="textarea" disabled="" ReadOnly>Trabajamos con las familias para garantizar protección y amor a niñas, niños y adolescentes y promovemos el derecho a la educación.</textarea>
                            </div>

                        </div>
                        <!-- /.col-lg-6 (nested) -->
                    </div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.panel-body -->
            </div>
     </div>
                        <!-- /.col-lg-6 (nested) -->
                    </div>
                    </div>
                </div>
            </div>
        </div>
      </div>



    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button style="font-size:30px" type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title" id="myModalLabel">¡Atención!</h4>
                                        </div>
                                        <div class="modal-body">
                                            ¿Está seguro que desea borrar <%=nombreFuncion %>?
                                        </div>
                                        <div class="modal-footer">
                                            <asp:LinkButton ID="Confirm" runat="server" OnClick="Confirm_Click" CssClass="btn btn-danger fondo-rojo-aldeas" Text="Borrar"></asp:LinkButton>
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button> 
                                        </div>
                                    </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
     </div>
    <div class="modal fade" id="delete" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body">
                     <%=Message %>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>

                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <script>
        function ShowPopup() {
            $('#myModal').modal({ backdrop: 'static', keyboard: false }, 'show');
        }

        function DeletePopup() {
            $('#delete').modal({ backdrop: 'static', keyboard: false }, 'show');
        }

       
            $('#closemodal').click(function () {
                $('#mymodal').modal('hide');
           
        });
    </script>
</asp:Content>
