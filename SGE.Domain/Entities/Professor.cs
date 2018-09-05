using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Entities
{
    public class Professor
    {
        public int IdProfessor { get; set; }
        public int IdContato { get; set; }
        public string Matricula { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }        
        public IEnumerable<Trabalha> ListaDeTrabalho { get; set; }
        public IEnumerable<ProfessorDisciplina> ListaDeDisciplinas { get; set; }
        public virtual Contato Contato { get; set; }

        public Professor()
        {
            ListaDeTrabalho = new List<Trabalha>();
            ListaDeDisciplinas = new List<ProfessorDisciplina>();
        }
    }
}
