using BookNest.Context;

namespace BookNest.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookNestDbContext _context;

        public UpdateBookCommand(BookNestDbContext context)
        {
            _context = context;
        }
        public int BookId { get; set; }
        public UpdateBookModel Model { get; set; }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);
            if (book == null)
                throw new InvalidOperationException("Kitap bulunamadi");

            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
            book.Title = Model.PublishDate != default ? Model.Title : book.Title;

            _context.SaveChanges();

        }

        public class UpdateBookModel()
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
            public int GenreId { get; set; }
        }
    }
}
