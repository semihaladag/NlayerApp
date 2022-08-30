using Nlayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _Context;

        public UnitOfWork(AppDbContext context
            )
        {
            _Context = context;
        }

        public void Commit()
        {
            _Context.SaveChanges(); 
        }

        public async Task CommitAsync()
        {
           await _Context.SaveChangesAsync();
        }
    }
}
