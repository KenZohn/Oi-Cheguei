using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroResponsavelAluno.Models
{
    internal class HoraTempo
    {
        // Método para obter a data e hora atual
        public DateTime ObterDataHoraAtual()
        {
            return DateTime.Now;
        }

        // Método para formatar a data em um formato específico, se necessário
        public string ObterDataHoraFormatada()
        {
            return DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"); // Exemplo de formato
        }
    }
}
