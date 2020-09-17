using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppLoginRegistro_WebForms
{
    public partial class Login : System.Web.UI.Page
    {
        string nomeUsuario;
        string nivelUsuario;
        Conexao con = new Conexao();
        protected void Page_Load(object sender, EventArgs e)
        {
            painel.Visible = false;
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                painel.Visible = true;
                IDMessageError.Text = "Preencha o campo com o Usuário!";
                txtUsuario.Focus();
                return;
            }
            if (txtSenha.Text == "")
            {
                painel.Visible = true;
                IDMessageError.Text = "Preencha o campo com a Senha!";
                txtSenha.Focus();
                return;
            }
            LoginUsuario();
        }
        private void LoginUsuario()
        {
            MySqlCommand cmd;
            MySqlDataReader reader;

            con.AbrirConexao();
            cmd = new MySqlCommand("SELECT u.nome, n.nivel FROM usuarios as u inner join niveis as n on u.id_nivel = n.id_nivel where u.usuario = @usuario AND u.senha = @senha", con.con);
            cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
            cmd.Parameters.AddWithValue("@senha", txtSenha.Text);
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    
                    nomeUsuario = reader["nome"].ToString();
                    nivelUsuario = reader["nivel"].ToString();
                }
                painel.Visible = false;
                Response.Redirect("Index.aspx?nome="+nomeUsuario+ "&nivel=" + nivelUsuario);
                txtUsuario.Text = "";
                txtSenha.Text = "";
                nomeUsuario = "";
                nivelUsuario = "";
            }
            else
            {
                painel.Visible = true;
                IDMessageError.Text = "Erro no Usuário/Senha";
                txtUsuario.Text = "";
                txtSenha.Text = "";
                txtUsuario.Focus();
            }
        }
    }
}