using BooksDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace SearchableBooksWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult GetBooksList()
        {
            
            List<Books> books = new List<Books>();
            using (var ctx = new AssignmentContext())
            {
                books = ctx.Books.ToList();
            }
            if(books.Count <= 0)
            {
                DataSynchronizer dataSynchronizer = new DataSynchronizer();
                dataSynchronizer.InsertDataIntoDb();
            }
            try
            {
                var draw = Request.Form.GetValues("draw").FirstOrDefault();  
                var start = Request.Form.GetValues("start").FirstOrDefault();  
                var length = Request.Form.GetValues("length").FirstOrDefault();  
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();  
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();  
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();  
  
  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;  
                int skip = start != null ? Convert.ToInt32(start) : 0;  
                int recordsTotal = 0;
 
                //Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    books = books.OrderBy(sortColumn + " " + sortColumnDir).ToList();
                }
                //Search    
                if (!string.IsNullOrEmpty(searchValue))  
                {
                    books = books.Where(m => m.Title.Contains(searchValue)
                    || m.Publisher.Contains(searchValue)
                    || m.Author.Contains(searchValue)
                    || m.Category.Contains(searchValue)
                    || m.Description.Contains(searchValue)
                    ).ToList();  
                }  
  
                //total number of rows count     
                recordsTotal = books.Count();  
                //Paging     
                var data = books.Skip(skip).Take(pageSize).ToList();  
                //Returning Json Data    
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch(Exception)
            {
                //Log exception
                //redirect to error page
                return RedirectToAction("Error", "Home");
            }
        }
        public ActionResult Error()
        {
            return View("Error");
        }
    }
}