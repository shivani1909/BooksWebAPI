using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string Subtitle { get; internal set; }
        public int? PageCount { get; internal set; }
        public string PrintType { get; internal set; }
    }
}
