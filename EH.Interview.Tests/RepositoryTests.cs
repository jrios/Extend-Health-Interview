using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using EH.Interview.Todo.Data;
using EH.Interview.Todo.Models;

namespace EH.Interview.Tests
{
    [TestFixture]
    public class in_memory_repository
    {
        private ToDoRepository repository;

        [SetUp]
        public void SetUp()
        {
            repository = new ToDoInMemoryRepository();
        }

        [Test]
        public void should_default_to_empty_list()
        {
            var items = repository.LoadItems();

            Assert.AreEqual(0, items.Count());
        }

        [Test]
        public void should_have_one_item_in_list_when_single_item_added()
        {
            var toDoItem = new ToDoItem("Wash Dishes");
            repository.AddToDoItem(toDoItem);
            var items = repository.LoadItems();

            Assert.AreEqual(1, items.Count());
        }

        [Test]
        public void should_have_multiple_items_in_list_when_multiple_items_added()
        {
            var itemOne = new ToDoItem("Wash dishes");
            var itemTwo = new ToDoItem("Take out garbage");

            repository.AddToDoItem(itemOne);
            repository.AddToDoItem(itemTwo);

            var items = repository.LoadItems();

            Assert.Greater(items.Count(), 1);
        }

        [Test]
        public void should_have_zero_items_when_single_item_is_removed()
        {
            var item = new ToDoItem("Wash dishes");
            repository.AddToDoItem(item);

            repository.RemoveItem(item);

            var items = repository.LoadItems();

            Assert.AreEqual(0, items.Count());
        }
    }
}
