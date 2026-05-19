using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;

namespace BLL.Services
{
    public class UserService
    {
        UserRepo repo;
        Mapper mapper;

        public UserService(UserRepo repo)
        {
            this.repo = repo;

            mapper = MapperConfig.GetMapper();
        }

        public bool Register(UserDTO dto)
        {
            var data = mapper.Map<User>(dto);

            return repo.Register(data);
        }

        public UserDTO Login(string email, string password)
        {
            var data = repo.Login(email, password);

            if (data == null)
                return null;

            return mapper.Map<UserDTO>(data);
        }



        public List<UserDTO> GetUsers()
        {
            var data = repo.GetUsers();

            return mapper.Map<List<UserDTO>>(data);
        }

        public bool DeleteUser(int id)
        {
            return repo.DeleteUser(id);
        }
    }
}