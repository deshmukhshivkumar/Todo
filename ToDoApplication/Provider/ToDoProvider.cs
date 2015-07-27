using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoApplication.Models;

namespace ToDoApplication.Provider
{
    public class ToDoProvider
    {
        public ToDoProvider()
        {
            if (InSessionToDoList.Count == 0)
            {
                InSessionToDoList.Add(new ToDoViewModel()
                {
                    Title = "Test Note",
                    CreatedOn = new DateTime(2015,07,20),
                    Description = "This is test note",
                    Email = "sdeshmukh@tavisca.com",
                    Id = 1,
                    Priority = 1
                });
            }
        }

        public List<ToDoViewModel> InSessionToDoList
        {
            get
            {
                if (HttpContext.Current.Session["ToDoList"] == null)
                {
                    HttpContext.Current.Session["ToDoList"] = new List<ToDoViewModel>();
                }
                return (List<ToDoViewModel>) HttpContext.Current.Session["ToDoList"];
            }
            set { HttpContext.Current.Session["ToDoList"] = value; }
        }

        public bool Add(ToDoViewModel toDoViewModel)
        {
            toDoViewModel.Id = InSessionToDoList.Count +1;
            toDoViewModel.CreatedOn = DateTime.Now;
            InSessionToDoList.Add(toDoViewModel);
            return true;
        }

        public bool Remove(ToDoViewModel toDoViewModel)
        {
            var itemToRemove = InSessionToDoList.FirstOrDefault(td => td.Id == toDoViewModel.Id);

            if (itemToRemove == null)
                return false;

            InSessionToDoList.Remove(itemToRemove);
            return true;
        }

        public List<ToDoViewModel> GetAll()
        {
            return InSessionToDoList;
        }
    }
}