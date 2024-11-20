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
        public string CPFAluno { get; set; }
        public string CPFResponsavel { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string TelefoneTrabalho { get; set; }
        public string EnderecoTrabalho { get; set; }
        public string Autorizado1 { get; set; }
        public string Autorizado2 { get; set; }
        public string Autorizado3 { get; set; }
    }
}
