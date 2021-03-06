using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using TodoAppLive.Models;
using Xunit;

namespace TodoAppLive.Tests
{
    public class HomeControllerTests
    {
        private ITodoRepository repo;
        private HomeController underTest;

        public HomeControllerTests()
        {
            repo = Substitute.For<ITodoRepository>();
            underTest = new HomeController(repo);
        }
        [Fact]
        public void Index_Returns_A_View()
        {
            var result = underTest.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_Passes_Todos_To_View()
        {
            var expected = new List<Todo>();
          
            repo.GetAll().Returns(expected);

            var result = underTest.Index();
            var model = result.Model;


            Assert.Same(expected, model);
            //repo.Received().GetAll();
            //Assert that All Todos were passed into view
        }
        [Fact]
        public void Details_Gets_Correct_Todo()
        {
            var id = 1;
            underTest.Details(id);

            repo.Received().GetById(id);
        }

        [Fact]
        public void Details_Returns_A_View()
        {
            var id = 1;

            var result = underTest.Details(id);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Details_Returns_A_Correct_View()
        {
            var expectedModel = new Todo();
            var id = 1;
            repo.GetById(id).Returns(expectedModel);

            var result = underTest.Details(id);
            var model = result.Model;

            Assert.Same(expectedModel, model);
        }

        [Fact]
        public void Create_Returns_A_View()
        {
            var result = underTest.Create();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Create_Saves_Data()
        {
            var userTodoData = new Todo() { Description = "Hi", DueDate = DateTime.Now };
            underTest.Create(userTodoData);

            repo.Received().Create(userTodoData);
        }
        [Fact]
        public void Create_Redirects_To_Index()
        {
            var arbitraryTodo = new Todo();

            var result = underTest.Create(arbitraryTodo);

            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void Delete_Returns_A_View()
        {
            var idToDelete = 42;
 
            var result = underTest.Delete(idToDelete);

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Delete_Gets_The_Details()
        {
            var idToDelete = 42;
            var todoToDelete = new Todo();
            repo.GetById(idToDelete).Returns(todoToDelete);

            var result = underTest.Delete(idToDelete);
            var model = result.Model;

            Assert.Same(todoToDelete, model);
        }

        [Fact]
        public void DeleteConfirned_Deletes_Todo()
        {
            var id = 42;
            var toDelete = new Todo();
            repo.GetById(id).Returns(toDelete);

            var result = underTest.DeleteConfirmed(id);

            repo.Received().Delete(toDelete);
        }

        [Fact]
        public void DeleteConfirmed_Redirects_To_Home()
        {

            var result = underTest.DeleteConfirmed(1);

            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}
