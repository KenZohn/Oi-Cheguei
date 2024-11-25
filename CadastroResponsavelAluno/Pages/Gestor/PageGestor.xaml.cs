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
            AlterarCorBotaoListarAlunos();
            //pageListaAlunos.CarregarDados();
            FrameSecundario.Navigate(new PageListaAlunos());
        }

        private void BotaoCadastrarAluno_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AlterarCorBotaoCadastrarAluno();
            FrameSecundario.Navigate(new PageCadastroAluno());
        }

        private void BotaoListarUsuarios_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AlterarCorBotaoListarUsuarios();
            FrameSecundario.Navigate(new PageListaUsuarios());
        }

        private void BotaoCadastrarUsuario_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AlterarCorBotaoCadastrarUsuario();
            FrameSecundario.Navigate(new PageCadastro());
        }

        #region AlterarCorBotões
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

        private void AlterarCorBotaoListarUsuarios()
        {
            ResetarCorBotoes();
            BotaoListarUsuarios.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#0F0F0F");
            BotaoListarUsuarios.BorderThickness = new Thickness(0, 0, 0, 3);
            ImageListarUsuarios.Source = new BitmapImage(new Uri("pack://application:,,,/CadastroResponsavelAluno;component/Icons/Listar.png")); //Alterar caminho da imagem quando mudar para o projeto principal
            LabelListarUsuarios.Foreground = (Brush)new BrushConverter().ConvertFromString("#0F0F0F");
            LabelListarUsuarios.FontWeight = FontWeights.Bold;
        }

        private void AlterarCorBotaoCadastrarUsuario()
        {
            ResetarCorBotoes();
            BotaoCadastrarUsuario.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#0F0F0F");
            BotaoCadastrarUsuario.BorderThickness = new Thickness(0, 0, 0, 3);
            ImageCadastrarUsuario.Source = new BitmapImage(new Uri("pack://application:,,,/CadastroResponsavelAluno;component/Icons/Adicionar.png")); //Alterar caminho da imagem quando mudar para o projeto principal
            LabelCadastrarUsuario.Foreground = (Brush)new BrushConverter().ConvertFromString("#0F0F0F");
            LabelCadastrarUsuario.FontWeight = FontWeights.Bold;
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

            BotaoListarUsuarios.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#606060");
            BotaoListarUsuarios.BorderThickness = new Thickness(0, 0, 0, 0);
            ImageListarUsuarios.Source = new BitmapImage(new Uri("pack://application:,,,/CadastroResponsavelAluno;component/Icons/ListarApagado.png")); //Alterar caminho da imagem quando mudar para o projeto principal
            LabelListarUsuarios.Foreground = (Brush)new BrushConverter().ConvertFromString("#606060");
            LabelListarUsuarios.FontWeight = FontWeights.Regular;

            BotaoCadastrarUsuario.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#606060");
            BotaoCadastrarUsuario.BorderThickness = new Thickness(0, 0, 0, 0);
            ImageCadastrarUsuario.Source = new BitmapImage(new Uri("pack://application:,,,/CadastroResponsavelAluno;component/Icons/AdicionarApagado.png")); //Alterar caminho da imagem quando mudar para o projeto principal
            LabelCadastrarUsuario.Foreground = (Brush)new BrushConverter().ConvertFromString("#606060");
            LabelCadastrarUsuario.FontWeight = FontWeights.Regular;
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

        private void BotaoCadastrarUsuario_MouseEnter(object sender, MouseEventArgs e)
        {
            if (BotaoCadastrarUsuario.BorderBrush.ToString() != "#FF0F0F0F")
            {
                BotaoCadastrarUsuario.BorderThickness = new Thickness(0, 0, 0, 3);
            }
        }

        private void BotaoCadastrarUsuario_MouseLeave(object sender, MouseEventArgs e)
        {
            if (BotaoCadastrarUsuario.BorderBrush.ToString() != "#FF0F0F0F")
            {
                BotaoCadastrarUsuario.BorderThickness = new Thickness(0, 0, 0, 0);
            }
        }

        private void BotaoListarUsuarios_MouseEnter(object sender, MouseEventArgs e)
        {
            if (BotaoListarUsuarios.BorderBrush.ToString() != "#FF0F0F0F")
            {
                BotaoListarUsuarios.BorderThickness = new Thickness(0, 0, 0, 3);
            }
        }

        private void BotaoListarUsuarios_MouseLeave(object sender, MouseEventArgs e)
        {
            if (BotaoListarUsuarios.BorderBrush.ToString() != "#FF0F0F0F")
            {
                BotaoListarUsuarios.BorderThickness = new Thickness(0, 0, 0, 0);
            }
        }
        #endregion

        private void FrameSecundario_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                e.Cancel = true;
            }
        }
    }
}
