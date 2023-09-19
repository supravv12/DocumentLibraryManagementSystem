using DocumentLibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentLibraryManagementSystem.DbOperations
{
    public class CategoryRepository
    {
        public int AddCategory(CategoryModel model)
        {
            using(var context = new DLMSDatabaseEntities())
            {
                Category cat = new Category()
                {
                    Name = model.Name,

                };

                context.Category.Add(cat);
                context.SaveChanges();
                return cat.Id;
            }
        }

        public List<CategoryModel> GetAllCategories()
        {
            using(var context = new DLMSDatabaseEntities())
            {
                var result = context.Category
                    .Select(x => new CategoryModel()
                    {
                        Id = x.Id,
                        Name = x.Name


                    }).ToList();

                return result;
            }

        }

        public CategoryModel GetCategory(int id)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var result = context.Category
                    .Where(x => x.Id == id)
                    .Select(x => new CategoryModel()
                    {
                        Id = x.Id,
                        Name = x.Name


                    }).FirstOrDefault();

                return result;
            }

        }

        public bool UpdateCategory(int id, CategoryModel model)
        {
            using(var context = new DLMSDatabaseEntities())
            {
                var category =  context.Category.FirstOrDefault(x => x.Id == id);
                if (category != null)
                {
                    category.Name = model.Name;
                }

                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteCategory(int id)
        {
            using(var context = new DLMSDatabaseEntities())
            {
                var category = context.Category.FirstOrDefault(x => x.Id == id);
                if (category != null)
                {
                    context.Category.Remove(category);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

    }
}