using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppLoginRegistro_WebForms
{
    public class Conexao
    {
        public MySqlConnection con = null;

        public string connection = "SERVER=localhost; DATABASE=asp; UID=root; PWD=12345;";

        public void AbrirConexao()
        {
            try
            {
                con = new MySqlConnection(connection);
                con.Open();
            }
            catch(Exception e)
            {
                HttpContext.Current.Response.Write("Erro ao Conectar: " + e);
            }
        }

        public void FecharConexao()
        {
            try
            {
                con = new MySqlConnection(connection);
                con.Close();
            }
            catch (Exception e)
            {
                HttpContext.Current.Response.Write("Erro ao fechar a Conexão: " + e);

            }
        }
    }
}