using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitTestExc.Models;
namespace UnitTestExc.Controllers.Tests.AuthorServices{
 public interface IAuthorsService
    {
        List<Author> GetAuthor();
        Author AddAuthor(Author author);
        Author GetAuthorById(int id);

    }
}