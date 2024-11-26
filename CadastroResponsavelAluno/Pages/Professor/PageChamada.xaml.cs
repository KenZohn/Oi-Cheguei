using CadastroResponsavelAluno.Models;
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

namespace CadastroResponsavelAluno
{
    /// <summary>
    /// Interação lógica para PageChamada.xam
    /// </summary>
    public partial class PageChamada : Page
    {
        public PageChamada()
        {
            InitializeComponent();

            AdicionarTurmas();
            ComboBoxTurma.SelectedIndex = 0;
            CarregarDados();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(DataGridChamada.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Nome", ListSortDirection.Ascending));
        }

        private void ComboBoxTurma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarregarDados();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(DataGridChamada.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Nome", ListSortDirection.Ascending));
        }

        public void CarregarDados()
        {
            List<Aluno> alunos = new List<Aluno>();

            using (SQLiteConnection conexao = new SQLiteConnection("Data Source=" + System.IO.Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "ChegouBD.db")))
            {
                conexao.Open();
                string strSql = "SELECT * FROM Alunos WHERE Turma = @turma";
                using (SQLiteCommand cmd = new SQLiteCommand(strSql, conexao))
                {
                    cmd.Parameters.AddWithValue("@turma", ComboBoxTurma.SelectedItem.ToString());

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Aluno aluno = new Aluno
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nome = reader["Nome"].ToString()
                            };
                            alunos.Add(aluno);
                        }
                    }
                }
            }
            DataGridChamada.ItemsSource = alunos;
        }

        private void AdicionarTurmas()
        {
            ComboBoxTurma.Items.Add("1º A");
            ComboBoxTurma.Items.Add("1º B");
            ComboBoxTurma.Items.Add("2º A");
            ComboBoxTurma.Items.Add("2º B");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PegarItensDataGrid();
        }

        private void SalvarPresenca(int Id_Aluno, bool isChecked, string Nome)
        {
            using (SQLiteConnection conexao = new SQLiteConnection("Data Source=" + System.IO.Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "ChegouBD.db")))
            {
                conexao.Open();
                string strSql = "INSERT INTO Presenca (Id_Aluno, Nome, Turma, Data, Presente) VALUES (@id, @nome, @turma, @data, @presente)";
                using (SQLiteCommand cmd = new SQLiteCommand(strSql, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", Id_Aluno);
                    cmd.Parameters.AddWithValue("@nome", Nome);
                    cmd.Parameters.AddWithValue("@turma", ComboBoxTurma.Text);
                    cmd.Parameters.AddWithValue("@data", DateTime.Today.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@presente", isChecked ? "1" : "0");
                    cmd.ExecuteNonQuery();
                }
                conexao.Close();
            }

        }

        private void PegarItensDataGrid()
        {
            foreach (var item in DataGridChamada.Items)
            {
                if (item is Aluno aluno )
                {  int Id_Aluno = aluno.Id ; 
                    bool isChecked = aluno.Presente;
                    string Nome = aluno.Nome ;
                    MessageBox.Show($"Aluno: ID={Id_Aluno}, Nome={Nome}, Presente={isChecked}");

                    if (isChecked)
                    {
                        SalvarPresenca(Id_Aluno, isChecked, Nome);
                    }
                } 
            } 
        }  
    }
}
