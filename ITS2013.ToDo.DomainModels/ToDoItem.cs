using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2013.ToDo.DomainModels
{
    public class ToDoItem
    {
        public Guid ToDoItemId { get; set; }
        public DateTime DataOra { get; set; }
        public decimal Durata { get; set; }
        public string Cosa { get; set; }
        public string Dettaglio { get; set; }
        public StatoToDoItem Stato { get; set; }
    }
}
