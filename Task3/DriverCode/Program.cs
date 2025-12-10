using BookObjects;
using System.Net;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace DriverCode
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            void TryStartReading(User user, Guid id)
            {
                try
                {
                    IBook book = new BookProxy(id, user);
                    string content = book.StartReading();
                    Console.WriteLine("====== E-Reader =======");
                    Console.WriteLine(content);
                    Console.WriteLine("========= End =========");
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine("[!] Access denied: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected error: " + ex.Message);
                }
            }

            var user = new User();
            var bookHidden = new Book(BookRepository.GetAllBooks()[0]);

            Console.WriteLine("\n* Anonymous user tries to read the book:");
            TryStartReading(user, bookHidden.Id);

            Console.WriteLine("\n* User who didn't pay tries to read the book:");
            user = new User("You", null);
            TryStartReading(user, bookHidden.Id);

            Console.WriteLine("\n* User who sighed and purchased the book because ThePirateBay felt wrong tries to read the book:");
            user.PurchaseBook(bookHidden.Id);
            TryStartReading(user, bookHidden.Id);

            Console.WriteLine("\n* User who already purchased the entire library tries to read the book:");
            user = new User("SonOfYourMomsFriend", BookRepository.GetAllBooks());
            TryStartReading(user, BookRepository.GetAllBooks()[^1]);

        }
    }
}
