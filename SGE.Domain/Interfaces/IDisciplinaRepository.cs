﻿using SGE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Interfaces
{
    public interface IDisciplinaRepository : IRepository<Disciplina>
    {
        Disciplina GetByCodigo(string codigo);
    }
}
