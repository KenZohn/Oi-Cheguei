using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CadastroResponsavelAluno.Gestor
{
    /// <summary>
    /// Lógica interna para WindowAlterarAluno.xaml
    /// </summary>
    public partial class WindowAlterarAluno : Window
    {
        Aluno aluno;
        public WindowAlterarAluno(Aluno _aluno)
        {
            InitializeComponent();

            aluno = _aluno;

            AdicionarTurmas();
            CarregarAluno();
        }

        private void BotaoAlterarAluno_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CampoAluno.Text) ||
                string.IsNullOrEmpty(ComboBoxTurma.Text) ||
                string.IsNullOrEmpty(CampoResponsavel.Text) ||
                string.IsNullOrEmpty(CampoCPFAluno.Text) ||
                string.IsNullOrEmpty(CampoCPFResponsavel.Text) ||
                string.IsNullOrEmpty(CampoTelefone.Text) ||
                string.IsNullOrEmpty(CampoEndereco.Text))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.");
            }
            else
            {
                AlterarAluno();
                this.Close();
            }
        }

        private void BotaoVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CarregarAluno()
        {
            CampoAluno.Text = aluno.Nome;
            ComboBoxTurma.Text = aluno.Turma;
            CampoResponsavel.Text = aluno.Responsavel;
            CampoCPFAluno.Text = aluno.CPFAluno;
            CampoCPFResponsavel.Text = aluno.CPFResponsavel;
            CampoTelefone.Text = aluno.Telefone;
            CampoEndereco.Text = aluno.Endereco;
            CampoTelefoneTrabalho.Text = aluno.TelefoneTrabalho;
            CampoEnderecoTrabalho.Text = aluno.EnderecoTrabalho;
            CampoAutorizado1.Text = aluno.Autorizado1;
            CampoAutorizado2.Text = aluno.Autorizado2;
            CampoAutorizado3.Text = aluno.Autorizado3;
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

        private void AlterarAluno()
        {
            using (SQLiteConnection conexao = new SQLiteConnection("Data Source=" + System.IO.Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "ChegouBD.db")))
            {
                conexao.Open();
                string strSql = "UPDATE Alunos SET " +
                    "Nome = @nome," +
                    "Turma = @turma," +
                    "Responsavel = @responsavel," +
                    "CPFAluno = @cpfAluno," +
                    "CPFResponsavel = @cpfResponsavel," +
                    "Telefone = @telefone," +
                    "Endereco = @endereco," +
                    "TelefoneTrabalho = @telefoneTrabalho," +
                    "EnderecoTrabalho = @enderecoTrabalho," +
                    "Autorizado1 = @autorizado1," +
                    "Autorizado2 = @autorizado2," +
                    "Autorizado3 = @autorizado3 " +
                    "WHERE Id = @id";

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
                    cmd.Parameters.AddWithValue("@id", aluno.Id);

                    cmd.ExecuteNonQuery();
                }
                conexao.Close();
            }
        }

        #region TextChanged PreviewTextInput
        private void CampoCPFAluno_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            // Remove caracteres inválidos
            string text = Regex.Replace(textBox.Text, @"[^\d]", "");
            // Formatando com caracteres especiais
            if (text.Length > 0)
            {
                if (text.Length > 3 && text.Length <= 6)
                    text = $"{text.Substring(0, 3)}.{text.Substring(3, text.Length - 3)}";
                else if (text.Length > 6 && text.Length <= 9)
                    text = $"{text.Substring(0, 3)}.{text.Substring(3, 3)}.{text.Substring(6, text.Length - 6)}";
                else if (text.Length > 9)
                    text = $"{text.Substring(0, 3)}.{text.Substring(3, 3)}.{text.Substring(6, 3)}-{text.Substring(9, text.Length - 9)}";
            }
            textBox.TextChanged -= CampoCPFAluno_TextChanged;
            textBox.Text = text;
            textBox.CaretIndex = textBox.Text.Length;
            textBox.TextChanged += CampoCPFAluno_TextChanged;
        }

        private void CampoCPFResponsavel_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            // Remove caracteres inválidos
            string text = Regex.Replace(textBox.Text, @"[^\d]", "");
            // Formatando com caracteres especiais
            if (text.Length > 0)
            {
                if (text.Length > 3 && text.Length <= 6)
                    text = $"{text.Substring(0, 3)}.{text.Substring(3, text.Length - 3)}";
                else if (text.Length > 6 && text.Length <= 9)
                    text = $"{text.Substring(0, 3)}.{text.Substring(3, 3)}.{text.Substring(6, text.Length - 6)}";
                else if (text.Length > 9)
                    text = $"{text.Substring(0, 3)}.{text.Substring(3, 3)}.{text.Substring(6, 3)}-{text.Substring(9, text.Length - 9)}";
            }
            textBox.TextChanged -= CampoCPFResponsavel_TextChanged;
            textBox.Text = text;
            textBox.CaretIndex = textBox.Text.Length;
            textBox.TextChanged += CampoCPFResponsavel_TextChanged;
        }

        private void CampoTelefone_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            // Remove caracteres inválidos
            string text = Regex.Replace(textBox.Text, @"[^\d]", "");
            // Formatando com caracteres especiais
            if (text.Length > 0)
            {
                if (text.Length > 2 && text.Length <= 6)
                    text = $"({text.Substring(0, 2)}) {text.Substring(2, text.Length - 2)}";
                else if (text.Length > 6)
                    text = $"({text.Substring(0, 2)}) {text.Substring(2, 4)}-{text.Substring(6, text.Length - 6)}";
                else text = $"({text}";
            }
            textBox.TextChanged -= CampoTelefone_TextChanged;
            textBox.Text = text;
            textBox.CaretIndex = textBox.Text.Length;
            textBox.TextChanged += CampoTelefone_TextChanged;
        }

        private void CampoTelefoneTrabalho_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            // Remove caracteres inválidos
            string text = Regex.Replace(textBox.Text, @"[^\d]", "");
            // Formatando com caracteres especiais
            if (text.Length > 0)
            {
                if (text.Length > 2 && text.Length <= 6)
                    text = $"({text.Substring(0, 2)}) {text.Substring(2, text.Length - 2)}";
                else if (text.Length > 6)
                    text = $"({text.Substring(0, 2)}) {text.Substring(2, 4)}-{text.Substring(6, text.Length - 6)}";
                else text = $"({text}";
            }
            textBox.TextChanged -= CampoTelefone_TextChanged;
            textBox.Text = text;
            textBox.CaretIndex = textBox.Text.Length;
            textBox.TextChanged += CampoTelefone_TextChanged;
        }

        private void CampoCPFAluno_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox; if (textBox.Text.Length >= 14)
            {
                e.Handled = true;
            }
        }

        private void CampoCPFResponsavel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox; if (textBox.Text.Length >= 14)
            {
                e.Handled = true;
            }
        }

        private void CampoTelefone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox; if (textBox.Text.Length >= 15)
            {
                e.Handled = true;
            }
        }

        private void CampoTelefoneTrabalho_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox; if (textBox.Text.Length >= 15)
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
