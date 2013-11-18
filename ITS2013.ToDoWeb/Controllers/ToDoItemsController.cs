using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITS2013.BestPractices;
using ITS2013.ToDo.DomainModels;
using ITS2013.ToDo.RavenSupport;
using ITS2013.ToDo.ReadModels;

namespace ITS2013.ToDoWeb.Controllers
{
    public class ToDoItemsController : Controller
    {
        private IRepository<ToDoItem> _repository;
        private ToDoAggregateRoot _aggregateRoot;
        private ToDoItemsDataContext _dataContext;

        public ToDoItemsController()
        {
            _repository = new RavenToDoItemRepository("ToDoDB");
            _aggregateRoot = new ToDoAggregateRoot(_repository);
            _dataContext = new ToDoItemsDataContext(_repository);
        }

        public ActionResult Index()
        {
            //var items = _dataContext.GetAllToDoItems();
            //return View(items);
            return View();
        }

        public JsonResult GetAllToDoItems()
        {
            var items = _dataContext.GetAllToDoItems();
            return Json(items, JsonRequestBehavior.AllowGet);
        }
    }
}
