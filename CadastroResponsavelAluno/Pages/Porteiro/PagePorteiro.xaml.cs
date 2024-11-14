using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Input;
using System;
using System.Windows.Media.Imaging;

namespace CadastroResponsavelAluno
{
    public partial class PagePorteiro : Page
    {
        public PagePorteiro()
        {
            InitializeComponent();

        }


        private void BotaoListarChamada_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AlterarCorBotaoListarChamada();
            //pageListaAlunos.CarregarDados();
            FrameSecundario.Navigate(new PageListaAlunos());
        }

        private void FrameSecundario_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                e.Cancel = true;
            }
        }
        private void AlterarCorBotaoListarChamada()
        {
            ResetarCorBotoes();
            BotaoListarChamada.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#0F0F0F");
            BotaoListarChamada.BorderThickness = new Thickness(0, 0, 0, 3);
            ImageListarChamada.Source = new BitmapImage(new Uri("pack://application:,,,/CadastroResponsavelAluno;component/Icons/Listar.png")); //Alterar caminho da imagem quando mudar para o projeto principal
            LabelListarChamada.Foreground = (Brush)new BrushConverter().ConvertFromString("#0F0F0F");
            LabelListarChamada.FontWeight = FontWeights.Bold;
        }
        private void ResetarCorBotoes()
        {
            BotaoListarChamada.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#606060");
            BotaoListarChamada.BorderThickness = new Thickness(0, 0, 0, 0);
            ImageListarChamada.Source = new BitmapImage(new Uri("pack://application:,,,/CadastroResponsavelAluno;component/Icons/ListarApagado.png")); //Alterar caminho da imagem quando mudar para o projeto principal
            LabelListarChamada.Foreground = (Brush)new BrushConverter().ConvertFromString("#606060");
            LabelListarChamada.FontWeight = FontWeights.Regular;

            
        }
        private void BotaoListarChamada_MouseEnter(object sender, MouseEventArgs e)
        {
            if (BotaoListarChamada.BorderBrush.ToString() != "#FF0F0F0F")
            {
                BotaoListarChamada.BorderThickness = new Thickness(0, 0, 0, 3);
            }
        }

        private void BotaoListarChamada_MouseLeave(object sender, MouseEventArgs e)
        {
            if (BotaoListarChamada.BorderBrush.ToString() != "#FF0F0F0F")
            {
                BotaoListarChamada.BorderThickness = new Thickness(0, 0, 0, 0);
            }
        }

    }
}
