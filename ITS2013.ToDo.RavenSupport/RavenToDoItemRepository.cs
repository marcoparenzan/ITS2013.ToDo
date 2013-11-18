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
            ToDoItem item = null;
            using (var session = DocumentStore.OpenSession())
            {
                item = session.Load<ToDoItem>(id.ToString());
            }
            return item;
        }

        public void Update(ToDoItem item)
        {
            using (var session = DocumentStore.OpenSession())
            {
                session.Store(item, item.ToDoItemId.ToString());
                session.SaveChanges();
            }
        }

        public IQueryable<ToDoItem> Items
        {
            get
            {
                using (var session = DocumentStore.OpenSession())
                {
                    return session.Query<ToDoItem>();
                }
            }
        }
    }
}
