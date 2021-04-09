 using System;
using System.Linq;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UnitTestExc.Models;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Net;

namespace UnitTestExc.Controllers.Tests.AuthorServices
{
 public class AuthorControllerTests
    {
        Mock<IAuthorsService> _repoMock;
        AuthorController _AuthorController;
        public void Setup()
        {
            _repoMock = new Mock<IAuthorsService>();
            _AuthorController = new AuthorController(_repoMock.Object);
        }

        [Fact]
        public void GetMember_ReturnStatusCode_StatusOK()
        {
            // Arrange
             _repoMock.Setup(r=>r.GetAuthorById(It.IsAny<int>())).Returns(new Author() {  AuthorId = 1 ,FirstName="Dig",LastName="Dag"});
            //Act
            var result = _AuthorController.GetAuthor(1);
            //assert
            Assert.Equal(HttpStatusCode.OK, result);
        }
        [Fact]
        public void GetMember_ReturnStatusCode_StatusNotFound()
        {
            //Act
            var result = _AuthorController.GetAuthor(3);
            //assert
            Assert.Equal(HttpStatusCode.NotFound, result);
        }
    }
}