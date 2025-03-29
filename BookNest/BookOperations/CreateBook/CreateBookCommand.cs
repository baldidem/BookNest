using BookNest.Context;
using BookNest.Entities;

namespace BookNest.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        private readonly BookNestDbContext _context;

        public CreateBookCommand(BookNestDbContext context)
        {
            _context = context;
        }
        public CreateBookModel Model { get; set; }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == Model.Title);

            if (book is not null)
            {
                throw new InvalidOperationException("Kitap zaten mevcut");
            }

            book = new Book();

            book.Title = Model.Title;
            book.GenreId = Model.GenreId;
            book.PublishDate = Model.PublishDate;
            book.PageCount = Model.PageCount;

            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
