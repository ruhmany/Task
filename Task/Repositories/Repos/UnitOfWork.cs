using IRepositories.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbcontxt;

        public UnitOfWork(ApplicationDbContext dbcontxt)
        {
            _dbcontxt = dbcontxt;
        }

        public int CommitChanges()
        {
            return _dbcontxt.SaveChanges();
        }
    }
}
