using System;

namespace EH.Interview.Todo.Models
{
    public class ToDoItem
    {
        private string description;
        private Guid id;

        public Guid ID { get { return id; } }
        public string Description { get { return description; } }

        public ToDoItem(string description)
        {
            this.id = Guid.NewGuid();
            this.description = description;
        }
    }
}
