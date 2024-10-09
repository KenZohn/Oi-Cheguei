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
    /// Interação lógica para Relacionamento.xam
    /// </summary>
    public partial class Relacionamento : Page
    {
        string projectPath;
        public Relacionamento()
        {
            InitializeComponent();

            projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            projectPath = projectPath.Remove(projectPath.Length - 25);

            listarAlunos();
            listarResponsaveis();
        }

        private void listarAlunos()
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + projectPath + "\\ChegouBD.db"))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    string strSql = "SELECT [Nome] FROM [Aluno]";
                    cmd.CommandText = strSql;
                    cmd.Connection = conn;
                    conn.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        campoAluno.Items.Add(reader["nome"].ToString());
                    }

                    conn.Close();
                }
            }
        }
        private void listarResponsaveis()
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + projectPath + "\\ChegouBD.db"))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    string strSql = "SELECT [Nome] FROM [Responsavel]";
                    cmd.CommandText = strSql;
                    cmd.Connection = conn;
                    conn.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        campoResponsavel.Items.Add(reader["nome"].ToString());
                    }

                    conn.Close();
                }
            }
        }

        private int buscarIdAluno()
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + projectPath + "\\ChegouBD.db"))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    string strSql = "SELECT [Id] FROM [Aluno] WHERE [Nome] IN ('" + campoAluno.Text + "')";
                    cmd.CommandText = strSql;
                    cmd.Connection = conn;
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    MessageBox.Show("Aluno: " + reader["id"].ToString());
                    return Convert.ToInt32(reader["id"]);
                    conn.Close();
                }
            }
        }

        private int buscarIdResponsavel()
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + projectPath + "\\ChegouBD.db"))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    string strSql = "SELECT [Id] FROM [Responsavel] WHERE [Nome] IN ('" + campoResponsavel.Text + "')";
                    cmd.CommandText = strSql;
                    cmd.Connection = conn;
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    MessageBox.Show("Responsável: " + reader["id"].ToString());
                    return Convert.ToInt32(reader["id"]);
                    conn.Close();
                }
            }
        }

        private void vincular(int idAluno, int idResponsavel)
        {

        }

        private void botaoVincular_Click(object sender, RoutedEventArgs e)
        {
            buscarIdAluno();
            buscarIdResponsavel();
        }
    }
}
