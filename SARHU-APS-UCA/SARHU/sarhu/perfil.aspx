<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="SARHU.sarhu.perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <div class="col-md-6">
                    <h1 class="page-header">Perfil del Usuario</h1>
                </div>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-6 col-md-offset-6">
                            <div class="panel panel-formulario">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-4" style="padding:10px;">
                                                   <img src="/Content/Imagenes/profile.png" width="130" height="140" title="De Clic Para Cambiar">
                                             </div>
                                            <div class="col-md-8">
                                                 <label>Nombres</label>
                                                       <div class="form-group input-group" style="width: 100%;">
                                                            <input type="text" class="form-control" value="Maria Juana" disabled="">
                                                       </div>
                                                 <label>Apellidos</label>
                                                       <div class="form-group input-group" style="width: 100%;">
                                                            <input type="text" class="form-control" value="Maldonado Palacios" disabled="">
                                                       </div>
                                                 <label>Nombre de Usuario</label>
                                                        <div class="form-group input-group" style="width: 100%;">
                                                            <input type="text" value="mariaMP" class="form-control" disabled="">
                                                        </div>
                                            </div>
                                            <label>Programa</label>
                                                  <div class="form-group input-group" style="width: 100%;">
                                                      <input type="text" class="form-control" value="Centro de Formación Hermann Gmeiner Estelí" disabled="" >
                                                  </div>
                                            <label>Puesto</label>
                                                  <div class="form-group input-group" style="width: 100%;">
                                                      <input type="text" class="form-control" value="Bibliotecario/a" disabled="" >
                                                  </div>
                                            <label>Teléfono</label>
                                            <div class="form-group input-group" style="width: 100%;">
                                                 <span class="input-group-addon">+505</span>
                                                 <input class="form-control" type="text"  id="Telefono" placeholder="8888-8888" tabindex="8" value="8256-7651">
                                            </div>
                                            <label>Correo Electrónico</label>
                                                    <div class="form-group input-group" style="width: 100%;">
                                                        <input type="text" class="form-control" value="mariajuanap@gmail.com">
                                                    </div>
                                            

                                            <div class="form-group" align="center">
                                                <button id="btnActualizafr" class="btn btn-success  fondo-verde-aldeas" align="center">Actualizar</button>
                                                <a href="inicio.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
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
                    <!-- /.row (nested) -->
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->

    </div>
    <div class="modal fade" id="mediumModal" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button style="font-size: 35px" type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h2 class="modal-title" id="mediumModalLabel">Lista de Localidades</h2>
                </div>
                <div class="modal-body">
                    <div id="page-wrapper1">
                        <div class="row">
                            <div class="col-md-6 col-md-offset-6">
                                <div class="panel panel-formulario">
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="panel panel-default2">
                                                    <div>
                                                        <h5 class="modalLittle" id="littleModalLabel">Seleccione</h5>
                                                    </div>
                                                    <div class="panel-body tooltip-demo">
                                                        <table width="100%" class="table table-striped table-bordered table-hover" id="dataTables-example">
                                                            <thead>
                                                                <tr>
                                                                    <th>Departamento</th>
                                                                    <th>Municipio</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr class="odd gradeX">
                                                                    <td>Somoto</td>
                                                                    <td>Totogalpa</td>
                                                                </tr>
                                                                <tr class="even gradeC" style='border: inset 0pt'>
                                                                    <td>Estelí</td>
                                                                    <td>Pueblo Nuevo</td>
                                                                </tr>
                                                                <tr class="even gradeD" style='border: inset 0pt'>
                                                                    <td>Managua</td>
                                                                    <td>Managua</td>
                                                                </tr>
                                                                <tr class="even gradeE" style='border: inset 0pt'>
                                                                    <td>Masaya</td>
                                                                    <td>Masatepe</td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <!-- /.table-responsive -->
                                                    </div>
                                                    <!-- /.panel-body -->
                                                </div>
                                                <!-- /.panel -->
                                            </div>
                                            <!-- /.col-lg-12 -->
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
</asp:Content>
