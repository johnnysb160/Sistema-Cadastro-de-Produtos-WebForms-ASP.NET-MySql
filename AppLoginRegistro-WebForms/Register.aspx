<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AppLoginRegistro_WebForms.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <link rel="stylesheet" href="Style.css" />
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="formRegister" runat="server">
        <div id="login">
            <div class="container">
                <div id="login-row" class="row justify-content-center align-items-center">
                    <div id="login-column" class="col-md-6">
                        <div id="login-box" class="col-md-12">
                            <div class="form-group">
                                <asp:Label Text="Nome: " runat="server" class="text-info" />
                                <asp:TextBox ID="txtNome" runat="server" class="form-control" />
                                <asp:Label Text="Usuário: " runat="server" class="text-info" />
                                <asp:TextBox ID="txtUsuario" runat="server" class="form-control" />
                                <asp:Label Text="Senha: " runat="server" class="text-info" />
                                <asp:TextBox ID="txtSenha" runat="server" class="form-control" Font-Names="Wingdings" />
                                <asp:Label Text="Nível: " runat="server" class="text-info" />
                                <asp:DropDownList ID="ddlNivel" runat="server" class="form-control">
                                </asp:DropDownList><br />
                                <asp:Button Text="Enviar" ID="btnEnviar" runat="server" class="btn btn-info btn-md" OnClick="btnEnviar_Click" Visible="true" />
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp                                
                                <asp:Button Text="Voltar" ID="btnVoltar" runat="server" PostBackUrl="~/Login.aspx" class="btn btn-info btn-md" />
                                <asp:Panel ID="painel" runat="server">
                                    <div class="alert alert-warning" role="alert">
                                        <asp:Label Text="" ID="IDMessageOK" runat="server" />
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
