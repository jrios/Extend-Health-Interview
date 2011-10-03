using Caliburn.Micro;
using EH.Interview.Todo.Data;
using EH.Interview.Todo.Models;

namespace EH.Interview.Todo.ViewModels
{
    public class ShellViewModel : PropertyChangedBase, IShell 
    {
        private readonly ToDoRepository repository;
        private string description;

        public ShellViewModel(ToDoRepository repository)
        {
            this.repository = repository;
            ToDoItems = new BindableCollection<ToDoItem>();
        }

        public BindableCollection<ToDoItem> ToDoItems { get; private set; }

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
            Description = string.Empty;
            ReloadItems();
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
