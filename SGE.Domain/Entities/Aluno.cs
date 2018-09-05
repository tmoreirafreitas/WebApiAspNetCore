using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Entities
{
    public class Aluno
    {
        public int IdAluno { get; set; }
        public int IdContato { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public Turma Turma { get; set; }
        public Escola Escola { get; set; }
        public virtual Contato Contato { get; set; }
    }
}
