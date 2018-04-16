using System;
using DomainBook.Repository;

namespace DomainBook.UnitOfWork
{
    public interface IUnitOfWorkBook : IDisposable
    {
        IRepositoryBook RepositoryBook { get; }

        int Save();
    }
}