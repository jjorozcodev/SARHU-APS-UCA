<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="acceso.aspx.cs" Inherits="SARHU.sarhu.access" %>

<!DOCTYPE html>

<html lang="es">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    
    <title>Sistema de Administración de Recursos Humanos</title>
    <link runat="server" href="~/Logo/aldeas-sos.ico" rel="shortcut icon" type="image/x-icon" />

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/js") %>
        <%: Styles.Render("~/bundles/css") %>
    </asp:PlaceHolder>

</head>
<body>
    <form runat="server">
        <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div  class="panel-heading">
                        <img class="panelimg" src="~/logo/logonav.png" runat="server"/>
                    </div>
                    <div class="panel-body">
                      
                            <fieldset>
                                <div class="form-group">
                                    <input class="form-control fondo-input-password" placeholder="Usuario" name="email" type="text" autofocus>
                                </div>
                                <div class="form-group">
                                    <input class="form-control fondo-input-password" placeholder="Contraseña" name="password" type="password" value="">
                                </div>
                                <div class="form-group">
                                    <a class="forgotpassword" data-toggle="modal" data-target="#mediumModal" href="#">¿Olvidaste tu contraseña? </a>
                                </div>
                                <a href="~/sarhu/inicio.aspx" runat="server" class="btn btn-lg btn-success btn-block fondo-verde-aldeas">Entrar</a>
                            </fieldset>
                    
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>

    <div class="modal fade" id="mediumModal" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button style="font-size: 35px" type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h2 class="modal-title" id="mediumModalLabel">Recuperar Contraseña</h2>

                </div>
                <div class="modal-body">

                    <div id="page-wrapper1">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-6 col-md-offset-6">
                                            <div class="panel panel-formulario">
                                                <div class="panel-body">
                                                    <div class="row">
                                                        <div class="col-md-12">

                                                            <label>Código Empleado</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input type="text" class="form-control">
                                                            </div>
                                                            
                                                            <label>Usuario</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input type="text" class="form-control">
                                                            </div>

                                                            <label>Correo </label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                                <input type="text" class="form-control">
                                                            </div>

                                                            <label>Fecha de Nacimiento</label>
                                                            <div class="form-group input-group" style="width: 100%;">
                                                            <input class="form-control" type="date" name="nacimiento" step="1" min="1959-01-01" max="2001-01-01">
                                                            </div>

                                                             <div class="form-group" align="center" style="width: 100%;">
                                                                <button type="button" class="btn btn-success  fondo-verde-aldeas" align="center">Enviar</button>
                                                                <a href="acceso.aspx" type="button" class="btn btn-danger fondo-rojo-aldeas">Cancelar</a>
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

                    </div>

                </div>

            </div>
        </div>
    </div>

</html>
