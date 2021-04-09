using System;
using System.Linq;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UnitTestExc.Models;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Xunit;

namespace UnitTestExc.Controllers.Tests
{
    
    public class BookServiceTests
    {
        // [SetUp]
        // public void SetUp()
        // {
        //     var mocking = new Mock<IBookServices>();
        //     // _bookServiceImplementation = new BookController(mocking.Object);
        // }
        
        [Fact]
        public async Task Get_AllBook_ReturnCount2()
        {
            var mocking = new Mock<IBookServices>();
            mocking.Setup(x => x.GetAll()).ReturnsAsync(FakeBookEntity());

            var controller = new BookController(mocking.Object);
            // ACT
            var result = await controller.Index();

            // Assert
            
             var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Book>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }
        private List<Book> FakeBookEntity()
        {
            return new List<Book>{
                new Book{
                    Title =  "a",
                    AuthorId =  1,
                },
                new Book{
                    Title =  "b",
                    AuthorId =  1,
                },
            };
        }   
    }
    
}