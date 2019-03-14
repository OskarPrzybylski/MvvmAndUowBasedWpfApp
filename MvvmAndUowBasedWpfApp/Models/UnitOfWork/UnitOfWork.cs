using MvvmAndUowBasedWpfApp.Models.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmAndUowBasedWpfApp.Models.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        #region Fields
        private readonly DatabaseContext _databaseContext;
        private bool disposed = false;
        #endregion
        #region Constructors
        public UnitOfWork(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        #endregion
        #region Properties
        
        #endregion
        #region Methods
        public void Save() => this._databaseContext.SaveChanges();

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _databaseContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
