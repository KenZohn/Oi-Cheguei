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
using CadastroResponsavelAluno.Gestor;
using CadastroResponsavelAluno.Models;

namespace CadastroResponsavelAluno
{
    /// <summary>
    /// Interação lógica para PageListarAlunos.xam
    /// </summary>
    public partial class PageListaUsuarios : Page
    {
        Usuario usuario;
        public PageListaUsuarios()
        {
            InitializeComponent();

            CarregarDados();
        }

        private void BotaoExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.Overlay.Visibility = Visibility.Visible;
                if (usuario != null)
                {
                    MessageBoxResult resultado = MessageBox.Show("Deseja realmente excluir os dados no aluno?", "Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (resultado == MessageBoxResult.Yes)
                    {
                        ExcluirAluno();
                        CarregarDados();
                    }
                    usuario = null;
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
            /*if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.Overlay.Visibility = Visibility.Visible;
                if (usuario != null)
                {
                    WindowAlterarUsuario windowAlterarAluno = new WindowAlterarUsuario(usuario);
                    windowAlterarAluno.ShowDialog();
                    CarregarDados();
                    usuario = null;
                    DataGridAlunos.SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("Selecione um aluno.");
                }
                mainWindow.Overlay.Visibility = Visibility.Collapsed;
            }*/
        }

        private void DataGridAlunos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridAlunos.SelectedItem is Usuario _usuario)
            {
                usuario = _usuario;
            }
        }

        public void CarregarDados()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SQLiteConnection conexao = new SQLiteConnection("Data Source=" + System.IO.Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "ChegouBD.db")))
            {
                conexao.Open();
                string strSql = "SELECT * FROM Funcionarios";
                using (SQLiteCommand cmd = new SQLiteCommand(strSql, conexao))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario usuario = new Usuario
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nome = reader["Usuario"].ToString(),
                            };
                            usuarios.Add(usuario);
                        }
                    }
                }
                conexao.Close();
            }
            DataGridAlunos.ItemsSource = usuarios;
        }

        private void ExcluirAluno()
        {
            using (SQLiteConnection conexao = new SQLiteConnection("Data Source=" + System.IO.Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "ChegouBD.db")))
            {
                conexao.Open();
                string strSql = "DELETE FROM Funcionario WHERE Id = @id";
                using (SQLiteCommand cmd = new SQLiteCommand(strSql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", usuario.Id);

                    cmd.ExecuteNonQuery();
                }
                conexao.Close();
            }
        }
    }
}
