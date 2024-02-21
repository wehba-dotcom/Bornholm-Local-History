using IdentityApi.Data;
using IdentityApi.Models;
using IdentityApi.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace IdentityApi.Service
{
    public class RepositoryAppUser : IRepositoryAppUser<ApplicationUser>
    {
        private readonly ApplicationDbContext _db;

        public RepositoryAppUser(ApplicationDbContext db)
        {
            _db = db;
        }
        public ApplicationUser Add(ApplicationUser entity)
        {
            var newUser = _db.ApplicationUsers.Add(entity).Entity;
            _db.SaveChanges();
            return newUser;
        }

        public void Edit(ApplicationUser entity)
        {

            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public ApplicationUser Get(string id)
        {
            return _db.ApplicationUsers.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _db.ApplicationUsers.ToList();
        }

       

        public void Remove(string id)
        {
            var applicationUser = _db.ApplicationUsers.FirstOrDefault(p => p.Id == id);
            _db.ApplicationUsers.Remove(applicationUser);
            _db.SaveChanges();
        }
    }
}
