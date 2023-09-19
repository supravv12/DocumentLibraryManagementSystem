using DocumentLibraryManagementSystem.Controllers;
using DocumentLibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentLibraryManagementSystem.DbOperations
{
    public class FiscalYearRepository
    {
        public int AddFiscalYear(FiscalYearModel model)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                Fiscal_Year fy = new Fiscal_Year()
                {
                    Name = model.Name,
                    Active = model.Active

                };

                context.Fiscal_Year.Add(fy);
                context.SaveChanges();
                return fy.Id;
            }
        }

        public List<FiscalYearModel> GetAllFiscalYear()
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var result = context.Fiscal_Year
                    .Select(x => new FiscalYearModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Active = x.Active


                    }).ToList();

                return result;
            }

        }

        public FiscalYearModel GetFiscalYear(int id)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var result = context.Fiscal_Year
                    .Where(x => x.Id == id)
                    .Select(x => new FiscalYearModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Active = x.Active


                    }).FirstOrDefault();

                return result;
            }

        }

        public bool UpdateFiscalYear(int id, FiscalYearModel model)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var fiscal = context.Fiscal_Year.FirstOrDefault(x => x.Id == id);
                if (fiscal != null)
                {
                    fiscal.Name = model.Name;
                    fiscal.Active = model.Active;
                }

                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteFiscalYear(int id)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var fiscal = context.Fiscal_Year.FirstOrDefault(x => x.Id == id);
                if (fiscal != null)
                {
                    context.Fiscal_Year.Remove(fiscal);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

       

    }
}