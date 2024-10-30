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
            if (string.IsNullOrEmpty(CampoAluno.Text) || string.IsNullOrEmpty(ComboBoxTurma.Text) || string.IsNullOrEmpty(CampoResponsavel.Text))
            {
                MessageBox.Show("Preencha todos os campos.");
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
                string strSql = "UPDATE Alunos SET Nome = @nome, Turma = @turma, Responsavel = @responsavel WHERE Id = @id";
                using (SQLiteCommand cmd = new SQLiteCommand(strSql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", CampoAluno.Text);
                    cmd.Parameters.AddWithValue("@turma", ComboBoxTurma.Text);
                    cmd.Parameters.AddWithValue("@responsavel", CampoResponsavel.Text);
                    cmd.Parameters.AddWithValue("@id", aluno.Id);

                    cmd.ExecuteNonQuery();
                }
                conexao.Close();
            }
        }
    }
}
