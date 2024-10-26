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
        MainWindow mainWindow;
        PageListaAlunos pageListaAlunos;
        PageCadastroAluno pageCadastroAluno;
        public PageGestor(MainWindow _mainWindow)
        {
            InitializeComponent();

            mainWindow = _mainWindow;
            pageListaAlunos = new PageListaAlunos(mainWindow);
            pageCadastroAluno = new PageCadastroAluno(mainWindow);

            BotaoListarAlunos_MouseLeftButtonUp(BotaoListarAlunos, null);
        }

        private void BotaoListarAlunos_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AlterarCorBotaoListarAlunos();
            pageListaAlunos.CarregarDados();
            FrameSecundario.Navigate(pageListaAlunos);
        }

        private void BotaoCadastrarAluno_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AlterarCorBotaoCadastrarAluno();
            FrameSecundario.Navigate(pageCadastroAluno);
        }

        private void AlterarCorBotaoListarAlunos()
        {
            ResetarCorBotoes();
            BotaoListarAlunos.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#0F0F0F");
            BotaoListarAlunos.BorderThickness = new Thickness(0, 0, 0, 3);
            ImageListarAlunos.Source = new BitmapImage(new Uri("pack://application:,,,/CadastroResponsavelAluno;component/Icons/Listar.png")); //Alterar caminho da imagem quando mudar para o projeto principal
            LabelListarAlunos.Foreground = (Brush)new BrushConverter().ConvertFromString("#0F0F0F");
            LabelListarAlunos.FontWeight = FontWeights.Bold;
        }

        private void AlterarCorBotaoCadastrarAluno()
        {
            ResetarCorBotoes();
            BotaoCadastrarAluno.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#0F0F0F");
            BotaoCadastrarAluno.BorderThickness = new Thickness(0, 0, 0, 3);
            ImageCadastrarAluno.Source = new BitmapImage(new Uri("pack://application:,,,/CadastroResponsavelAluno;component/Icons/Adicionar.png")); //Alterar caminho da imagem quando mudar para o projeto principal
            LabelCadastrarAluno.Foreground = (Brush)new BrushConverter().ConvertFromString("#0F0F0F");
            LabelCadastrarAluno.FontWeight = FontWeights.Bold;
        }

        private void ResetarCorBotoes()
        {
            BotaoListarAlunos.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#606060");
            BotaoListarAlunos.BorderThickness = new Thickness(0, 0, 0, 0);
            ImageListarAlunos.Source = new BitmapImage(new Uri("pack://application:,,,/CadastroResponsavelAluno;component/Icons/ListarApagado.png")); //Alterar caminho da imagem quando mudar para o projeto principal
            LabelListarAlunos.Foreground = (Brush)new BrushConverter().ConvertFromString("#606060");
            LabelListarAlunos.FontWeight = FontWeights.Regular;

            BotaoCadastrarAluno.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#606060");
            BotaoCadastrarAluno.BorderThickness = new Thickness(0, 0, 0, 0);
            ImageCadastrarAluno.Source = new BitmapImage(new Uri("pack://application:,,,/CadastroResponsavelAluno;component/Icons/AdicionarApagado.png")); //Alterar caminho da imagem quando mudar para o projeto principal
            LabelCadastrarAluno.Foreground = (Brush)new BrushConverter().ConvertFromString("#606060");
            LabelCadastrarAluno.FontWeight = FontWeights.Regular;
        }

        private void BotaoListarAlunos_MouseEnter(object sender, MouseEventArgs e)
        {
            if(BotaoListarAlunos.BorderBrush.ToString() != "#FF0F0F0F")
            {
                BotaoListarAlunos.BorderThickness = new Thickness(0, 0, 0, 3);
            }
        }

        private void BotaoListarAlunos_MouseLeave(object sender, MouseEventArgs e)
        {
            if (BotaoListarAlunos.BorderBrush.ToString() != "#FF0F0F0F")
            {
                BotaoListarAlunos.BorderThickness = new Thickness(0, 0, 0, 0);
            }
        }

        private void BotaoCadastrarAluno_MouseEnter(object sender, MouseEventArgs e)
        {
            if (BotaoCadastrarAluno.BorderBrush.ToString() != "#FF0F0F0F")
            {
                BotaoCadastrarAluno.BorderThickness = new Thickness(0, 0, 0, 3);
            }
        }

        private void BotaoCadastrarAluno_MouseLeave(object sender, MouseEventArgs e)
        {
            if (BotaoCadastrarAluno.BorderBrush.ToString() != "#FF0F0F0F")
            {
                BotaoCadastrarAluno.BorderThickness = new Thickness(0, 0, 0, 0);
            }
        }
    }
}
