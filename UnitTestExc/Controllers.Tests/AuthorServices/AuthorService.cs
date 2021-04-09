using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitTestExc.Models;
namespace UnitTestExc.Controllers.Tests.AuthorServices{
public class AuthorService : IAuthorsService{
        private readonly EFCoreWebDemoContext _dbContext;

        public AuthorService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        

        public Member AddAuthor(Author author){
            _dbContext.Author.Add(author);
            _dbContext.SaveChanges();
            return author;
        }

        public List<Author> GetAuthors() {
            return _dbContext.Author.ToList();
        }

        public Member GetAuthorById(int id) => _dbContext.Author.SingleOrDefault(p=>p.ID == id);
       
    }
}
}