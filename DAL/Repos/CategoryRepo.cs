using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class CategoryRepo
    {
        BookManagementContext db;
        public CategoryRepo(BookManagementContext db)
        {
            this.db = db;
        }
        public bool Create(Category c)
        {
            db.Categories.Add(c);
            return db.SaveChanges() > 0;
        }

        public List<Category> Get()
        {
            return db.Categories.ToList();
        }



        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public bool Update(Category c)
        {
            var exCategory = db.Categories.Find(c.Id);

            if (exCategory == null) return false;

            exCategory.Name = c.Name;

            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var category = db.Categories.Find(id);

            if (category == null) return false;

            db.Categories.Remove(category);

            return db.SaveChanges() > 0;
        }
    }
}
