

using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System.Collections.Generic;

namespace BLL.Services
{
    public class BookService
    {
        BookRepo repo;
        Mapper mapper;

        public BookService(BookRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public List<BookDTO> Get()
        {
            var data = repo.Get();
            var res = mapper.Map<List<BookDTO>>(data);
            return res;
        }

        public bool Create(BookDTO b)
        {
            var data = mapper.Map<Book>(b);
            return repo.Create(data);
        }




        public BookDTO Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<BookDTO>(data);
        }

        public bool Update(BookDTO b)
        {
            var data = mapper.Map<Book>(b);
            return repo.Update(data);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }


        public List<BookDTO> Search(string text)
        {
            var data = repo.Search(text);

            return mapper.Map<List<BookDTO>>(data);
        }
    }
}