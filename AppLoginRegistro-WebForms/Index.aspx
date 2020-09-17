<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AppLoginRegistro_WebForms.Index" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js" integrity="sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8shuf57BaghqFfPlYxofvL8/KUEfYiJOMMV+rV" crossorigin="anonymous"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <a class="navbar-brand" href="#">Sistema com Cadastro de Produtos (WebForms - ASP.NET - MySql)</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
                        <asp:Label Text="" ID="Label1" runat="server" class="nav-link" />
                    </li>
                    <li class="nav-item">
                        <span class="form-inline my-2 my-lg-0">
                            <asp:TextBox ID="txtBuscar" runat="server" class="form-control mr-sm-2" placeholder="Buscar Produto" aria-label="Search" />
                            <asp:Button Text="Buscar" ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" class="btn btn-outline-success my-2 my-sm-0" />
                        </span>
                    </li>
                </ul>
                <span class="form-inline my-2 my-lg-0">
                    <asp:Label Text="" ID="txtNomeNivel" runat="server" class="nav-link" />
                    <asp:Button Text="Logout" ID="btnSair" runat="server" PostBackUrl="~/Login.aspx" class="nav-link" />
                </span>
            </div>
        </nav>


        <asp:HiddenField ID="id_produtos" runat="server" />
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label Text="Produto " runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtProduto" runat="server" Width="180px" Enabled="False" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Descrição " runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtDescricao" runat="server" Width="180px" Enabled="False" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Valor " runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtValor" runat="server" Width="180px" Enabled="False" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Quantidade " runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtQuantidade" runat="server" Width="180px" Enabled="False" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Categorias " runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlCategorias" runat="server" Width="180px" Enabled="False" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Fornecedores " runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlFornecedores" runat="server" Width="180px" Enabled="False">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button Text="Novo" ID="btnNovo" runat="server" OnClick="btnNovo_Click" Enabled="False" />
                        <asp:Button Text="Salvar" ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" Enabled="False" />
                        <asp:Button Text="Atualizar" ID="btnEditar" runat="server" Enabled="False" OnClick="btnEditar_Click" />
                        <asp:Button Text="Deletar" ID="btnDeletar" runat="server" Enabled="False" OnClick="btnDeletar_Click" />
                        <asp:Button Text="Limpar" ID="btnLimpar" runat="server" Enabled="False" OnClick="btnLimpar_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label Text="" ID="IDMessageOK" runat="server" ForeColor="Green" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label Text="" ID="IDMessageError" runat="server" ForeColor="Red" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" BackColor="#99CCFF" BorderColor="#999999" BorderWidth="2px" Font-Bold="False" Font-Overline="False">
                <AlternatingRowStyle HorizontalAlign="Left" />
                <Columns>
                    <asp:BoundField DataField="produto" HeaderText="Produto" />
                    <asp:BoundField DataField="descricao" HeaderText="Descrição" />
                    <asp:BoundField DataField="valor" HeaderText="Valor" />
                    <asp:BoundField DataField="quantidade" HeaderText="Quantidade" />
                    <asp:BoundField DataField="categoria" HeaderText="Categoria" />
                    <asp:BoundField DataField="fornecedor" HeaderText="Fornecedor" />
                    <asp:BoundField DataField="telefone" HeaderText="Tel Fornecedor" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnSelecionar" Text="Selecionar" CommandArgument='<%# Eval("id_produtos") %>' runat="server" OnClick="btnSelecionar_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle HorizontalAlign="Center" />
                <HeaderStyle BackColor="Silver" HorizontalAlign="Center" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
