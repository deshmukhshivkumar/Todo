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
            return View(new ToDoViewModel());
        }
               
        public ActionResult Save(ToDoViewModel toDoViewModel)
        {
            if (toDoViewModel.Id == 0)
                _toDoProvider.Add(toDoViewModel);
            else
                _toDoProvider.Update(toDoViewModel);
            return RedirectToAction("ToDo");
        }

        public ActionResult List()
        {
            return PartialView("Index", _toDoProvider.GetAll());
        }

        public ActionResult Delete(int id)
        {
            _toDoProvider.Remove(id);

            return RedirectToAction("ToDo", _toDoProvider.GetAll());
        }

        public ActionResult Edit(int id)
        {
            return View("ToDo", _toDoProvider.Get(id));
        }
    }
}
