using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Entities
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public int? Numero { get; set; }
        public string UF { get; set; }
        public virtual IEnumerable<Aluno> ListaDeAlunos { get; set; }
        public virtual IEnumerable<Escola> ListaDeEscolas { get; set; }

        public Endereco()
        {
            ListaDeAlunos = new List<Aluno>();
            ListaDeEscolas = new List<Escola>();
        }
    }
}
