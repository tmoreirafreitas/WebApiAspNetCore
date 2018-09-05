using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Entities
{
    public class TurmaEscola
    {
        public int IdTurma { get; set; }
        public Turma Turma { get; set; }

        public int IdEscola { get; set; }       
        public Escola Escola { get; set; }
    }
}
