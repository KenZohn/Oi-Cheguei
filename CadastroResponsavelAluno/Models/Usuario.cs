using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CadastroResponsavelAluno.Models
{
    public class Usuario
    {
        //TODO: Gerar RA, pegar a data do cadatro 
        private int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int CPF { get; set; }
        public int Contato { get; set; }
        public string Cargo { get; set; }

        private ConexaoBD conexao;

        public Usuario(ConexaoBD _conexao)
        {
            this.conexao = _conexao;
        }

        public void MetodoCadastro(string usuario, string senha, string cpf, string cargo)
        {
            SQLiteConnection conn = conexao.AbrirConexao();
            string strSql = "INSERT INTO [Funcionarios] ([Usuario], [Senha], [CPF], [Cargo]) VALUES (@Usuario, @Senha, @CPF, @Cargo)";
            using (SQLiteCommand cmd = new SQLiteCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Senha", senha);
                cmd.Parameters.AddWithValue("@CPF", cpf);
                cmd.Parameters.AddWithValue("@Cargo", cargo);
                cmd.ExecuteNonQuery();
            }
            conexao.FecharConexao();
        }

        public bool MetodoLogin(string usuario, string senha)
        {
            bool entrar = false;
            SQLiteConnection conn = conexao.AbrirConexao();
            string strSql = "SELECT * FROM [Funcionarios] WHERE [Usuario] = @Usuario AND [Senha] = @Senha";
            using (SQLiteCommand cmd = new SQLiteCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Senha", senha);
                using (SQLiteDataReader leitor = cmd.ExecuteReader())
                {
                    entrar = leitor.Read();
                }
            }
            conexao.FecharConexao();
            return entrar;
        }

        public string BuscarCargo(string usuario, string senha)
        {
            string cargo = "";
            SQLiteConnection conn = conexao.AbrirConexao();
            string strSql = "SELECT [Cargo] FROM [Funcionarios] WHERE [Usuario] = @Usuario AND [Senha] = @Senha";
            using (SQLiteCommand cmd = new SQLiteCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Senha", senha);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cargo = reader["Cargo"].ToString();
                    }
                }
            }
            conexao.FecharConexao();
            return cargo;
        }
    }
}
