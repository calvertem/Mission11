//using System.Diagnostics;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Mission11.Models;
using Mission11.Models.ViewModels;
//using Mission11.Models;

namespace Mission11.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _repo;
        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }
        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;

            var blah = new BooksListViewModel
            {
                Books = _repo.Books
                    .OrderBy(x => x.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }
            };

            return View(blah);
        }
    }
}

