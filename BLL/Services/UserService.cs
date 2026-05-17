using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;

namespace BLL.Services
{
    public class UserService
    {
        UserRepo repo;

        public UserService(UserRepo repo)
        {
            this.repo = repo;
        }

        public bool Register(UserDTO dto)
        {
            var mapper = MapperConfig.GetMapper();

            var data = mapper.Map<User>(dto);

            return repo.Register(data);
        }

        public UserDTO Login(string email, string password)
        {
            var data = repo.Login(email, password);

            if (data == null) return null;

            var mapper = MapperConfig.GetMapper();

            return mapper.Map<UserDTO>(data);
        }
    }
}