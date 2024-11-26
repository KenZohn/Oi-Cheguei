using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroResponsavelAluno.Models
{
    internal class Presenca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Id_Aluno { get; set; }
        public string Turma { get; set; }
        public string Data { get; set; }
        public string Hora_saida { get; set; }
        public bool Presente {  get; set; }


    }
}
