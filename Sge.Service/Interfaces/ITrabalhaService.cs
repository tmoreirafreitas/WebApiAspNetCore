using Sge.Service.Validators;
using SGE.Domain.Entities;
using SGE.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Sge.Service.Interfaces
{
    public interface ITrabalhaService : IService<Trabalha, TrabalhaValidator>
    {
        IEnumerable<Trabalha> GetByDate(DateTime date);
    }
}
