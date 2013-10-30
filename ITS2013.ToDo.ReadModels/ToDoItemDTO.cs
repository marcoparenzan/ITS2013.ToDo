using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2013.ToDo.ReadModels
{
    public class ToDoItemDTO
    {
        public Guid ToDoItemId { get; set; }
        public string Data { get; set; }
        public string Ora { get; set; }
        public decimal Durata { get; set; }
        public string Cosa { get; set; }
        public string Stato { get; set; }
    }
}
