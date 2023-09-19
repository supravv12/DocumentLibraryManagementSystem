using DocumentLibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentLibraryManagementSystem.DbOperations
{
    public class DocumentTypeRepository
    {
        public int AddDocumentType(DocumentTypeModel model)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                Document_Type dt = new Document_Type()
                {
                    Name = model.Name,

                };

                context.Document_Type.Add(dt);
                context.SaveChanges();
                return dt.Id;
            }
        }

        public List<DocumentTypeModel> GetAllDocumentTypes()
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var result = context.Document_Type
                    .Select(x => new DocumentTypeModel()
                    {
                        Id = x.Id,
                        Name = x.Name


                    }).ToList();

                return result;
            }

        }

        public DocumentTypeModel GetDocumentType(int id)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var result = context.Document_Type
                    .Where(x => x.Id == id)
                    .Select(x => new DocumentTypeModel()
                    {
                        Id = x.Id,
                        Name = x.Name


                    }).FirstOrDefault();

                return result;
            }

        }

        public bool UpdateDocumentType(int id, DocumentTypeModel model)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var dtype = context.Document_Type.FirstOrDefault(x => x.Id == id);
                if (dtype != null)
                {
                    dtype.Name = model.Name;
                }

                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteDocumentType(int id)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var dtype = context.Document_Type.FirstOrDefault(x => x.Id == id);
                if (dtype != null)
                {
                    context.Document_Type.Remove(dtype);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}