using BookNest.Common;
using BookNest.Context;

namespace BookNest.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookNestDbContext _context;

        public GetBooksQuery(BookNestDbContext context)
        {
            _context = context;
        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _context.Books.OrderBy(x=>x.Id).ToList();

            List<BooksViewModel> vmModel = new List<BooksViewModel>();
            foreach (var book in bookList)
            {
                vmModel.Add(new BooksViewModel()
                {
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
                    PageCount = book.PageCount
                });
            }
            return vmModel;

        } 

        public class BooksViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
        }
    }
}
