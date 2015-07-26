using System.Web.Mvc;
using ToDoApplication.Models;
using ToDoApplication.Provider;

namespace ToDoApplication.Controllers
{
    public class ToDoController : Controller
    {
        ToDoProvider _toDoProvider = new ToDoProvider();
        public ActionResult ToDo()
        {
            return View();
        }
       
        public ActionResult Save(ToDoViewModel toDoViewModel)
        {
            _toDoProvider.Add(toDoViewModel);
            //return PartialView("Index", ToDoProvider.GetAll());
            return RedirectToAction("ToDo");
        }

        public ActionResult List()
        {
            return PartialView("Index", _toDoProvider.GetAll());
        }

        public void Delete(ToDoViewModel toDoViewModel)
        {
            _toDoProvider.Remove(toDoViewModel);

            RedirectToAction("List");
        }
    }
}
