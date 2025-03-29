using BookNest.Common;
using BookNest.Context;
using BookNest.Entities;

namespace BookNest.BookOperations.GetBooks
{
    public class GetByIdQuery
    {
        private readonly BookNestDbContext _context;

        public GetByIdQuery(BookNestDbContext context)
        {
            _context = context;
        }
        public int BookId { get; set; }
        public BookModel Handle()
        {
            var book = _context.Books.Where(x => x.Id == BookId).FirstOrDefault();
            if (book is null)
            {
                throw new InvalidOperationException("Kitap bulunamadi");
            }
            BookModel model = new()
            {
                Title = book.Title,
                PageCount = book.PageCount,
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
                Genre = ((GenreEnum)book.GenreId).ToString(),
            };
            return model;
        }

        public class BookModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
        }

    }
}
