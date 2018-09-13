using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Entities
{
    public class Professor
    {
        public int IdProfessor { get; set; }
        public string Matricula { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public virtual IEnumerable<Trabalha> ListaDeTrabalho { get; set; }
        public virtual IEnumerable<ProfessorDisciplina> ListaDeDisciplinas { get; set; }
        
        public Professor()
        {
            ListaDeTrabalho = new List<Trabalha>();
            ListaDeDisciplinas = new List<ProfessorDisciplina>();
        }
    }
}
