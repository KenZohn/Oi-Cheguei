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
    /// Interação lógica para CadastroResponsavel.xam
    /// </summary>
    public partial class CadastroResponsavel : Page
    {
        public CadastroResponsavel()
        {
            InitializeComponent();
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

        private void campoCPF_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(campoCPF.Text))
            {
                labelCPF.Visibility = Visibility.Visible;
            }
            else
            {
                labelCPF.Visibility = Visibility.Hidden;
            }
        }

        private void campoTelefone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(campoTelefone.Text))
            {
                labelTelefone.Visibility = Visibility.Visible;
            }
            else
            {
                labelTelefone.Visibility = Visibility.Hidden;
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
                    string strSql = "INSERT INTO [Responsavel] ([Nome], [CPF], [Telefone]) VALUES ('"+
                        campoNome.Text + "', '" + 
                        campoCPF.Text + "', '" +
                        campoTelefone + "')";
                    cmd.CommandText = strSql;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            MessageBox.Show("Responsável cadastrado com sucesso.");
            campoNome.Clear();
            campoCPF.Clear();
            campoTelefone.Clear();
        }
    }
}
