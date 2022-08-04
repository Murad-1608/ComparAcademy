using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstractions
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IPostRepository PostRepository { get; }
        public IShareRepository ShareRepository { get; }
    }
}
