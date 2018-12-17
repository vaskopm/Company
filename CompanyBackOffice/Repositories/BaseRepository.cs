using CompanyBackOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBackOffice.Repositories
{
    public abstract class BaseRepository<TEnt, TPk> : IDisposable, IRepository<TEnt, TPk> where TEnt : class
    {
        protected readonly CompanyDbContext context;

        public BaseRepository(CompanyDbContext context)
        {
            this.context = context;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
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

        public abstract IEnumerable<TEnt> GetAll();
        public abstract TEnt Get(TPk id);
        public abstract void Add(TEnt entity);
        public abstract void Remove(TEnt entity);
        public abstract void Save();
        public abstract Task<int> SaveAsync();
    }
}
