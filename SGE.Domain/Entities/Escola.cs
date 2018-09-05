
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Entities
{
    public class Escola
    {
        public int IdEscola { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public int IdContato { get; set; }
        public virtual Contato Contato { get; set; }
        public Endereco Endereco { get; set; }
        public IEnumerable<Trabalha> ListaDeTrabalhos { get; set; }
        public IEnumerable<Aluno> ListaDeAlunos { get; set; }
        public IEnumerable<TurmaEscola> ListaDeTurmas { get; set; }

        public Escola()
        {
            ListaDeTrabalhos = new List<Trabalha>();
            ListaDeAlunos = new List<Aluno>();
            ListaDeTurmas = new List<TurmaEscola>();
        }
    }
}
