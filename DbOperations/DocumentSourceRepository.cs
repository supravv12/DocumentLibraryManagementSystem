using DocumentLibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentLibraryManagementSystem.DbOperations
{
    public class DocumentSourceRepository
    {
        public int AddDocumentSource(DocumentSourceModel model)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                Document_Source docsource = new Document_Source()
                {
                    Name = model.Name,

                };

                context.Document_Source.Add(docsource);
                context.SaveChanges();
                return docsource.Id;
            }
        }

        public List<DocumentSourceModel> GetAllDocumentSource()
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var result = context.Document_Source
                    .Select(x => new DocumentSourceModel()
                    {
                        Id = x.Id,
                        Name = x.Name


                    }).ToList();

                return result;
            }

        }

        public DocumentSourceModel GetDocumentSource(int id)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var result = context.Document_Source
                    .Where(x => x.Id == id)
                    .Select(x => new DocumentSourceModel()
                    {
                        Id = x.Id,
                        Name = x.Name


                    }).FirstOrDefault();

                return result;
            }

        }

        public bool UpdateDocumentSource(int id, DocumentSourceModel model)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var docsource = context.Document_Source.FirstOrDefault(x => x.Id == id);
                if (docsource != null)
                {
                    docsource.Name = model.Name;
                }

                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteDocumentSource(int id)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                var docsource = context.Document_Source.FirstOrDefault(x => x.Id == id);
                if (docsource != null)
                {
                    context.Document_Source.Remove(docsource);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}