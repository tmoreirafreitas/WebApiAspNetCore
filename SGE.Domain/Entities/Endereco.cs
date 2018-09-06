﻿using System;
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
        public char[] UF { get; set; }
    }
}
