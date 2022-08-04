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
    public class PostManager : IGenericService<Post>, IPostService
    {
        private IUnitOfWork db;
        public PostManager(IUnitOfWork db)
        {
            this.db = db;
        }
        public void Add(Post entity)
        {
            db.PostRepository.Add(entity);
        }

        public void Delete(Post entity)
        {
            db.PostRepository.Delete(entity);
        }

        public List<Post> GetAll()
        {
            return db.PostRepository.GetAll();
        }

        public Post GetById(int id)
        {
            return db.PostRepository.GetById(id);
        }

        public void Update(Post entity)
        {
            db.PostRepository.Update(entity);
        }
    }
}
