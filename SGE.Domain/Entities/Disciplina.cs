using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Entities
{
    public class Disciplina
    {
        public int IdDisciplina { get; set; }
        public string Ementa { get; set; }
        public int CargaHoraria { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public IEnumerable<ProfessorDisciplina> ListaDeProfessores { get; set; }
        public IEnumerable<TurmaDisciplina> ListaDeTurmas { get; set; }

        public Disciplina()
        {
            ListaDeProfessores = new List<ProfessorDisciplina>();
            ListaDeTurmas = new List<TurmaDisciplina>();
        }
    }
}
