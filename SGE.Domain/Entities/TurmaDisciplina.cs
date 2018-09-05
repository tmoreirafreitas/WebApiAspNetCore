using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Entities
{
    public class TurmaDisciplina
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int IdTurma { get; set; }
        public int IdDisciplina { get; set; }
        public Turma Turma { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}
