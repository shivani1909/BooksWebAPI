using BooksDAL;
using DataSync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchableBooksWebAPI
{
    public class DataSynchronizer
    {
        private IDataProcessor _dataProcessor;
        public DataSynchronizer()
        {
            _dataProcessor = new DataProcessor("AIzaSyBB_ - gRT8yxCKCslfEQA19RLN4pWBMksHo"); 
        }

        public void InsertDataIntoDb()
        {
            var booksData = _dataProcessor.Process("habit", 40);
            List<BooksDAL.Books> booksDAL = new List<BooksDAL.Books>();
            foreach (var books in booksData)
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