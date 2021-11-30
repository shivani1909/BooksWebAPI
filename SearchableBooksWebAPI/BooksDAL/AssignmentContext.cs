using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDAL
{
    public class AssignmentContext : DbContext
    {
        public DbSet<Books> Books { get; set; }
        public AssignmentContext() : base("AssignmentContext")
        {

        }
    }
}
