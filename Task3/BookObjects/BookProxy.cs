using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookObjects
{
    public class BookProxy : IBook
    {
        private readonly Guid _bookId;
        private readonly User _currentUser;
        private Book _book;

        public BookProxy(Guid bookId, User currentUser)
        {
            _bookId = bookId == Guid.Empty ? throw new ArgumentException("Provide non-empty book ID") : bookId;
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
        }

        private void ValidateAccess()
        {
            if (!_currentUser.IsRegistered)
            {
                throw new UnauthorizedAccessException("Current user is not registered");
            }
            else if (!_currentUser.Purchased(_bookId))
            {
                throw new UnauthorizedAccessException($"User {_currentUser.Username} has not purchased the book \"{BookRepository.GetBookTitle(_bookId)}\"");
            }
        }

        public string StartReading()
        {
            ValidateAccess();
            _book ??= new Book(_bookId);
            return _book.StartReading();
        }
    }
}
