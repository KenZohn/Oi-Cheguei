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

namespace CadastroResponsavelAluno
{
    /// <summary>
    /// Interação lógica para CadastroAluno.xam
    /// </summary>
    public partial class PageCadastroAluno : Page
    {
        public PageCadastroAluno()
        {
            InitializeComponent();

            AdicionarTurmas();
        }

        #region Botões
        private void BotaoCadastrarAluno_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CampoAluno.Text) ||
                string.IsNullOrEmpty(ComboBoxTurma.Text) ||
                string.IsNullOrEmpty(CampoResponsavel.Text) ||
                string.IsNullOrEmpty(CampoCPFAluno.Text) ||
                string.IsNullOrEmpty(CampoCPFResponsavel.Text))
            {
                if (Application.Current.MainWindow is MainWindow mainWindow)
                {
                    mainWindow.Overlay.Visibility = Visibility.Visible;
                    MessageBox.Show("Preencha todos os campos obrigatórios.");
                    mainWindow.Overlay.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                CadastrarAluno();
                LimparCampos();
            }
        }

        private void BotaoLimparAluno_Click(object sender, RoutedEventArgs e)
        {
            LimparCampos();
        }
        #endregion

        #region Funções
        private void CadastrarAluno()
        {
            using (SQLiteConnection conexao = new SQLiteConnection("Data Source=" + System.IO.Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "ChegouBD.db")))
            {
                conexao.Open();
                string strSql = "INSERT INTO Alunos (Nome, Turma, Responsavel, CPFAluno, CPFResponsavel, Telefone, Endereco, TelefoneTrabalho, EnderecoTrabalho, Autorizado1, Autorizado2, Autorizado3) VALUES (@nome, @turma, @responsavel, @cpfAluno, @cpfResponsavel, @telefone, @endereco, @telefoneTrabalho, @enderecoTrabalho, @autorizado1, @autorizado2, @autorizado3)";
                using (SQLiteCommand cmd = new SQLiteCommand(strSql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", CampoAluno.Text);
                    cmd.Parameters.AddWithValue("@turma", ComboBoxTurma.Text);
                    cmd.Parameters.AddWithValue("@responsavel", CampoResponsavel.Text);
                    cmd.Parameters.AddWithValue("@cpfAluno", CampoCPFAluno.Text);
                    cmd.Parameters.AddWithValue("@cpfResponsavel", CampoCPFResponsavel.Text);
                    cmd.Parameters.AddWithValue("@telefone", CampoTelefone.Text);
                    cmd.Parameters.AddWithValue("@endereco", CampoEndereco.Text);
                    cmd.Parameters.AddWithValue("@telefoneTrabalho", CampoTelefoneTrabalho.Text);
                    cmd.Parameters.AddWithValue("@enderecoTrabalho", CampoEnderecoTrabalho.Text);
                    cmd.Parameters.AddWithValue("@autorizado1", CampoAutorizado1.Text);
                    cmd.Parameters.AddWithValue("@autorizado2", CampoAutorizado2.Text);
                    cmd.Parameters.AddWithValue("@autorizado3", CampoAutorizado3.Text);

                    cmd.ExecuteNonQuery();
                }
                conexao.Close();
            }

            MessageBox.Show("Aluno cadastrado com sucesso.");
        }

        private void LimparCampos()
        {
            CampoAluno.Clear();
            ComboBoxTurma.SelectedIndex = -1;
            CampoResponsavel.Clear();
            CampoCPFAluno.Clear();
            CampoCPFResponsavel.Clear();
            CampoTelefone.Clear();
            CampoEndereco.Clear();
            CampoTelefoneTrabalho.Clear();
            CampoEnderecoTrabalho.Clear();
            CampoAutorizado1.Clear();
            CampoAutorizado2.Clear();
            CampoAutorizado3.Clear();
        }

        private void AdicionarTurmas()
        {
            ComboBoxTurma.Items.Add("1º A");
            ComboBoxTurma.Items.Add("1º B");
            ComboBoxTurma.Items.Add("1º C");
            ComboBoxTurma.Items.Add("2º A");
            ComboBoxTurma.Items.Add("2º B");
            ComboBoxTurma.Items.Add("2º C");
        }
        #endregion
    }
}
