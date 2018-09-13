
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Entities
{
    public class Escola
    {
        public int IdEscola { get; set; }
        public int IdEndereco { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual IEnumerable<Trabalha> ListaDeTrabalhos { get; set; }
        public virtual IEnumerable<Aluno> ListaDeAlunos { get; set; }
        public virtual IEnumerable<TurmaEscola> ListaDeTurmas { get; set; }

        public Escola()
        {
            ListaDeTrabalhos = new List<Trabalha>();
            ListaDeAlunos = new List<Aluno>();
            ListaDeTurmas = new List<TurmaEscola>();
        }
    }
}
