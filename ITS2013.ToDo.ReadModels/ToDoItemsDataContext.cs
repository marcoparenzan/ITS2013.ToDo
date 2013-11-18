using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITS2013.BestPractices;
using ITS2013.ToDo.DomainModels;

namespace ITS2013.ToDo.ReadModels
{
    public class ToDoItemsDataContext
    {
        private IRepository<ToDoItem> _repository;

        public ToDoItemsDataContext(IRepository<ToDoItem> repository)
        {
            this._repository = repository;
        }

        public IEnumerable<ToDoItemDTO> GetAllToDoItems()
        {
            return this
                ._repository
                .Items
                .Select(xx => new
                {
                    ToDoItemId = xx.ToDoItemId
                    ,
                    Stato = xx.Stato
                    ,
                    Cosa = xx.Cosa
                    ,
                    DataOra = xx.DataOra
                    ,
                    Durata = xx.Durata
                })
                .ToList()
                .Select(xx => new ToDoItemDTO
                {
                    ToDoItemId = xx.ToDoItemId
                    ,
                    Stato = xx.Stato.ToString()
                    ,
                    Cosa = xx.Cosa
                    ,
                    Data = xx.DataOra.ToShortDateString()
                    ,
                    Ora = xx.DataOra.ToShortTimeString()
                    ,
                    Durata = xx.Durata
                })
                ;
        }

        public ToDoItemDTO GetNextIncompleteItem()
        {
            var today = DateTime.Today;
            var tomorrow = today.Tomorrow();
            return this
                ._repository
                .Items
                .Where(xx => xx.Stato == StatoToDoItem.DaFare)
                .Where(xx => xx.DataOra < tomorrow)
                .OrderBy(xx => xx.DataOra)
                .Select(xx => new ToDoItemDTO
                {
                    ToDoItemId = xx.ToDoItemId
                    ,
                    Stato = xx.Stato.ToString()
                    ,
                    Cosa = xx.Cosa
                    ,
                    Data = xx.DataOra.ToShortDateString()
                    ,
                    Ora = xx.DataOra.ToShortTimeString()
                    ,
                    Durata = xx.Durata
                })
                .First();
        }

        public IEnumerable<ToDoItemDTO> GetAllUcompleteItemsUntilYesterday()
        {
            var today = DateTime.Today;
            return this
                ._repository
                .Items
                .Where(xx => xx.DataOra < today)
                .Where(xx => xx.Stato == StatoToDoItem.DaFare)
                .Select(xx => new
                {
                    ToDoItemId = xx.ToDoItemId
                    ,
                    Stato = xx.Stato
                    ,
                    Cosa = xx.Cosa
                    ,
                    DataOra = xx.DataOra
                    ,
                    Durata = xx.Durata
                })
                .ToList()
                .Select(xx => new ToDoItemDTO
                {
                    ToDoItemId = xx.ToDoItemId
                    ,
                    Stato = xx.Stato.ToString()
                    ,
                    Cosa = xx.Cosa
                    ,
                    Data = xx.DataOra.ToShortDateString()
                    ,
                    Ora = xx.DataOra.ToShortTimeString()
                    ,
                    Durata = xx.Durata
                })
                ;
        }

        public IEnumerable<ToDoItemDTO> GetAllUcompleteItemsToday()
        {
            var today = DateTime.Today;
            var tomorrow = today.Tomorrow();
            return this
                ._repository
                .Items
                .Where(xx => xx.DataOra >= today)
                .Where(xx => xx.DataOra < tomorrow)
                .Where(xx => xx.Stato == StatoToDoItem.DaFare)
                .Select(xx => new ToDoItemDTO
                {
                    ToDoItemId = xx.ToDoItemId
                    ,
                    Stato = xx.Stato.ToString()
                    ,
                    Cosa = xx.Cosa
                    ,
                    Data = xx.DataOra.ToShortDateString()
                    ,
                    Ora = xx.DataOra.ToShortTimeString()
                    ,
                    Durata = xx.Durata
                })
                .ToList();
        }
    }
}
