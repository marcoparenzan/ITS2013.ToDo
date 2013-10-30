using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ITS2013.BestPractices;

namespace ITS2013.ToDo.DomainModels
{
    public class ToDoAggregateRoot
    {
        private IRepository<ToDoItem> _repository;

        public ToDoAggregateRoot(
            IRepository<ToDoItem> repository)
        {
            this._repository = repository;
        }

        public ToDoAggregateRoot Pianifica(
            DateTime quando
            , decimal perQuanto
            , CoseDaFare cosa
            , string dettaglio
        )
        {
            var nuova = new ToDoItem
            {
                ToDoItemId = Guid.NewGuid()
                ,
                DataOra = quando
                ,
                Durata = perQuanto
                ,
                Cosa = cosa.ToString()
                ,
                Stato = StatoToDoItem.DaFare
                ,
                Dettaglio = dettaglio
            };
            _repository.Add(nuova);
            return this;
        }

        public ToDoAggregateRoot Fatto(Guid id)
        {
            var esistente = _repository.Get(id);
            esistente.Stato = StatoToDoItem.Fatto;
            _repository.Update(esistente);
            return this;
        }

        public ToDoAggregateRoot Salta(Guid id)
        {
            var esistente = _repository.Get(id);
            esistente.Stato = StatoToDoItem.Saltato;
            _repository.Update(esistente);
            return this;
        }
    }
}
