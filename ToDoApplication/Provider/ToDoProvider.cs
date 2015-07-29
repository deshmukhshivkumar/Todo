using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoApplication.Models;

namespace ToDoApplication.Provider
{
    public class ToDoProvider
    {
       

        public List<ToDoViewModel> InSessionToDoList
        {
            get
            {
                if (HttpContext.Current.Session["ToDoList"] == null)
                {
                    HttpContext.Current.Session["ToDoList"] = new List<ToDoViewModel>();

                    if (InSessionToDoList.Count == 0)
                    {
                        InSessionToDoList.Add(new ToDoViewModel()
                        {
                            Title = "Test Note",
                            CreatedOn = new DateTime(2015, 07, 20),
                            Description = "This is test note",
                            Email = "sdeshmukh@tavisca.com",
                            Id = 1,
                            Priority = 1
                        });
                    }
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

        public bool Update(ToDoViewModel toDoViewModel)
        {
            var existingItem = InSessionToDoList.Find(istodo => istodo.Id == toDoViewModel.Id);

            if (existingItem != null)
            {
                existingItem.Title = toDoViewModel.Title;
                existingItem.Description = toDoViewModel.Description;
                existingItem.Email = toDoViewModel.Email;
                existingItem.Priority = toDoViewModel.Priority;
                return true;
            }
            return false;
        }

        public bool Remove(int id)
        {
            var itemToRemove = InSessionToDoList.FirstOrDefault(td => td.Id == id);

            if (itemToRemove == null)
                return false;

            InSessionToDoList.Remove(itemToRemove);
            return true;
        }

        public ToDoViewModel Get(int id)
        {
            return InSessionToDoList.Find(todo => todo.Id == id);
        }

        public List<ToDoViewModel> GetAll()
        {
            return InSessionToDoList;
        }
    }
}