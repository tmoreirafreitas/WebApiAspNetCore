using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Entities
{
    public class Turma
    {
        public int IdTurma { get; set; }
        public Turno Turno { get; set; }
        public string Sala { get; set; }
        public string Codigo { get; set; }
        public virtual IEnumerable<Aluno> ListaDeAlunos { get; set; }
        public virtual IEnumerable<TurmaDisciplina> ListaDeDisciplinas { get; set; }
        public virtual IEnumerable<TurmaEscola> ListaDeEscolas { get; set; }

        public Turma()
        {
            ListaDeAlunos = new List<Aluno>();
            ListaDeDisciplinas = new List<TurmaDisciplina>();
            ListaDeEscolas = new List<TurmaEscola>();
        }
    }
}
