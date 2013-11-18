using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITS2013.BestPractices;
using ITS2013.ToDo.DomainModels;
using ITS2013.ToDo.ReadModels;

namespace ITS2013.ToDo.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository<ToDoItem> repository = 
                new RavenSupport.RavenToDoItemRepository("ToDoDB");
            var toDoAR = new ToDoAggregateRoot(repository);
            //var domani = DateTime.Today.Tomorrow();
            //toDoAR.Pianifica(
            //    domani.At(9) 
            //    ,
            //    4
            //    ,
            //    CoseDaFare.SviluppoSoftware
            //    ,
            //    "Strumento di marketing"
            //)
            //.Pianifica(
            //    domani.At(14,30)
            //    ,
            //    0.5M
            //    ,
            //    CoseDaFare.Appuntamento
            //    ,
            //    "Con Gigi"
            //)
            //.Pianifica(
            //    domani.At(16,30)
            //    ,
            //    1
            //    ,
            //    CoseDaFare.Formazione
            //    ,
            //    "Corso Javascript"
            //);

            var toDoDataContext = new ToDoItemsDataContext(repository);

            var items = toDoDataContext.GetAllToDoItems();
            foreach (var item in items)
            {
                System.Console.WriteLine(
                    "{0} {1} {2}"
                    , item.Data, item.Ora, item.Cosa
                );
                var toDoItem = repository.Get(item.ToDoItemId);
            }
            System.Console.ReadLine();
        }
    }
}
