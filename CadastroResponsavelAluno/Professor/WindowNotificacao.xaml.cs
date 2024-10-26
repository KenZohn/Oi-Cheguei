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
using System.Windows.Shapes;

namespace CadastroResponsavelAluno.Professor
{
    /// <summary>
    /// Lógica interna para WindowNotificacao.xaml
    /// </summary>
    public partial class WindowNotificacao : Window
    {
        public WindowNotificacao()
        {
            InitializeComponent();
            this.Topmost = true;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
