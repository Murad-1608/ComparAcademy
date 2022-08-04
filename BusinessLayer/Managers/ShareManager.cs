using BusinessLayer.Services;
using DataAccessLayer.Abstractions;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managers
{
    public class ShareManager : IShareService
    {
        private IUnitOfWork db;
        public ShareManager(IUnitOfWork db)
        {
            this.db = db;
        }
        public void Add(Share entity)
        {
            db.ShareRepository.Add(entity);
        }

        public void Delete(Share entity)
        {
            db.ShareRepository.Delete(entity);
        }

        public List<Share> GetAll()
        {
            return db.ShareRepository.GetAll();
        }

        public Share GetById(int id)
        {
            return db.ShareRepository.GetById(id);
        }

        public List<Share> GetWithPostAndUser(int id)
        {
            return db.ShareRepository.GetWithPostAndUser(id);
        }

        public void Update(Share entity)
        {
            throw new NotImplementedException();
        }
    }
}
