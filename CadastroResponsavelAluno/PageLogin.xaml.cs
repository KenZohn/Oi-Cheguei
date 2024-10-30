﻿using System;
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
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
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
                        MessageBox.Show("Login bem sucedido!");
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

        private void BotaoCadastrar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageCadastro());
        }
    }
}
