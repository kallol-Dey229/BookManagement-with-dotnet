
using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System.Collections.Generic;

namespace BLL.Services
{
    public class CategoryService
    {
        CategoryRepo repo;
        Mapper mapper;

        public CategoryService(CategoryRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public List<CategoryDTO> Get()
        {
            var data = repo.Get();
            var res = mapper.Map<List<CategoryDTO>>(data);
            return res;
        }

        public bool Create(CategoryDTO c)
        {
            var data = mapper.Map<Category>(c);
            return repo.Create(data);
        }



        public CategoryDTO Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<CategoryDTO>(data);
        }

        public bool Update(CategoryDTO c)
        {
            var data = mapper.Map<Category>(c);
            return repo.Update(data);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }


}
