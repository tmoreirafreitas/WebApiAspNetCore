using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Entities
{
    public class TurmaEscola
    {
        public int IdTurma { get; set; }      
        public int IdEscola { get; set; }       
        public virtual Escola Escola { get; set; }
        public virtual Turma Turma { get; set; }
    }
}
