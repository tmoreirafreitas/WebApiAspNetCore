
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
        public Contato Contato { get; set; }
        public Endereco Endereco { get; set; }
        public IEnumerable<Professor> ListaDeProfessores { get; set; }
        public IEnumerable<Aluno> ListaDeAlunos { get; set; }
        public Escola()
        {
            ListaDeProfessores = new List<Professor>();
            ListaDeAlunos = new List<Aluno>();
        }
    }
}
