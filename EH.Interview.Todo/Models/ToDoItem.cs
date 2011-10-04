using System;
using Caliburn.Micro;

namespace EH.Interview.Todo.Models
{
    public class ToDoItem : PropertyChangedBase
    {
        private string description;
        private Guid id;

        public Guid ID { get { return id; } }
        public string Description { get { return description; } private set { description = value; NotifyOfPropertyChange(() => Description); } }

        public ToDoItem(string description)
        {
            this.id = Guid.NewGuid();
            this.description = description;
        }

        public void EditDescription(string newDescription)
        {
            this.Description = newDescription;
        }
    }
}
