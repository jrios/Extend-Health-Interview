using System;

namespace EH.Interview.Todo.ViewModels
{
    public class ShellViewModel : IShell 
    {
        public AddToDoItemViewModel AddToDoItemsViewModel { get; private set; }
        public ToDoListViewModel ToDoListViewModel { get; private set; }

        public ShellViewModel(AddToDoItemViewModel addItemsViewModel, ToDoListViewModel listViewModel)
        {
            AddToDoItemsViewModel = addItemsViewModel;
            ToDoListViewModel = listViewModel;

            AddToDoItemsViewModel.ItemAdded += ItemAdded;
        }

        void ItemAdded(object sender, EventArgs e)
        {
            ToDoListViewModel.ReloadItems();
        }
    }
}
