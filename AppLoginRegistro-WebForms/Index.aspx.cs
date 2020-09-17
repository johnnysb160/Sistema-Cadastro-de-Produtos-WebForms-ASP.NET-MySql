using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppLoginRegistro_WebForms
{
    public partial class Index : System.Web.UI.Page
    {
        Int32 id;
        Conexao con = new Conexao();
        string nomeUsuario;
        string nivelUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            nomeUsuario = Request.QueryString["nome"];
            nivelUsuario = Request.QueryString["nivel"];
            txtNomeNivel.Text = "User: " + Request.QueryString["nome"] + " - Nível: " + nivelUsuario;
            
            
            if (nomeUsuario == null){
                Response.Redirect("Login.aspx");
            }
            if (nivelUsuario == "admin")
            {
                btnNovo.Enabled = true;
            }
            ListarGrid();
            if (ddlCategorias.Text == "")
            {
                CarregarCategorias();
            }
            if (ddlFornecedores.Text == "")
            {
                CarregarFornecedores();
            }
        }

        private void CarregarFornecedores()
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter ListaAdapter = new MySqlDataAdapter();
            DataTable TabelaDataTable = new DataTable();
            con.AbrirConexao();
            sql = "SELECT * FROM fornecedores order by fornecedor asc";
            cmd = new MySqlCommand(sql, con.con);
            ListaAdapter.SelectCommand = cmd;
            ListaAdapter.Fill(TabelaDataTable);
            if (TabelaDataTable.Rows.Count > 0)
            {
                ddlFornecedores.DataSource = TabelaDataTable;
                ddlFornecedores.DataTextField = "fornecedor";
                ddlFornecedores.DataValueField = "id_fornecedores";
                ddlFornecedores.DataBind();
            }
            else
            {
                IDMessageError.Text = "Não possui fornecedores cadastrados";
            }
            con.FecharConexao();
        }

        private void CarregarCategorias()
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter ListaAdapter = new MySqlDataAdapter();
            DataTable TabelaDataTable = new DataTable();
            con.AbrirConexao();
            sql = "SELECT * FROM categorias order by categoria asc";
            cmd = new MySqlCommand(sql, con.con);
            ListaAdapter.SelectCommand = cmd;
            ListaAdapter.Fill(TabelaDataTable);
            if (TabelaDataTable.Rows.Count > 0)
            {
                ddlCategorias.DataSource = TabelaDataTable;
                ddlCategorias.DataTextField = "categoria";
                ddlCategorias.DataValueField = "id_categorias";
                ddlCategorias.DataBind();
            }
            else
            {
                IDMessageError.Text = "Não possui categorias cadastradas";
            }
            con.FecharConexao();
        }

        private void ListarGrid()
        {
                string sql;
                MySqlCommand cmd;
                MySqlDataAdapter ListaAdapter = new MySqlDataAdapter();
                DataTable TabelaDataTable = new DataTable();
                con.AbrirConexao();
                sql = "SELECT p.id_produtos, p.produto, p.descricao, p.valor, p.quantidade, c.id_categorias, c.categoria, f.id_fornecedores, f.fornecedor, f.telefone  FROM produtos as p inner join categorias as c on p.id_categorias = c.id_categorias inner join fornecedores as f on p.id_fornecedores = f.id_fornecedores order by p.produto";
                cmd = new MySqlCommand(sql, con.con);
                ListaAdapter.SelectCommand = cmd;
                ListaAdapter.Fill(TabelaDataTable);
                if (TabelaDataTable.Rows.Count > 0)
                {
                    gridView.Visible = true;
                    gridView.DataSource = TabelaDataTable;
                    gridView.DataBind();
                }
                else
                {
                    IDMessageError.Text = "Não possui produtos cadastrados";
                    gridView.Visible = false;
                }
                con.FecharConexao();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtProduto.Text == "")
            {
                IDMessageError.Text = "Preencha o Produto!";
                txtProduto.Focus();
                return;
            }
            if (txtValor.Text == "")
            {
                IDMessageError.Text = "Preencha o Valor!";
                txtValor.Focus();
                return;
            }
            if (txtQuantidade.Text == "")
            {
                IDMessageError.Text = "Preencha a Quantidade!";
                txtQuantidade.Focus();
                return;
            }
            Salvar();
        }

        private void Salvar()
        {
            string sql;
            MySqlCommand cmd;
            try
            {
                con.AbrirConexao();

                sql = "INSERT INTO produtos (produto, descricao, valor, quantidade, id_categorias, id_fornecedores) VALUES (@produto, @descricao, @valor, @quantidade, @id_categorias, @id_fornecedores)";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@produto", txtProduto.Text);
                cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
                cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(txtValor.Text));
                cmd.Parameters.AddWithValue("@quantidade", txtQuantidade.Text);
                cmd.Parameters.AddWithValue("@id_categorias", ddlCategorias.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@id_fornecedores", ddlFornecedores.SelectedItem.Value);
                cmd.ExecuteNonQuery();
                IDMessageError.Text = "";
                IDMessageOK.Text = "Salvo com Sucesso!";
                ListarGrid();
                con.FecharConexao();
                btnSalvar.Enabled = false;
            }
            catch (Exception e)
            {
                HttpContext.Current.Response.Write("Erro ao fechar a Conexão: " + e);
            }
        }

        private void LimparCampos()
        {
            txtProduto.Text = "";
            txtDescricao.Text = "";
            txtValor.Text = "";
            txtQuantidade.Text = "";
            IDMessageError.Text = "";
            IDMessageOK.Text = "";
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            LimparCampos();
            btnSalvar.Enabled = true;
            btnLimpar.Enabled = true;
            btnEditar.Enabled = false;
            btnBuscar.Enabled = false;
            txtBuscar.Enabled = false;
        }

        private void HabilitarCampos()
        {
            txtProduto.Enabled = true;
            txtDescricao.Enabled = true;
            txtQuantidade.Enabled = true;
            txtValor.Enabled = true;
            ddlCategorias.Enabled = true;
            ddlFornecedores.Enabled = true;
        }
        private void DesabilitarCampos()
        {
            txtProduto.Enabled = false;
            txtDescricao.Enabled = false;
            txtQuantidade.Enabled = false;
            txtValor.Enabled = false;
            ddlCategorias.Enabled = false;
            ddlFornecedores.Enabled = false;
        }

        protected void btnSelecionar_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32((sender as Button).CommandArgument);
            if (txtBuscar.Text != "")
            {
                SelecaoBuscar();
            }
            else
            {
                Selecao();
            }
        }

        private void SelecaoBuscar()
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter ListaAdapter = new MySqlDataAdapter();
            DataTable TabelaDataTable = new DataTable();
            con.AbrirConexao();
            sql = "SELECT p.id_produtos, p.produto, p.descricao, p.valor, p.quantidade, c.id_categorias, c.categoria, f.id_fornecedores, f.fornecedor, f.telefone  FROM produtos as p inner join categorias as c on p.id_categorias = c.id_categorias inner join fornecedores as f on p.id_fornecedores = f.id_fornecedores where p.produto LIKE @produto AND id_produtos = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@produto", txtBuscar.Text + "%");
            cmd.Parameters.AddWithValue("@id", id);
            ListaAdapter.SelectCommand = cmd;
            ListaAdapter.Fill(TabelaDataTable);

            id_produtos.Value = TabelaDataTable.Rows[0][0].ToString();
            txtProduto.Text = TabelaDataTable.Rows[0][1].ToString();
            txtDescricao.Text = TabelaDataTable.Rows[0][2].ToString();
            txtValor.Text = TabelaDataTable.Rows[0][3].ToString();
            txtQuantidade.Text = TabelaDataTable.Rows[0][4].ToString();
            ddlCategorias.SelectedItem.Text = TabelaDataTable.Rows[0][6].ToString();
            ddlFornecedores.SelectedItem.Text = TabelaDataTable.Rows[0][8].ToString();
            gridView.Visible = true;
            gridView.DataSource = TabelaDataTable;
            gridView.DataBind();


            btnSalvar.Enabled = false;
            btnNovo.Enabled = false;
            btnEditar.Enabled = true;
            btnLimpar.Enabled = true;
            if (nivelUsuario == "admin")
            {
                btnDeletar.Enabled = true;
            }
            IDMessageError.Text = "";
            IDMessageOK.Text = "";
            HabilitarCampos();
            con.FecharConexao();
        }

        private void Selecao()
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter ListaAdapter = new MySqlDataAdapter();
            DataTable TabelaDataTable = new DataTable();
            con.AbrirConexao();
            sql = "SELECT p.id_produtos, p.produto, p.descricao, p.valor, p.quantidade, c.id_categorias, c.categoria, f.id_fornecedores, f.fornecedor, f.telefone  FROM produtos as p inner join categorias as c on p.id_categorias = c.id_categorias inner join fornecedores as f on p.id_fornecedores = f.id_fornecedores where p.id_produtos = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", id);
            ListaAdapter.SelectCommand = cmd;
            ListaAdapter.Fill(TabelaDataTable);

            id_produtos.Value = TabelaDataTable.Rows[0][0].ToString();
            txtProduto.Text = TabelaDataTable.Rows[0][1].ToString();
            txtDescricao.Text = TabelaDataTable.Rows[0][2].ToString();
            txtValor.Text = TabelaDataTable.Rows[0][3].ToString();
            txtQuantidade.Text = TabelaDataTable.Rows[0][4].ToString();
            if (TabelaDataTable.Rows[0][5].ToString() != "") ddlCategorias.SelectedItem.Text = TabelaDataTable.Rows[0][6].ToString();
            if (TabelaDataTable.Rows[0][6].ToString() != "") ddlFornecedores.SelectedItem.Text = TabelaDataTable.Rows[0][8].ToString();

            btnSalvar.Enabled = false;
            btnNovo.Enabled = false;
            btnEditar.Enabled = true;
            btnLimpar.Enabled = true;
            if (nivelUsuario == "admin")
            {
                btnDeletar.Enabled = true;
            }
            IDMessageError.Text = "";
            IDMessageOK.Text = "";
            HabilitarCampos();
            con.FecharConexao();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

            if (txtProduto.Text == "")
            {
                IDMessageError.Text = "Preencha o Produto!";
                txtProduto.Focus();
                return;
            }
            if (txtValor.Text == "")
            {
                IDMessageError.Text = "Preencha o Valor!";
                txtValor.Focus();
                return;
            }
            if (txtQuantidade.Text == "")
            {
                IDMessageError.Text = "Preencha a Quantidade!";
                txtQuantidade.Focus();
                return;
            }
            Editar();
        }

        private void Editar()
        {
            string sql;
            MySqlCommand cmd;

            con.AbrirConexao();
            sql = "UPDATE produtos SET produto = @produto, descricao = @descricao, valor=@valor, quantidade=@quantidade, id_categorias=@id_categorias, id_fornecedores=@id_fornecedores WHERE id_produtos = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", id_produtos.Value);
            cmd.Parameters.AddWithValue("@produto", txtProduto.Text);
            cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(txtValor.Text));
            cmd.Parameters.AddWithValue("@quantidade", txtQuantidade.Text);
            cmd.Parameters.AddWithValue("@id_categorias", ddlCategorias.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@id_fornecedores", ddlFornecedores.SelectedItem.Value);
            cmd.ExecuteNonQuery();
            IDMessageError.Text = "";
            txtBuscar.Text = "";
            IDMessageOK.Text = "Atualizado com Sucesso!";
            ListarGrid();
            HabilitarCampos();
            con.FecharConexao();


        }


        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            if (txtProduto.Text == "")
            {
                IDMessageError.Text = "Preencha o Produto!";
                txtProduto.Focus();
                return;
            }
            if (txtValor.Text == "")
            {
                IDMessageError.Text = "Preencha o Valor!";
                txtValor.Focus();
                return;
            }
            if (txtQuantidade.Text == "")
            {
                IDMessageError.Text = "Preencha a Quantidade!";
                txtQuantidade.Focus();
                return;
            }
            if (id_produtos.Value != "")
            {
                Deletar();
            }

        }

        private void Deletar()
        {
            string sql;
            MySqlCommand cmd;

            con.AbrirConexao();
            sql = "DELETE FROM produtos WHERE id_produtos = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", id_produtos.Value);
            cmd.ExecuteNonQuery();
            IDMessageError.Text = "";
            LimparCampos();
            IDMessageOK.Text = "Removido com Sucesso!";
            ListarGrid();
            con.FecharConexao();
            btnEditar.Enabled = false;
            btnLimpar.Enabled = false;
            btnSalvar.Enabled = false;
            btnDeletar.Enabled = false;
            if (nivelUsuario == "admin")
            {
                btnNovo.Enabled = true;
            }
            DesabilitarCampos();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter ListaAdapter = new MySqlDataAdapter();
            DataTable TabelaDataTable = new DataTable();
            con.AbrirConexao();
            sql = "SELECT p.id_produtos, p.produto, p.descricao, p.valor, p.quantidade, c.id_categorias, c.categoria, f.id_fornecedores, f.fornecedor, f.telefone  FROM produtos as p inner join categorias as c on p.id_categorias = c.id_categorias inner join fornecedores as f on p.id_fornecedores = f.id_fornecedores where p.produto LIKE @produto order by p.descricao";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@produto", txtBuscar.Text + "%");
            ListaAdapter.SelectCommand = cmd;
            ListaAdapter.Fill(TabelaDataTable);
            Int32 cont = TabelaDataTable.Rows.Count;
            if (TabelaDataTable.Rows.Count > 0)
            {
                id_produtos.Value = TabelaDataTable.Rows[0][0].ToString();
                txtProduto.Text = TabelaDataTable.Rows[0][1].ToString();
                txtDescricao.Text = TabelaDataTable.Rows[0][2].ToString();
                txtValor.Text = TabelaDataTable.Rows[0][3].ToString();
                txtQuantidade.Text = TabelaDataTable.Rows[0][4].ToString();
                ddlCategorias.SelectedItem.Text = TabelaDataTable.Rows[0][6].ToString();
                ddlFornecedores.SelectedItem.Text = TabelaDataTable.Rows[0][8].ToString();
                gridView.Visible = true;
                gridView.DataSource = TabelaDataTable;
                gridView.DataBind();
                string letra;
                if (cont > 1)
                { letra = "s "; }
                else
                {
                    letra = " ";
                }
                IDMessageOK.Text = cont + " produto" + letra + "encontrado" + letra;
                IDMessageError.Text = "";
            }
            else
            {
                IDMessageOK.Text = "";
                IDMessageError.Text = "Nenhum produto encontrado";
                gridView.Visible = false;
            }
            btnSalvar.Enabled = false;
            btnNovo.Enabled = false;
            btnEditar.Enabled = true;
            btnLimpar.Enabled = true;
            if (nivelUsuario == "admin")
            {
                btnDeletar.Enabled = true;
            }
            HabilitarCampos();
            con.FecharConexao();
        }
        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            DesabilitarCampos();
            btnEditar.Enabled = false;
            btnLimpar.Enabled = false;
            btnSalvar.Enabled = false;
            btnDeletar.Enabled = false;
            if (nivelUsuario == "admin")
            {
                btnNovo.Enabled = true;
            }
            txtBuscar.Text = "";
            btnBuscar.Enabled = true;
            txtBuscar.Enabled = true;
        }
    }
}