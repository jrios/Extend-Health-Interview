using System;
using Caliburn.Micro;
using EH.Interview.Todo.Data;

namespace EH.Interview.Todo.ViewModels
{
    public class EditToDoItemViewModel : Screen
    {
        private string description;
        private readonly ToDoRepository repository;

        public EditToDoItemViewModel(ToDoRepository repository)
        {
            this.repository = repository;
        }

        public Guid ID
        {
            private get;
            set;
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                NotifyOfPropertyChange(() => Description);
                NotifyOfPropertyChange(() => CanEditItem);
            }
        }

        public bool CanEditItem
        {
            get { return !string.IsNullOrEmpty(Description); }
        }

        public void EditItem()
        {
            var item = repository.FindItem(ID);
            if (item != null)
                item.EditDescription(Description);
        }
    }
}
