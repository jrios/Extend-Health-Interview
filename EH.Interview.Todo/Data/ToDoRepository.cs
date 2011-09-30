using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EH.Interview.Todo.Models;

namespace EH.Interview.Todo.Data
{
    public interface ToDoRepository
    {
        void AddToDoItem(ToDoItem item);
        void RemoveItem(ToDoItem item);
        IEnumerable<ToDoItem> LoadItems();
    }
}
