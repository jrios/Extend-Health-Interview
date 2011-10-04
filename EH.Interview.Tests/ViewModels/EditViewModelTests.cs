using EH.Interview.Todo.Data;
using EH.Interview.Todo.ViewModels;
using NUnit.Framework;

namespace EH.Interview.Tests.ViewModels
{
    [TestFixture]
    public class edit_item_view_model
    {
        private ToDoRepository repository;
        private EditToDoItemViewModel viewModel;

        [SetUp]
        public void SetUp()
        {
            repository = new ToDoInMemoryRepository();
            viewModel = new EditToDoItemViewModel(repository);
        }

        [TearDown]
        public void TearDown()
        {
            viewModel = null;
        }

        [Test]
        public void should_not_allow_item_to_be_edited_if_description_is_empty_string()
        {
            viewModel.Description = "";

            Assert.IsFalse(viewModel.CanEditItem);
        }

        [Test]
        public void should_now_allow_item_to_be_edited_if_description_is_null()
        {
            viewModel.Description = null;

            Assert.IsFalse(viewModel.CanEditItem);
        }

        [Test]
        public void should_allow_item_to_be_edited_if_description_is_string()
        {
            viewModel.Description = "Wash Dishes";

            Assert.IsTrue(viewModel.CanEditItem);
        }
    }
}
