using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookObjects
{
    public class User
    {
        public string Username { get; set; } = String.Empty;
        public bool IsRegistered { get; }
        private readonly HashSet<Guid> _purchasedBookIds;

        public User(string username, IEnumerable<Guid>? purchasedBookIds)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            IsRegistered = true;
            _purchasedBookIds = [.. purchasedBookIds ?? []];
        }

        public User()
        {
            Username = "Anonymous";
            IsRegistered = false;
            _purchasedBookIds = [];
        }

        public bool Purchased(Guid bookId) => _purchasedBookIds.Contains(bookId);
        public void PurchaseBook(Guid bookId) => _purchasedBookIds.Add(bookId);
    }
}
