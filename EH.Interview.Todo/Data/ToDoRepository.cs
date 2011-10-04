using System;
using System.Collections.Generic;
using EH.Interview.Todo.Models;

namespace EH.Interview.Todo.Data
{
    public interface ToDoRepository
    {
        void AddToDoItem(ToDoItem item);
        void RemoveItem(ToDoItem item);
        IEnumerable<ToDoItem> LoadItems();
        ToDoItem FindItem(Guid id);
    }
}
