using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Entities
{
    public class Aluno
    {
        public int IdAluno { get; set; }
        public int IdEndereco { get; set; }
        public int IdTurma { get; set; }
        public int IdEscola { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual Turma Turma { get; set; }
        public virtual Escola Escola { get; set; }        
    }
}
