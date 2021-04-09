using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnitTestExc.Models;
using UnitTestExc.Controllers.Tests.AuthorServices;
using System.Net;
using System.Collections.Generic;

namespace UnitTestExc.Controllers
{
    public class AuthorController : Controller
    {
         private readonly IAuthorsService _authorService;
        public AuthorController(IAuthorsService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("GetAuthor/{id}")]
        public HttpStatusCode GetAuthor(int id)
        {
            var member = _authorService.GetAuthorById(id);
            if (member != null){
                return HttpStatusCode.OK;
            }else{
                return HttpStatusCode.NotFound;
            }
        }
    }
}