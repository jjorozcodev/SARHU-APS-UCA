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
                                    <a class="forgotpassword" href="#">¿Olvidaste tu contraseña? </a>
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
</html>
