using BLL.DTOs;
using DAL.Repos;

namespace BLL.Services
{
    public class DashboardService
    {
        BookRepo bookRepo;
        CategoryRepo categoryRepo;
        UserRepo userRepo;

        public DashboardService(
            BookRepo bookRepo,
            CategoryRepo categoryRepo,
            UserRepo userRepo)
        {
            this.bookRepo = bookRepo;
            this.categoryRepo = categoryRepo;
            this.userRepo = userRepo;
        }

        public DashboardDTO GetStatistics()
        {
            return new DashboardDTO
            {
                TotalBooks = bookRepo.GetBookCount(),

                TotalCategories =
                    categoryRepo.GetCategoryCount(),

                TotalUsers =
                    userRepo.GetUserCount()
            };
        }
    }
}