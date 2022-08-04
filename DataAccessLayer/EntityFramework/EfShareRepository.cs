using DataAccessLayer.Abstractions;
using DataAccessLayer.Contrete;
using DataAccessLayer.Implementations;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfShareRepository : GenericRepository<Share>, IShareRepository
    {
        public List<Share> GetWithPostAndUser(int id)
        {
            using (Context db = new Context())
            {
                var values = db.Shares.Where(x => x.RecipientID == id).Include(x => x.Recipient).Include(x => x.Post).ToList();
                return values;
            }
        }
    }
}
