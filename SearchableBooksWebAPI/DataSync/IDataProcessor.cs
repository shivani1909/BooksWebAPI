using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync
{
    public interface IDataProcessor
    {
        List<Books> Process(string query, int count);
    }
}
