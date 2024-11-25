using System;
using System.Collections.Generic;
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
using CadastroResponsavelAluno.Models;

namespace CadastroResponsavelAluno
{
    /// <summary>
    /// Interação lógica para PageCadastro.xam
    /// </summary>
    public partial class PageCadastro : Page
    {
        private ConexaoBD _conexao;
        public PageCadastro()
        {
            InitializeComponent();
            _conexao = new ConexaoBD();
        }

        private void Cadastrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CampoNome.Text) || string.IsNullOrWhiteSpace(CampoSenha.Password) || string.IsNullOrWhiteSpace(CampoCPF.Text) || string.IsNullOrWhiteSpace(ComboBoxCargo.Text))
                {
                    MessageBox.Show("Preencha os campos vazios!");
                }
                else if (CampoSenha.Password != CampoRepetirSenha.Password)
                {
                    MessageBox.Show("As senhas não coincidem.");
                }
                else if (CampoCPF.Text.Length != 11 || !CampoCPF.Text.All(char.IsDigit))
                {
                    MessageBox.Show("CPF inválido!");
                }
                else
                {
                    Usuario user = new Usuario(_conexao);
                    user.MetodoCadastro(CampoNome.Text, CampoSenha.Password, CampoCPF.Text, ComboBoxCargo.Text);
                    MessageBox.Show("Cadastrado com sucesso!");

                    CampoNome.Clear();
                    CampoSenha.Clear();
                    CampoRepetirSenha.Clear();
                    CampoCPF.Clear();
                    ComboBoxCargo.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }
        }

        private void CampoSenha_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //if (string.IsNullOrEmpty(CampoSenha.Password))
            //{
            //    LabelSenha.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    LabelSenha.Visibility = Visibility.Collapsed;
            //}
        }

        private void CampoRepetirSenha_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //if (string.IsNullOrEmpty(CampoRepetirSenha.Password))
            //{
            //    LabelRepetirSenha.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    LabelRepetirSenha.Visibility = Visibility.Collapsed;
            //}
        }

        private void ComboBoxCargo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (ComboBoxCargo.Text != null)
            //{
            //    labelCargo.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
            //    labelCargo.Visibility = Visibility.Visible;
            //}
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new PageLogin());
        }
    }
}
