using DataAccessLayer.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository => new EfUserRepository();

        public IPostRepository PostRepository => new EfPostRepository();

        public IShareRepository ShareRepository => new EfShareRepository();
    }
}
