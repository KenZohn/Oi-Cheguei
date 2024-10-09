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
    public partial class CadastroAluno : Page
    {
        public CadastroAluno()
        {
            InitializeComponent();
            campoAno.Items.Add("1");
            campoAno.Items.Add("2");
            campoAno.Items.Add("3");
            campoAno.Items.Add("4");
            campoAno.Items.Add("5");
            campoAno.Items.Add("6");
            campoTurma.Items.Add("A");
            campoTurma.Items.Add("B");
            campoTurma.Items.Add("C");
        }

        private void campoNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(campoNome.Text))
            {
                labelNome.Visibility = Visibility.Visible;
            }
            else
            {
                labelNome.Visibility = Visibility.Hidden;
            }
        }

        private void botaoCadastrar_Click(object sender, RoutedEventArgs e)
        {
            string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            projectPath = projectPath.Remove(projectPath.Length - 25);

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + projectPath + "\\ChegouBD.db"))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    string strSql = "INSERT INTO [Aluno] ([Nome], [Ano], [Turma]) VALUES ('" +
                        campoNome.Text + "', '" +
                        campoAno.Text + "', '" +
                        campoTurma.Text + "')";
                    cmd.CommandText = strSql;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            MessageBox.Show("Aluno cadastrado com sucesso.");
            campoNome.Clear();
            campoAno.SelectedIndex = -1;
            campoTurma.SelectedIndex = -1;
        }
    }
}
