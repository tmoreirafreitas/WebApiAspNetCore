using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Entities
{
    public class Professor
    {
        public int IdProfessor { get; set; }
        public string Matricula { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public Contato Contato { get; set; }
        public DateTime? Adimissao { get; set; }
        public virtual IEnumerable<Escola> ListaDeEscolas { get; set; }
        public IEnumerable<Disciplina> ListaDeDisciplinas { get; set; }

        public Professor()
        {
            ListaDeEscolas = new List<Escola>();
            ListaDeDisciplinas = new List<Disciplina>();
        }
    }
}
