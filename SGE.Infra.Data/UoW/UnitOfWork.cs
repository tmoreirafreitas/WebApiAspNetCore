using SGE.Domain.Interfaces;
using SGE.Infra.Data.Context;
using SGE.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SgeContext _context;
        private readonly IAlunoRepository _alunoRepository;        
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IEscolaRepository _escolaRepository;
        private readonly IProfessorDisciplinaRepository _professorDisciplinaRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly ITrabalhaRepository _trabalhaRepository;
        private readonly ITurmaDisciplinaRepository _turmaDisciplinaRepository;
        private readonly ITurmaEscolaRepository _turmaEscolaRepository;
        private readonly ITurmaRepository _turmaRepository;


        public UnitOfWork(SgeContext context)
        {
            _context = context;
        }

        public IAlunoRepository AlunoRepository => _alunoRepository ?? new AlunoRepository(_context);

        public IEnderecoRepository EnderecoRepository => _enderecoRepository ?? new EnderecoRepository(_context);

        public IEscolaRepository EscolaRepository => _escolaRepository ?? new EscolaRepository(_context);

        public IProfessorDisciplinaRepository ProfessorDisciplinaRepository => _professorDisciplinaRepository ?? new ProfessorDisciplinaRepository(_context);

        public IProfessorRepository ProfessorRepository => _professorRepository ?? new ProfessorRepository(_context);

        public ITrabalhaRepository TrabalhaRepository => _trabalhaRepository ?? new TrabalhaRepository(_context);

        public ITurmaDisciplinaRepository TurmaDisciplinaRepository => _turmaDisciplinaRepository ?? new TurmaDisciplinaRepository(_context);

        public ITurmaEscolaRepository TurmaEscolaRepository => _turmaEscolaRepository ?? new TurmaEscolaRepository(_context);

        public ITurmaRepository TurmaRepository => _turmaRepository ?? new TurmaRepository(_context);

        bool IUnitOfWork.Commit()
        {
            return _context.SaveChanges() > 0;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
