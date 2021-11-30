using Google.Apis.Books.v1;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync
{
    public class DataProcessor : IDataProcessor
    {
        private readonly BooksService _booksService;
        public DataProcessor(string apiKey)
        {
            _booksService = new BooksService(new BaseClientService.Initializer()
            {
                ApiKey = apiKey,
                ApplicationName = this.GetType().ToString()
            });
        }

        public List<Books> Process(string query, int count)
        {
            var listquery = _booksService.Volumes.List(query);
            listquery.MaxResults = count;
            //listquery.StartIndex = offset;
            var res = listquery.Execute();
            var books = res.Items.Select(b => new Books
            {
                //Id = Convert.ToInt32(b.Id),
                Title = b.VolumeInfo?.Title ?? string.Empty,
                Subtitle = b.VolumeInfo?.Subtitle ?? string.Empty,
                Description = b.VolumeInfo?.Description ?? string.Empty,
                Author = b.VolumeInfo?.Authors == null ? string.Empty : string.Join(",", b.VolumeInfo?.Authors),
                PageCount = b.VolumeInfo?.PageCount ?? 0,
                Publisher = b.VolumeInfo?.Publisher ?? string.Empty,
                PrintType = b.VolumeInfo?.PrintType ?? string.Empty,
                Category = b.VolumeInfo?.Categories == null ? string.Empty : string.Join(",", b.VolumeInfo?.Categories)
            }).ToList();
            return books;
        }
    }
}
