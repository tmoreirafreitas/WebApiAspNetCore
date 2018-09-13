using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Entities
{
    public class ProfessorDisciplina
    {
        public int IdProfessor { get; set; }
        public int IdDisciplina { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual Disciplina Disciplina { get; set; }
    }
}
