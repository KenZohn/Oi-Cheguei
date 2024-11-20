using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroResponsavelAluno
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Turma { get; set; }
        public string Responsavel { get; set; }
        public int CPFAluno { get; set; }
        public int CPFResponsavel { get; set; }
        public string Telefone { get; set; }
    }
}
