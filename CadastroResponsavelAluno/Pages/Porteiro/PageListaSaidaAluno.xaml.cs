using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CadastroResponsavelAluno.Models;
using LoginCadastroDB;

namespace CadastroResponsavelAluno.Pages.Porteiro
{
    /// <summary>
    /// Interação lógica para PageListaSaidaAluno.xam
    /// </summary>
    public partial class PageListaSaidaAluno : Page
    {
        Presenca presente;
        private ConexaoBD conexao;
        public PageListaSaidaAluno()
        {
            InitializeComponent();
            conexao = new ConexaoBD();
            ObterListaPresenca();
        }

        private void ObterListaPresenca()
        {
            List<Presenca> listaPresenca = new List<Presenca>();
            string connectionString = "Data Source=" + System.IO.Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "ChegouBD.db");
            using (SQLiteConnection conexao = new SQLiteConnection(connectionString))
            {
                conexao.Open();

                string query = "SELECT * FROM Presenca";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conexao))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Presenca presenca = new Presenca
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Id_Aluno = Convert.ToInt32(reader["Id_Aluno"]),
                                Nome = reader["Nome"].ToString(),
                                Turma = reader["Turma"].ToString()
                            };
                            listaPresenca.Add(presenca);
                        }
                    }
                    conexao.Close();
                }
                DataGridPresenca.ItemsSource = listaPresenca;
            }
        }

        private void BotaoChegou_Click(object sender, RoutedEventArgs e)
        {
            Button chamar = (Button)sender; //as Button
            DataGridRow linha = DataGridRow.GetRowContainingElement(chamar); 
            var item = linha.Item as Presenca;
            string responsavel = ObterResponsavel(item.Id_Aluno);
            WindowCheguei cheguei = new WindowCheguei(item.Nome, responsavel); 
            cheguei.Show();
        }


        private void NotificarChegada()
        {
            using (SQLiteConnection conexao = new SQLiteConnection("Data Source=" + System.IO.Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "ChegouBD.db")))
            {
                conexao.Open();
                string strSql = "UPDATE Alunos SET " +
                    "Hora_Saida = @hora_saida," +
                    "WHERE Id = @id";

                using (SQLiteCommand cmd = new SQLiteCommand(strSql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", DateTime.Now.ToString("HH:mm"));
                    //cmd.Parameters.AddWithValue("@id", presenca.Id);

                    cmd.ExecuteNonQuery();
                }
                conexao.Close();
            }
        }

        private string ObterResponsavel(int idAluno)
        {
            string responsavel = null;
            SQLiteConnection conn = conexao.AbrirConexao();
            string query = "SELECT Responsavel FROM Alunos WHERE Id = @IdAluno";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@IdAluno", idAluno);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        responsavel = reader["Responsavel"].ToString();
                    }
                }
            }
            conexao.FecharConexao();
            return responsavel;   
        }
    
    }
}
