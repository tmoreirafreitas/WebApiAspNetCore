using SGE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Endereco GetByCep(string cep);
    }
}
