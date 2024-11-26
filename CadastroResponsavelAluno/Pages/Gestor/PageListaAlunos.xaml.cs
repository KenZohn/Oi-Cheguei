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
using CadastroResponsavelAluno.Gestor;

namespace CadastroResponsavelAluno
{
    /// <summary>
    /// Interação lógica para PageListarAlunos.xam
    /// </summary>
    public partial class PageListaAlunos : Page
    {
        Aluno aluno;
        public PageListaAlunos()
        {
            InitializeComponent();

            CarregarDados();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(DataGridAlunos.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Nome", ListSortDirection.Ascending));
        }

        private void BotaoExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.Overlay.Visibility = Visibility.Visible;
                if (aluno != null)
                {
                    MessageBoxResult resultado = MessageBox.Show("Deseja realmente excluir os dados no aluno?", "Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (resultado == MessageBoxResult.Yes)
                    {
                        ExcluirAluno();
                        CarregarDados();
                    }
                    aluno = null;
                    DataGridAlunos.SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("Selecione um aluno.");
                }
                mainWindow.Overlay.Visibility = Visibility.Collapsed;
            }
        }

        private void BotaoAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.Overlay.Visibility = Visibility.Visible;
                if (aluno != null)
                {
                    WindowAlterarAluno windowAlterarAluno = new WindowAlterarAluno(aluno);
                    windowAlterarAluno.ShowDialog();
                    CarregarDados();
                    aluno = null;
                    DataGridAlunos.SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("Selecione um aluno.");
                }
                mainWindow.Overlay.Visibility = Visibility.Collapsed;
            }
        }

        private void DataGridAlunos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridAlunos.SelectedItem is Aluno _aluno)
            {
                aluno = _aluno;
            }
        }

        public void CarregarDados()
        {
            List<Aluno> alunos = new List<Aluno>();

            using (SQLiteConnection conexao = new SQLiteConnection("Data Source=" + System.IO.Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "ChegouBD.db")))
            {
                conexao.Open();
                string strSql = "SELECT * FROM Alunos";
                using (SQLiteCommand cmd = new SQLiteCommand(strSql, conexao))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Aluno aluno = new Aluno
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nome = reader["Nome"].ToString(),
                                Turma = reader["Turma"].ToString(),
                                Responsavel = reader["Responsavel"].ToString(),
                                CPFAluno = reader["CPFAluno"].ToString(),
                                CPFResponsavel = reader["CPFResponsavel"].ToString(),
                                Telefone = reader["Telefone"].ToString(),
                                Endereco = reader["Endereco"].ToString(),
                                TelefoneTrabalho = reader["TelefoneTrabalho"].ToString(),
                                EnderecoTrabalho = reader["EnderecoTrabalho"].ToString(),
                                Autorizado1 = reader["Autorizado1"].ToString(),
                                Autorizado2 = reader["Autorizado2"].ToString(),
                                Autorizado3 = reader["Autorizado3"].ToString()
                            };
                            alunos.Add(aluno);
                        }
                    }
                }
                conexao.Close();
            }
            DataGridAlunos.ItemsSource = alunos;
        }

        private void ExcluirAluno()
        {
            using (SQLiteConnection conexao = new SQLiteConnection("Data Source=" + System.IO.Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "ChegouBD.db")))
            {
                conexao.Open();
                string strSql = "DELETE FROM Alunos WHERE Id = @id";
                using (SQLiteCommand cmd = new SQLiteCommand(strSql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", aluno.Id);

                    cmd.ExecuteNonQuery();
                }
                conexao.Close();
            }
        }
    }
}
