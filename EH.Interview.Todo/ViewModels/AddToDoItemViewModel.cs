using Caliburn.Micro;
using EH.Interview.Todo.Data;
using EH.Interview.Todo.Models;

namespace EH.Interview.Todo.ViewModels
{
    public class AddToDoItemViewModel : PropertyChangedBase
    {
        private readonly ToDoRepository repository;
        private string description;

        public AddToDoItemViewModel(ToDoRepository repository)
        {
            this.repository = repository;
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                NotifyOfPropertyChange(() => Description);
                NotifyOfPropertyChange(() => CanAddItem);
            }
        }

        public bool CanAddItem
        {
            get { return !string.IsNullOrEmpty(Description); }
        }

        public void AddItem()
        {
            ToDoItem item = new ToDoItem(Description);
            repository.AddToDoItem(item);
        }

    }
}
