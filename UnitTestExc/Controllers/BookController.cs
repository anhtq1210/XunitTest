using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using UnitTestExc.Models;
using UnitTestExc.Controllers.Tests.BookServices;

namespace UnitTestExc.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookServices _iBookServices;
        public BookController(IBookServices iBookServices)
        {
            _iBookServices = iBookServices;
        }
        public async Task<IActionResult> Index()
        {
            using (var context = new EFCoreWebDemoContext())
            {
                var model = await _iBookServices.GetAll();
                return View(model);
            }
        }  
        // public async Task<IActionResult> Index()
        // {
        //     using (var context = new EFCoreWebDemoContext())
        //     {
        //         var model = await context.Authors.Include(a => a.Books).AsNoTracking().ToListAsync();
        //         return View(model);
        //     }
        // }  
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            using(var context = new EFCoreWebDemoContext())
            {
                var authors = await context.Authors.Select(a => new SelectListItem {
                    Value = a.AuthorId.ToString(), 
                    Text = $"{a.FirstName} {a.LastName}"
                }).ToListAsync();
                ViewBag.Authors = authors;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title, AuthorId")] Book book)
        {
            using (var context = new EFCoreWebDemoContext())
            {
                context.Books.Add(book);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
    }
}