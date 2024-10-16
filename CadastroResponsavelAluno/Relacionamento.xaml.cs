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
            int id = -1;
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
                    id = Convert.ToInt32(reader["id"]);
                    reader.Close();
                    conn.Close();
                }
            }
            return id;
        }

        private int buscarIdResponsavel()
        {
            int id = -1;
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
                    id = Convert.ToInt32(reader["id"]);
                    reader.Close();
                    conn.Close();
                }
            }
            return id;
        }

        private void vincular(int idAluno, int idResponsavel)
        {
            if (!verificarVinculo(idAluno, idResponsavel))
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + projectPath + "\\ChegouBD.db"))
                {
                    using (SQLiteCommand cmd = new SQLiteCommand())
                    {
                        string strSql = "INSERT INTO [Vinculo] ([Aluno], [Responsavel]) VALUES ('" +
                            idAluno + "', '" +
                            idResponsavel + "')";
                        cmd.CommandText = strSql;
                        cmd.Connection = conn;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                MessageBox.Show("Vínculo cadastrado.");
            }
            else
            {
                MessageBox.Show("Vínculo já existe.");
            }
        }

        private bool verificarVinculo(int idAluno, int idResponsavel)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + projectPath + "\\ChegouBD.db"))
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    string strSql = "SELECT * FROM [Vinculo] WHERE [Aluno] IN ('" + idAluno + "')";
                    cmd.CommandText = strSql;
                    cmd.Connection = conn;
                    conn.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["Aluno"]) == idAluno && Convert.ToInt32(reader["Responsavel"]) == idResponsavel)
                        {
                            conn.Close();
                            return true;
                        }
                    }
                    conn.Close();
                    return false;
                }
            }
        }

        private void botaoVincular_Click(object sender, RoutedEventArgs e)
        {
            vincular(buscarIdAluno(), buscarIdResponsavel());
        }
    }
}
