using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EH.Interview.Todo.Models;
using Caliburn.Micro;
using EH.Interview.Todo.Data;

namespace EH.Interview.Todo.ViewModels
{
    public class ToDoListViewModel
    {
        private readonly ToDoRepository repository;

        public BindableCollection<ToDoItem> ToDoItems { get; private set; }

        public ToDoListViewModel(ToDoRepository repository)
        {
            this.repository = repository;
            ToDoItems = new BindableCollection<ToDoItem>();
        }

        public void ReloadItems()
        {
            ToDoItems.Clear();
            var reloadedItems = repository.LoadItems();
            ToDoItems.AddRange(reloadedItems);
        }

        public void RemoveItem(ToDoItem itemToBeRemoved)
        {
            ToDoItems.Remove(itemToBeRemoved);
            repository.RemoveItem(itemToBeRemoved);
        }
    }
}
