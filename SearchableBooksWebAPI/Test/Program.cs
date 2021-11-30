using BooksDAL;
using DataSync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DataProcessor dataProcessor = new DataProcessor("AIzaSyBB_ - gRT8yxCKCslfEQA19RLN4pWBMksHo");
            var booksdata = dataProcessor.Process("habit", 40);
            //convert datasync books to DAL Books
            List<BooksDAL.Books> booksDAL = new List<BooksDAL.Books>();
            foreach (var books in booksdata)
            {
                var book = new BooksDAL.Books()
                {
                    Title = books.Title,
                    Author = books.Author,
                    Category = books.Category,
                    Description = books.Description,
                    Publisher = books.Publisher,
                    PrintType = books.PrintType,
                    PageCount = books.PageCount ?? 0,
                };
                booksDAL.Add(book);
            }
            using (var ctx = new AssignmentContext())
            {
                //var stud = new BooksDAL.Books() { Title = "Bill" };

                ctx.Books.AddRange(booksDAL);
                ctx.SaveChanges();
            }
        }
    }
}
