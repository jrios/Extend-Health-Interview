using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using EH.Interview.Todo.Data;
using EH.Interview.Todo.ViewModels;
using EH.Interview.Todo.Models;

namespace EH.Interview.Tests.ViewModels
{
    [TestFixture]
    public class list_view_model
    {
        private ToDoRepository repository;
        private ToDoListViewModel viewModel;

        [SetUp]
        public void SetUp()
        {
            repository = new ToDoInMemoryRepository();
            viewModel = new ToDoListViewModel(repository);
        }

        [TearDown]
        public void TearDown()
        {
            viewModel = null;
        }

        [Test]
        public void collection_should_have_the_same_number_of_items_as_repository_when_reloaded()
        {
            add_single_item();

            viewModel.ReloadItems();

            var repositoryItems = repository.LoadItems();
            viewModel.ReloadItems();

            Assert.AreEqual(repositoryItems.Count(), viewModel.ToDoItems.Count);
        }

        [Test]
        public void should_be_able_to_remove_item_from_bindable_collection()
        {
            add_single_item();
            
            viewModel.ReloadItems();

            var itemToRemove = viewModel.ToDoItems.First();
            viewModel.RemoveItem(itemToRemove);

            Assert.IsEmpty(viewModel.ToDoItems);
        }

        private void add_single_item()
        {
            var addItemViewModel = new AddToDoItemViewModel(repository);
            addItemViewModel.Description = "Wash dishes";
            addItemViewModel.AddItem();
        }

        [Test]
        public void collection_should_have_the_same_number_of_items_as_repository_when_item_is_removed()
        {
            add_single_item();

            viewModel.ReloadItems();

            var itemToRemove = viewModel.ToDoItems.First();
            viewModel.RemoveItem(itemToRemove);

            var items = repository.LoadItems();

            Assert.AreEqual(items.Count(), viewModel.ToDoItems.Count);
        }
    }
}
