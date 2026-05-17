using DAL.EF;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class BookRepo
    {
        BookManagementContext db;
        public BookRepo(BookManagementContext db)
        {
            this.db = db;
        }
        public bool Create(Book b)
        {
            db.Books.Add(b);
            return db.SaveChanges() > 0;
        }

        public List<Book> Get()
        {
            return db.Books.ToList();
        }






        //.......................

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        public bool Update(Book b)
        {
            var exbook = db.Books.Find(b.Id);

            exbook.Title = b.Title;
            exbook.Price = b.Price;
            exbook.Cid = b.Cid;

            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var book = db.Books.Find(id);

            db.Books.Remove(book);

            return db.SaveChanges() > 0;
        }

    }
}
