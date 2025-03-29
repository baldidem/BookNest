using BookNest.Context;
using Microsoft.AspNetCore.Mvc;

namespace BookNest.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookNestDbContext _context;

        public DeleteBookCommand(BookNestDbContext context)
        {
            _context = context;
        }
        public int BookId { get; set; }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);

            if (book == null)
                throw new InvalidOperationException("Kitap Bulunamadi");

            _context.Books.Remove(book);
            _context.SaveChanges();
        }

    }
}
