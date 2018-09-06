using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAlunoRepository AlunoRepository { get; }
        IContatoRepository ContatoRepository { get; }
        IEnderecoRepository EnderecoRepository { get; }
        IEscolaRepository EscolaRepository { get; }
        IProfessorDisciplinaRepository ProfessorDisciplinaRepository { get; }
        IProfessorRepository ProfessorRepository { get; }
        ITrabalhaRepository TrabalhaRepository { get; }
        ITurmaDisciplinaRepository TurmaDisciplinaRepository { get; }
        ITurmaEscolaRepository TurmaEscolaRepository { get; }
        ITurmaRepository TurmaRepository { get; }
        bool Commit();
    }
}
