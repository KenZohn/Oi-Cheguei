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
    /// Interação lógica para PageListarAlunos.xam
    /// </summary>
    public partial class PageListaAlunos : Page
    {
        public PageListaAlunos()
        {
            InitializeComponent();
            CarregarDados();
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
                                Responsavel = reader["Responsavel"].ToString()
                            };
                            alunos.Add(aluno);
                        }
                    }
                }
            }
            DataGridAlunos.ItemsSource = alunos;
        }
    }
}
