using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using EH.Interview.Todo.ViewModels;
using EH.Interview.Todo.Data;

namespace EH.Interview.Tests.ViewModels
{
    [TestFixture]
    public class add_item_view_model
    {
        private ToDoRepository repository;
        private AddToDoItemViewModel viewModel;

        [SetUp]
        public void SetUp()
        {
            repository = new ToDoInMemoryRepository();
            viewModel = new AddToDoItemViewModel(repository);
        }

        [TearDown]
        public void TearDown()
        {
            viewModel = null;
        }

        [Test]
        public void should_not_allow_item_to_be_added_if_description_is_empty_string()
        {
            viewModel.Description = "";

            Assert.IsFalse(viewModel.CanAddItem);
        }

        [Test]
        public void should_now_allow_item_to_be_added_if_description_is_null()
        {
            viewModel.Description = null;

            Assert.IsFalse(viewModel.CanAddItem);
        }

        [Test]
        public void should_allow_item_to_be_added_if_description_is_string()
        {
            viewModel.Description = "Wash Dishes";

            Assert.IsTrue(viewModel.CanAddItem);
        }

        [Test]
        public void should_add_item_with_filled_description()
        {
            viewModel.Description = "Wash Dishes";
            viewModel.AddItem();

            var items = repository.LoadItems();
            Assert.AreEqual(1, items.Count());

        }
    }
}
