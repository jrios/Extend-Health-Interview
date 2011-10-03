using Caliburn.Micro;
using EH.Interview.Todo.Data;
using EH.Interview.Todo.Models;
using System.ComponentModel.Composition;

namespace EH.Interview.Todo.ViewModels
{
    public class AddToDoItemViewModel : Screen
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
            //ToDoItem item = new ToDoItem(Description);
            //repository.AddToDoItem(item);
            //var items = repository.LoadItems();
  //          System.Windows.MessageBox.Show(string.Format("Number of items: {0}", items.Count());
            System.Windows.MessageBox.Show("Added item");

        }
    }
}
