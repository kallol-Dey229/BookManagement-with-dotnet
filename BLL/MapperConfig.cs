using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;

namespace BLL
{
    public class MapperConfig
    {
        static MapperConfiguration cfg = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Category, CategoryDTO>().ReverseMap();
            cfg.CreateMap<Book, BookDTO>().ReverseMap();
            cfg.CreateMap<User, UserDTO>().ReverseMap();

        });

        public static Mapper GetMapper()
        {
            return new Mapper(cfg);
        }

       

    }
}
