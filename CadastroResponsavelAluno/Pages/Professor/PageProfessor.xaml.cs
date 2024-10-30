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
using CadastroResponsavelAluno.Professor;

namespace CadastroResponsavelAluno
{
    /// <summary>
    /// Interação lógica para PageProfessor.xam
    /// </summary>
    public partial class PageProfessor : Page
    {
        PageChamada pageChamada;
        public PageProfessor()
        {
            InitializeComponent();

            pageChamada = new PageChamada();

            BotaoChamada_MouseLeftButtonUp(BotaoChamada, null);
        }

        private void BotaoChamada_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AlterarCorBotaoChamada();
            FrameSecundario.Navigate(pageChamada);
        }

        private void BotaoNotificacao_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WindowNotificacao windowNotificacao = new WindowNotificacao();
            windowNotificacao.ShowDialog();
        }

        private void AlterarCorBotaoChamada()
        {
            BotaoChamada.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#0F0F0F");
            BotaoChamada.BorderThickness = new Thickness(0, 0, 0, 3);
            ImageChamada.Source = new BitmapImage(new Uri("pack://application:,,,/CadastroResponsavelAluno;component/Icons/Listar.png")); //Alterar caminho da imagem quando mudar para o projeto principal
            LabelChamada.Foreground = (Brush)new BrushConverter().ConvertFromString("#0F0F0F");
            LabelChamada.FontWeight = FontWeights.Bold;
        }

        private void BotaoNotificacao_MouseEnter(object sender, MouseEventArgs e)
        {
                BotaoNotificacao.BorderThickness = new Thickness(0, 0, 0, 3);
        }

        private void BotaoNotificacao_MouseLeave(object sender, MouseEventArgs e)
        {
                BotaoNotificacao.BorderThickness = new Thickness(0, 0, 0, 0);
        }
    }
}
