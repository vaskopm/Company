using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBackOffice.Repositories
{
    public interface IRepository<TEnt, in TPk> where TEnt : class
    {
        IEnumerable<TEnt> GetAll();
        TEnt Get(TPk id);
        void Add(TEnt entity);
        void Remove(TEnt entity);
        void Save();
        Task<int> SaveAsync();
    }
}
