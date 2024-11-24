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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LoginCadastroDB
{
    /// <summary>
    /// Lógica interna para WindowCheguei.xaml
    /// </summary>
    public partial class WindowCheguei : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public WindowCheguei(string _aluno, string _responsavel)
        {
            InitializeComponent();
            DefinirChamada(_aluno, _responsavel);
            Temporizador();
        }

        private void DefinirChamada(string aluno, string responsavel)
        {
            nomeAluno.Text = aluno;
            nomeResponsavel.Text = responsavel;
        }

        private void Temporizador()
        {
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            this.Close();
        }


    }
}
