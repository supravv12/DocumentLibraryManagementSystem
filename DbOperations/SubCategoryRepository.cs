using DocumentLibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentLibraryManagementSystem.DbOperations
{
    public class SubCategoryRepository
    {
        public int AddSubCategory(SubCategoryModel model)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                Sub_Category scat = new Sub_Category()
                {
                    Name = model.Name,
                    Category_Id = model.Category_Id

                };

                context.Sub_Category.Add(scat);
                context.SaveChanges();
                return scat.Id;
            }
        }

        public List<SubCategoryModel> GetAllSubCategories()
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var result = context.Sub_Category
                    .Select(x => new SubCategoryModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Category_Id = x.Category_Id,
                        Category_Name = x.Category.Name


                    }).ToList();

                return result;
            }

        }

        public SubCategoryModel GetSubCategory(int id)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var result = context.Sub_Category
                    .Where(x => x.Id == id)
                    .Select(x => new SubCategoryModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Category_Id = x.Category_Id,
                        Category_Name = x.Category.Name



                    }).FirstOrDefault();

                return result;
            }

        }

        public bool UpdateSubCategory(int id, SubCategoryModel model)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var subcategory = context.Sub_Category.FirstOrDefault(x => x.Id == id);
                if (subcategory != null)
                {
                    subcategory.Name = model.Name;
                    subcategory.Category_Id = model.Category_Id;
                }

                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteSubCategory(int id)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var subcategory = context.Sub_Category.FirstOrDefault(x => x.Id == id);
                if (subcategory != null)
                {
                    context.Sub_Category.Remove(subcategory);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

    }
}