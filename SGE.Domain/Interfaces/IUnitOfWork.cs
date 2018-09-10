using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
