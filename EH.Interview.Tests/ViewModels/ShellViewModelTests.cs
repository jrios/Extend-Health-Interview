using EH.Interview.Todo.Data;
using EH.Interview.Todo.ViewModels;
using NUnit.Framework;

namespace EH.Interview.Tests.ViewModels
{
    [TestFixture]
    public class shell_view_model
    {
        private ShellViewModel viewModelUnderTest;

        [SetUp]
        public void SetUp()
        {
            var repository = new ToDoInMemoryRepository();
            var addItemsViewModel = new AddToDoItemViewModel(repository);
            var todoListViewModel = new ToDoListViewModel(repository);

            this.viewModelUnderTest = new ShellViewModel(addItemsViewModel, todoListViewModel);
        }

        [Test]
        public void should_reload_to_do_items_when_item_is_added()
        {
            viewModelUnderTest.AddToDoItemsViewModel.Description = "Wash Dishes";
            viewModelUnderTest.AddToDoItemsViewModel.AddItem();

            Assert.AreEqual(1, viewModelUnderTest.ToDoListViewModel.ToDoItems.Count);
        }
    }
}
