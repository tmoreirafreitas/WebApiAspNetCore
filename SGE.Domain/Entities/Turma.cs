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
        public IEnumerable<Disciplina> ListaDeDisciplinas { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }

        public Turma()
        {
            ListaDeAlunos = new List<Aluno>();
            ListaDeDisciplinas = new List<Disciplina>();
        }
    }
}
