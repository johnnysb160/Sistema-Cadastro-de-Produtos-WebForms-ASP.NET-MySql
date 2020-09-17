<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AppLoginRegistro_WebForms.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <link rel="stylesheet" href="Style.css" />
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
</head>
<body>
    <form id="formLogin" runat="server">
        <div id="login">
            <div class="container">
                <div id="login-row" class="row justify-content-center align-items-center">
                    <div id="login-column" class="col-md-6">
                        <div id="login-box" class="col-md-12">
                            <h3 class="text-center text-info">Login
                                    <img src="https://www.flaticon.com/svg/static/icons/svg/1000/1000946.svg" id="id_img" alt="icon" height="60" width="30" /></h3>
                            <div class="form-group">

                                <asp:Label Text="Usuário" runat="server" class="text-info" /><br />
                                <asp:TextBox ID="txtUsuario" runat="server" class="form-control" />
                            </div>
                            <div class="form-group">
                                <asp:Label Text="Senha" runat="server" class="text-info" /><br />
                                <asp:TextBox ID="txtSenha" runat="server" class="form-control" Font-Names="Wingdings" />
                            </div>

                            <ul class="navbar-nav mr-auto">
                                <li class="nav-item">
                                    <span class="form-inline my-2 my-lg-0">
                                        <asp:Button Text="Login" ID="btnBuscar" runat="server" class="btn btn-info btn-md" OnClick="btnBuscar_Click" />

                                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

                                        <asp:Button Text="Registrar" ID="btnRegistrar" runat="server" PostBackUrl="~/Register.aspx" class="btn btn-info btn-md" />
                                    </span>
                                </li>
                            </ul>

                            <div class="form-group">



                                <asp:Panel ID="painel" runat="server">
                                    <div class="alert alert-warning" role="alert">
                                        <asp:Label Text="" ID="IDMessageError" runat="server" />
                                    </div>
                                </asp:Panel>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
