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
    /// Interação lógica para Relacionamento.xam
    /// </summary>
    public partial class Relacionamento : Page
    {
        public Relacionamento()
        {
            InitializeComponent();
            campoRelacao.Items.Add("Pai/Mãe");
            campoRelacao.Items.Add("Tio/Tia");
            campoRelacao.Items.Add("Vô/Vó");
            campoRelacao.Items.Add("Outro");
        }
    }
}
