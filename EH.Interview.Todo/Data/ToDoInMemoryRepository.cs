using System;
using System.Collections.Generic;
using System.Linq;
using EH.Interview.Todo.Models;

namespace EH.Interview.Todo.Data
{
    public class ToDoInMemoryRepository : ToDoRepository
    {
        private IList<ToDoItem> items;

        public ToDoInMemoryRepository()
        {
            items = new List<ToDoItem>();
        }

        public void AddToDoItem(ToDoItem item)
        {
            items.Add(item);
        }

        public void RemoveItem(ToDoItem item)
        {
            items.Remove(item);
        }

        public IEnumerable<ToDoItem> LoadItems()
        {
            return items;
        }

        public ToDoItem FindItem(Guid id)
        {
            return items.FirstOrDefault(tdi => tdi.ID == id);
        }
    }
}
