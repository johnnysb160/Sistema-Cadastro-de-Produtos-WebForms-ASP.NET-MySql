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
    public partial class Register : System.Web.UI.Page
    {
        Int32 id;
        Conexao con = new Conexao();
        protected void Page_Load(object sender, EventArgs e)
        {
            painel.Visible = false;
            if (ddlNivel.Text == "")
            {
                CarregarNiveis();
            }

        }
        private void CarregarNiveis()
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter ListaAdapter = new MySqlDataAdapter();
            DataTable TabelaDataTable = new DataTable();
            con.AbrirConexao();
            sql = "SELECT * FROM niveis order by nivel asc";
            cmd = new MySqlCommand(sql, con.con);
            ListaAdapter.SelectCommand = cmd;
            ListaAdapter.Fill(TabelaDataTable);
            ddlNivel.DataSource = TabelaDataTable;
            ddlNivel.DataTextField = "nivel";
            ddlNivel.DataValueField = "id_nivel";
            ddlNivel.DataBind();
            con.FecharConexao();
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                painel.Visible = true;
                IDMessageError.Text = "Preencha o Nome!";
                txtNome.Focus();
                return;
            }
            if (txtSenha.Text == "")
            {
                painel.Visible = true;
                IDMessageError.Text = "Preencha a Senha!";
                txtSenha.Focus();
                return;
            }
            if (txtUsuario.Text == "")
            {
                painel.Visible = true;
                IDMessageError.Text = "Preencha o usuário!";
                txtUsuario.Focus();
                return;
            }
            Enviar();
        }

        private void Enviar()
        {
            string sql;
            MySqlCommand cmd;
            try
            {
                con.AbrirConexao();

                sql = "INSERT INTO usuarios (nome, usuario, senha, id_nivel) VALUES (@nome, @usuario, @senha, @id_nivel)";
                
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@senha", txtSenha.Text);
                cmd.Parameters.AddWithValue("@id_nivel", ddlNivel.SelectedItem.Value);
                cmd.ExecuteNonQuery();
                IDMessageError.Text = "";
                txtNome.Text = "";
                txtUsuario.Text = "";
                txtSenha.Text = "";
                painel.Visible = true;
                IDMessageOK.Text = "Registrado com Sucesso!";
                btnEnviar.Visible = false;
                con.FecharConexao();

            }
            catch (Exception e)
            {
                HttpContext.Current.Response.Write("Erro ao fechar a Conexão: " + e);
            }
        }
    }
}