using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Entities
{
    public class Trabalha
    {
        public DateTime? Adimissao { get; set; }
        public int IdEscola { get; set; }
        public int IdProfessor { get; set; }
        public Escola Escola { get; set; }
        public Professor Professor { get; set; }
    }
}
