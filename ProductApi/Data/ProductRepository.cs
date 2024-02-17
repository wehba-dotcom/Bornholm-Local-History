using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ProductApi.Models;

namespace ProductApi.Data
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly AppDbContext db;

        public ProductRepository(AppDbContext context)
        {
            db = context;
        }

        Product IRepository<Product>.Add(Product entity)
        {
            var newProduct = db.Products.Add(entity).Entity;
            db.SaveChanges();
            return newProduct;
        }

        void IRepository<Product>.Edit(Product entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        Product IRepository<Product>.Get(int id)
        {
            return db.Products.FirstOrDefault(p => p.ID == id);
        }

        IEnumerable<Product> IRepository<Product>.GetAll()
        {
            return db.Products.ToList();
        }

        void IRepository<Product>.Remove(int id)
        {
            var product = db.Products.FirstOrDefault(p => p.ID == id);
            db.Products.Remove(product);
            db.SaveChanges();
        }
    }
}
