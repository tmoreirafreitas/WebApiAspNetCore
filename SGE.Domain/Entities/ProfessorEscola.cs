using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Entities
{
    public class ProfessorEscola
    {
        public DateTime? Adimissao { get; set; }
        public int IdEscola { get; set; }
        public int IdProfessor { get; set; }
        public virtual Escola Escola { get; set; }
        public virtual Professor Professor { get; set; }
    }
}
