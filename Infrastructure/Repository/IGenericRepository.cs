using Nest;
using System;
namespace Infrastructure.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> Add(T data);
    }
}

