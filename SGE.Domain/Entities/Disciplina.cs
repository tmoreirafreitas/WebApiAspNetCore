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
        public virtual IEnumerable<Professor> ListaDeProfessores { get; set; }
        public virtual IEnumerable<Turma> ListaDeTurmas { get; set; }

        public Disciplina()
        {
            ListaDeProfessores = new List<Professor>();
            ListaDeTurmas = new List<Turma>();
        }
    }
}
