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
    /// Interação lógica para PageLogin.xam
    /// </summary>
    public partial class PageLogin : Page
    {
        private ConexaoBD _conexao;
        public PageLogin()
        {
            InitializeComponent();
            _conexao = new ConexaoBD();
            CampoLogin.Focus();
        }

        private void BotaoLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CampoLogin.Text) || string.IsNullOrWhiteSpace(CampoSenha.Password))
                {
                    MessageBox.Show("Preencha os campos vazios!");
                }
                else
                {
                    Usuario usuario = new Usuario(_conexao);
                    bool sucesso = usuario.MetodoLogin(CampoLogin.Text, CampoSenha.Password);
                    if (sucesso)
                    {
                        this.NavigationService.Navigate(new PagePrincipal(usuario.BuscarCargo(CampoLogin.Text, CampoSenha.Password)));
                    }
                    else
                    {
                        MessageBox.Show("Login ou senha incorretos!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void BotaoCadastrar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageCadastro());
        }

        private void CampoSenha_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CampoSenha.Password))
            {
                LabelSenha.Visibility = Visibility.Visible;
            }
            else
            {
                LabelSenha.Visibility = Visibility.Collapsed;
            }
        }

        private void CampoLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BotaoLogin_Click(BotaoLogin, e);
            }
        }

        private void CampoSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BotaoLogin_Click(BotaoLogin, e);
            }
        }
    }
}
