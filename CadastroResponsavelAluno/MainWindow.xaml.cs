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

    /* Dados do responsável:
         * Nome:
         * CPF:
         * Telefone:
         * Endereço:
         * Alunos por quem é responspavel:
         */
    //Fazer o CRUD
    public partial class MainWindow : Window
    {
        CadastroResponsavel cadastroResponsavel = new CadastroResponsavel();
        CadastroAluno cadastroAluno = new CadastroAluno();
        Relacionamento relacionamento = new Relacionamento();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void botaoCadastrarResponsavel_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(cadastroResponsavel);
        }

        private void botaoCadastrarAluno_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(cadastroAluno);
        }

        private void botaoRelacionar_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(relacionamento);
        }
    }
}
