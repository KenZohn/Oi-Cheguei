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
    /// Interação lógica para MainWindow.xam
    /// </summary>
    
    //Alterar o ícone da janela
    public partial class MainWindow : Window
    {
        PageGestor pageGestor;
        PageProfessor pageProfessor;
        PagePorteiro pagePorteiro;
        public MainWindow()
        {
            InitializeComponent();

            pageGestor = new PageGestor(this);
            pageProfessor = new PageProfessor();
            pagePorteiro = new PagePorteiro();

            BotaoGestor_MouseLeftButtonUp(BotaoGestor, null);
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
            this.Close();
        }

        private void AlterarCorBotaoGestor()
        {
            ResetarCorBotoes();
            BotaoGestor.Background = (Brush)new BrushConverter().ConvertFromString("#E6E6E6");
        }

        private void AlterarCorBotaoProfessor()
        {
            ResetarCorBotoes();
            BotaoProfessor.Background = (Brush)new BrushConverter().ConvertFromString("#E6E6E6");
        }

        private void AlterarCorBotaoPorteiro()
        {
            ResetarCorBotoes();
            BotaoPorteiro.Background = (Brush)new BrushConverter().ConvertFromString("#E6E6E6");
        }

        private void ResetarCorBotoes()
        {
            BotaoGestor.Background = (Brush)new BrushConverter().ConvertFromString("#FFFFFF");
            BotaoProfessor.Background = (Brush)new BrushConverter().ConvertFromString("#FFFFFF");
            BotaoPorteiro.Background = (Brush)new BrushConverter().ConvertFromString("#FFFFFF");
        }

        private void BotaoGestor_MouseEnter(object sender, MouseEventArgs e)
        {
            if (BotaoGestor.Background.ToString() != "#FFE6E6E6")
            {
                BotaoGestor.Background = (Brush)new BrushConverter().ConvertFromString("#F2F2F2");
            }
        }

        private void BotaoGestor_MouseLeave(object sender, MouseEventArgs e)
        {
            if (BotaoGestor.Background.ToString() != "#FFE6E6E6")
            {
                BotaoGestor.Background = (Brush)new BrushConverter().ConvertFromString("#FFFFFF");
            }
        }

        private void BotaoProfessor_MouseEnter(object sender, MouseEventArgs e)
        {
            if (BotaoProfessor.Background.ToString() != "#FFE6E6E6")
            {
                BotaoProfessor.Background = (Brush)new BrushConverter().ConvertFromString("#F2F2F2");
            }
        }

        private void BotaoProfessor_MouseLeave(object sender, MouseEventArgs e)
        {
            if (BotaoProfessor.Background.ToString() != "#FFE6E6E6")
            {
                BotaoProfessor.Background = (Brush)new BrushConverter().ConvertFromString("#FFFFFF");
            }
        }

        private void BotaoPorteiro_MouseEnter(object sender, MouseEventArgs e)
        {
            if (BotaoPorteiro.Background.ToString() != "#FFE6E6E6")
            {
                BotaoPorteiro.Background = (Brush)new BrushConverter().ConvertFromString("#F2F2F2");
            }
        }

        private void BotaoPorteiro_MouseLeave(object sender, MouseEventArgs e)
        {
            if (BotaoPorteiro.Background.ToString() != "#FFE6E6E6")
            {
                BotaoPorteiro.Background = (Brush)new BrushConverter().ConvertFromString("#FFFFFF");
            }
        }

        private void BotaoSair_MouseEnter(object sender, MouseEventArgs e)
        {
            BotaoSair.Background = (Brush)new BrushConverter().ConvertFromString("#F2F2F2");
        }

        private void BotaoSair_MouseLeave(object sender, MouseEventArgs e)
        {
            BotaoSair.Background = (Brush)new BrushConverter().ConvertFromString("#FFFFFF");
        }
    }
}
