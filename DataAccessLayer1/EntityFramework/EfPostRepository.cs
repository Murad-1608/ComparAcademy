using DataAccessLayer.Abstractions;
using DataAccessLayer.Contrete;
using DataAccessLayer.Implementations;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfPostRepository : GenericRepository<Post>, IPostRepository
    {       
    }
}
