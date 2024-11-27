using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            AdicionarTurmas();
            ComboBoxTurma.SelectedIndex = 0;
            CarregarDados();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(DataGridPresenca.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Nome", ListSortDirection.Ascending));
        }

        private void ComboBoxTurma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarregarDados();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(DataGridPresenca.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Nome", ListSortDirection.Ascending));
        }

        private void CarregarDados()
        {
            List<Presenca> listaPresenca = new List<Presenca>();
            string connectionString = "Data Source=" + System.IO.Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "ChegouBD.db");
            using (SQLiteConnection conexao = new SQLiteConnection(connectionString))
            {
                conexao.Open();

                string query = "SELECT * FROM Presenca WHERE Turma = @turma";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conexao))
                {
                    cmd.Parameters.AddWithValue("@turma", ComboBoxTurma.SelectedItem.ToString());

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

        private void BotaoHoraSaida_Click(object sender, RoutedEventArgs e)
        {
            // Cria uma instância da classe HoraTempo
            HoraTempo horaTempo = new HoraTempo();

            // Obtém a hora formatada atual
            string horaAtual = horaTempo.ObterDataHoraFormatada();

            // Exibe a hora atual em um MessageBox (você pode ajustar para salvar ou fazer outra ação)
            MessageBox.Show($"Hora de saída: {horaAtual}", "Hora Atualizada", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void NotificarChegada()
        {
            /*using (SQLiteConnection conexao = new SQLiteConnection("Data Source=" + System.IO.Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "ChegouBD.db")))
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
            }*/
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

        private void AdicionarTurmas()
        {
            ComboBoxTurma.Items.Add("1º A");
            ComboBoxTurma.Items.Add("1º B");
            ComboBoxTurma.Items.Add("2º A");
            ComboBoxTurma.Items.Add("2º B");
        }
    }
}
