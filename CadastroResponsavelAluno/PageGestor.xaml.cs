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
    /// Interação lógica para PageGestor.xam
    /// </summary>

    //Alterar caminho da imagem quando mudar para o projeto principal
    public partial class PageGestor : Page
    {
        public PageGestor()
        {
            InitializeComponent();
            BotaoListarAlunos_MouseLeftButtonUp(BotaoListarAlunos, null);
        }

        private void BotaoListarAlunos_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ResetarCorBotoes();
            AlterarCorBotaoListarAlunos();
        }

        private void BotaoCadastrarAluno_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ResetarCorBotoes();
            AlterarCorBotaoCadastrarAluno();
            FrameSecundario.Navigate(new PageCadastroAluno());
        }

        private void AlterarCorBotaoListarAlunos()
        {
            BotaoListarAlunos.BorderThickness = new Thickness(0, 0, 0, 3);
            ImageListarAlunos.Source = new BitmapImage(new Uri("pack://application:,,,/CadastroResponsavelAluno;component/Icons/Listar.png")); //Alterar caminho da imagem quando mudar para o projeto principal
            LabelListarAlunos.Foreground = (Brush)new BrushConverter().ConvertFromString("#0F0F0F");
            LabelListarAlunos.FontWeight = FontWeights.Bold;
        }

        private void AlterarCorBotaoCadastrarAluno()
        {
            BotaoCadastrarAluno.BorderThickness = new Thickness(0, 0, 0, 3);
            ImageCadastrarAluno.Source = new BitmapImage(new Uri("pack://application:,,,/CadastroResponsavelAluno;component/Icons/Adicionar.png")); //Alterar caminho da imagem quando mudar para o projeto principal
            LabelCadastrarAluno.Foreground = (Brush)new BrushConverter().ConvertFromString("#0F0F0F");
            LabelCadastrarAluno.FontWeight = FontWeights.Bold;
        }

        private void ResetarCorBotoes()
        {
            BotaoCadastrarAluno.BorderThickness = new Thickness(0, 0, 0, 0);
            ImageCadastrarAluno.Source = new BitmapImage(new Uri("pack://application:,,,/CadastroResponsavelAluno;component/Icons/AdicionarApagado.png")); //Alterar caminho da imagem quando mudar para o projeto principal
            LabelCadastrarAluno.Foreground = (Brush)new BrushConverter().ConvertFromString("#606060");
            LabelCadastrarAluno.FontWeight = FontWeights.Regular;

            BotaoListarAlunos.BorderThickness = new Thickness(0, 0, 0, 0);
            ImageListarAlunos.Source = new BitmapImage(new Uri("pack://application:,,,/CadastroResponsavelAluno;component/Icons/ListarApagado.png")); //Alterar caminho da imagem quando mudar para o projeto principal
            LabelListarAlunos.Foreground = (Brush)new BrushConverter().ConvertFromString("#606060");
            LabelListarAlunos.FontWeight = FontWeights.Regular;
        }
    }
}
