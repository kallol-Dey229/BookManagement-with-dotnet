using DAL.EF;
using DAL.EF.Tables;
using System.Linq;

namespace DAL.Repos
{
    public class UserRepo
    {
        BookManagementContext db;

        public UserRepo(BookManagementContext db)
        {
            this.db = db;
        }

        public bool Register(User u)
        {
            db.Users.Add(u);
            return db.SaveChanges() > 0;
        }

        public User Login(string email, string password)
        {
            return db.Users
                     .FirstOrDefault(x => x.Email == email && x.Password == password);
        }


        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }

        public bool DeleteUser(int id)
        {
            var user = db.Users.Find(id);

            db.Users.Remove(user);

            return db.SaveChanges() > 0;
        }
    }
}