using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Security.Cryptography;

namespace CadastroResponsavelAluno.Models
{
    public class Usuario
    {
        //TODO: Gerar RA, pegar a data do cadatro 
        public int Id { get; set; }
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
        public Usuario()
        {
            
        }

        public void MetodoCadastro(string usuario, string senha, string cpf, string cargo)
        {
            string senhaHasheada = HashingSenha(senha);
            
            SQLiteConnection conn = conexao.AbrirConexao();
            string strSql = "INSERT INTO [Funcionarios] ([Usuario], [Senha], [CPF], [Cargo]) VALUES (@Usuario, @Senha, @CPF, @Cargo)";
            using (SQLiteCommand cmd = new SQLiteCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Senha", senhaHasheada);
                cmd.Parameters.AddWithValue("@CPF", cpf);
                cmd.Parameters.AddWithValue("@Cargo", cargo);
                cmd.ExecuteNonQuery();
            }
            conexao.FecharConexao();
        }

        public bool MetodoLogin(string usuario, string senha)
        {
            bool entrar = false;
            string senhaHasheada = HashingSenha(senha);
            
            SQLiteConnection conn = conexao.AbrirConexao();
            string strSql = "SELECT * FROM [Funcionarios] WHERE [Usuario] = @Usuario AND [Senha] = @Senha";
            using (SQLiteCommand cmd = new SQLiteCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Senha", senhaHasheada);
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

        public string HashingSenha(string senha)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha)); //ComputeHAse calcula o hash do array de bytes fornecido
                return BitConverter.ToString(bytes).Replace("-", "").ToLower(); ; //Cada byte do array equivale a 2 caracteres
            }
        }
    }
}
