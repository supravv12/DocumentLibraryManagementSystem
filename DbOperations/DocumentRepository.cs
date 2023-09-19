using DocumentLibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DocumentLibraryManagementSystem.DbOperations
{
    public class DocumentRepository
    {
        public int AddDocument(DocumentModel model)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                Document doc = new Document()
                {
                    Name = model.Name,
                    Category_Id = model.Category_Id,
                    Sub_Category_Id = model.Sub_Category_Id,
                    Document_Source_Id  = model.Document_Source_Id,
                    Document_Type_Id = model.Document_Type_Id,
                    State_Id = model.State_Id,
                    District_Id = model.District_Id,
                    Palika_Id = model.Palika_Id,
                    Fiscal_Year_Id = model.Fiscal_Year_Id

                };

                context.Document.Add(doc);
                context.SaveChanges();
                return doc.Id;
            }
        }

        public List<DocumentModel> GetAllDocuments()
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var result = context.Document
                    .Select(x => new DocumentModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Category_Id = x.Category_Id,
                        Category_Name = x.Category.Name,
                        Sub_Category_Id= x.Sub_Category_Id,
                        Sub_Category_Name =  x.Sub_Category.Name,
                        Document_Source_Id = x.Document_Source_Id,
                        Document_Source_Name = x.Document_Source.Name,
                        Document_Type_Id= x.Document_Type_Id,
                        Document_Type_Name = x.Document_Type.Name,
                        State_Id = x.State_Id,
                        State_Name =x.State.Name,
                        District_Id= x.District_Id,
                        District_Name = x.District.Name,
                        Palika_Id= x.Palika_Id,
                        Palika_Name = x.Palika.Name,
                        Fiscal_Year_Id = x.Fiscal_Year_Id,
                        Fiscal_Year_Name = x.Fiscal_Year.Name


                    }).ToList();

                return result;
            }

        }

        public DocumentModel GetDocument(int id)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var result = context.Document
                    .Where(x => x.Id == id)
                    .Select(x => new DocumentModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Category_Id = x.Category_Id,
                        Category_Name = x.Category.Name,
                        Sub_Category_Id = x.Sub_Category_Id,
                        Sub_Category_Name = x.Sub_Category.Name,
                        Document_Source_Id = x.Document_Source_Id,
                        Document_Source_Name = x.Document_Source.Name,
                        Document_Type_Id = x.Document_Type_Id,
                        Document_Type_Name = x.Document_Type.Name,
                        State_Id = x.State_Id,
                        State_Name = x.State.Name,
                        District_Id = x.District_Id,
                        District_Name = x.District.Name,
                        Palika_Id = x.Palika_Id,
                        Palika_Name = x.Palika.Name,
                        Fiscal_Year_Id = x.Fiscal_Year_Id,
                        Fiscal_Year_Name = x.Fiscal_Year.Name




                    }).FirstOrDefault();

                return result;
            }

        }

        public bool UpdateDocument(int id, DocumentModel model)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var doc = context.Document.FirstOrDefault(x => x.Id == id);
                if (doc != null)
                {
                    doc.Name = model.Name;
                    doc.Document_Source_Id = model.Document_Source_Id;
                    doc.Document_Type_Id = model.Document_Type_Id;
                    doc.Fiscal_Year_Id = model.Fiscal_Year_Id;
                    doc.Category_Id= model.Category_Id;
                    doc.Sub_Category_Id = model.Sub_Category_Id;
                    doc.State_Id = model.State_Id;
                    doc.District_Id = model.District_Id;
                    doc.Palika_Id = model.Palika_Id;
                    
                }

                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteDocument(int id)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var doc = context.Document.FirstOrDefault(x => x.Id == id);
                if (doc != null)
                {
                    context.Document.Remove(doc);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }



  


    }
}