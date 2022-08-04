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
    public class UserManager : IUserService
    {
        private IUnitOfWork db;
        public UserManager(IUnitOfWork db)
        {
            this.db = db;
        }

        public void Add(User entity)
        {
            db.UserRepository.Add(entity);
        }

        public void Delete(User entity)
        {
            db.UserRepository.Delete(entity);
        }

        public List<User> GetAll()
        {
            return db.UserRepository.GetAll();
        }

        public User GetById(int id)
        {
            return db.UserRepository.GetById(id);
        }


        public void Update(User entity)
        {
            db.UserRepository.Update(entity);
        }
    }
}
