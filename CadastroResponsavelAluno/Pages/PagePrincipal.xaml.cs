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

namespace CadastroResponsavelAluno
{
    /// <summary>
    /// Interação lógica para PagePrincipal.xam
    /// </summary>

    //Função do botão sair para voltar pra tela de login
    public partial class PagePrincipal : Page
    {

        PageGestor pageGestor;
        PageProfessor pageProfessor;
        PagePorteiro pagePorteiro;
        public PagePrincipal(string cargo)
        {
            InitializeComponent();

            pageGestor = new PageGestor();
            pageProfessor = new PageProfessor();
            pagePorteiro = new PagePorteiro();

            AlterarAcesso(cargo);
        }

        private void BotaoGestor_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AlterarCorBotaoGestor();
            FramePrincipal.Navigate(pageGestor);
        }

        private void BotaoProfessor_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AlterarCorBotaoProfessor();
            FramePrincipal.Navigate(pageProfessor);
        }

        private void BotaoPorteiro_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AlterarCorBotaoPorteiro();
            FramePrincipal.Navigate(pagePorteiro);
        }

        private void BotaoSair_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new PageLogin());
        }

        private void AlterarAcesso(string cargo)
        {
            if (cargo == "Coordenação/Direção")
            {
                BotaoGestor_MouseLeftButtonUp(BotaoGestor, null);
            }
            if (cargo == "Professor")
            {
                BotaoGestor.Visibility = Visibility.Collapsed;
                BotaoPorteiro.Visibility = Visibility.Collapsed;
                BotaoProfessor_MouseLeftButtonUp(BotaoProfessor, null);
            }
            else if (cargo == "Portaria")
            {
                BotaoGestor.Visibility = Visibility.Collapsed;
                BotaoProfessor.Visibility = Visibility.Collapsed;
                BotaoPorteiro_MouseLeftButtonUp(BotaoPorteiro, null);
            }
        }

        #region AlterarCorBotão
        private void AlterarCorBotaoGestor()
        {
            ResetarCorBotoes();
            BotaoGestor.Background = (Brush)new BrushConverter().ConvertFromString("#6AADE4");
        }

        private void AlterarCorBotaoProfessor()
        {
            ResetarCorBotoes();
            BotaoProfessor.Background = (Brush)new BrushConverter().ConvertFromString("#6AADE4");
        }

        private void AlterarCorBotaoPorteiro()
        {
            ResetarCorBotoes();
            BotaoPorteiro.Background = (Brush)new BrushConverter().ConvertFromString("#6AADE4");
        }

        private void ResetarCorBotoes()
        {
            BotaoGestor.Background = (Brush)new BrushConverter().ConvertFromString("#0A88EE");
            BotaoProfessor.Background = (Brush)new BrushConverter().ConvertFromString("#0A88EE");
            BotaoPorteiro.Background = (Brush)new BrushConverter().ConvertFromString("#0A88EE");
        }

        private void BotaoGestor_MouseEnter(object sender, MouseEventArgs e)
        {
            if (BotaoGestor.Background.ToString() != "#FF6AADE4")
            {
                BotaoGestor.Background = (Brush)new BrushConverter().ConvertFromString("#0A76CE");
            }
        }
        private void BotaoGestor_MouseLeave(object sender, MouseEventArgs e)
        {
            if (BotaoGestor.Background.ToString() != "#FF6AADE4")
            {
                BotaoGestor.Background = (Brush)new BrushConverter().ConvertFromString("#0A88EE");
            }
        }
        private void BotaoProfessor_MouseEnter(object sender, MouseEventArgs e)
        {
            if (BotaoProfessor.Background.ToString() != "#FF6AADE4")
            {
                BotaoProfessor.Background = (Brush)new BrushConverter().ConvertFromString("#0A76CE");
            }
        }
        private void BotaoProfessor_MouseLeave(object sender, MouseEventArgs e)
        {
            if (BotaoProfessor.Background.ToString() != "#FF6AADE4")
            {
                BotaoProfessor.Background = (Brush)new BrushConverter().ConvertFromString("#0A88EE");
            }
        }
        private void BotaoPorteiro_MouseEnter(object sender, MouseEventArgs e)
        {
            if (BotaoPorteiro.Background.ToString() != "#FF6AADE4")
            {
                BotaoPorteiro.Background = (Brush)new BrushConverter().ConvertFromString("#0A76CE");
            }
        }
        private void BotaoPorteiro_MouseLeave(object sender, MouseEventArgs e)
        {
            if (BotaoPorteiro.Background.ToString() != "#FF6AADE4")
            {
                BotaoPorteiro.Background = (Brush)new BrushConverter().ConvertFromString("#0A88EE");
            }
        }
        private void BotaoSair_MouseEnter(object sender, MouseEventArgs e)
        {
            BotaoSair.Background = (Brush)new BrushConverter().ConvertFromString("#0A76CE");
        }
        private void BotaoSair_MouseLeave(object sender, MouseEventArgs e)
        {
            BotaoSair.Background = (Brush)new BrushConverter().ConvertFromString("#0A88EE");
        }
        #endregion

        private void FramePrincipal_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                e.Cancel = true;
            }
        }
    }
}
