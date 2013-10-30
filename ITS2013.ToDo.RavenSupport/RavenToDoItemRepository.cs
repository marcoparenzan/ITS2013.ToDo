using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITS2013.BestPractices;
using ITS2013.ToDo.DomainModels;
using Raven.Client.Document;

namespace ITS2013.ToDo.RavenSupport
{
    public class RavenToDoItemRepository: 
        IRepository<ToDoItem>
    {
        private string _connectionStringName;

        public RavenToDoItemRepository(string connectionStringName)
        {
            this._connectionStringName = connectionStringName;
        }

        private DocumentStore _documentStore;

        public DocumentStore DocumentStore
        {
            get {
                if (_documentStore == null)
                {
                    _documentStore = new DocumentStore
                    {
                        ConnectionStringName = this._connectionStringName
                    };
                    _documentStore.Initialize();
                }
                return _documentStore; 
            }
        }

        public void Add(ToDoItem item)
        {
            using (var session = DocumentStore.OpenSession())
            {
                session.Store(item, item.ToDoItemId.ToString());
                session.SaveChanges();
            }
        }

        public ToDoItem Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(ToDoItem item)
        {
            throw new NotImplementedException();
        }
    }
}
