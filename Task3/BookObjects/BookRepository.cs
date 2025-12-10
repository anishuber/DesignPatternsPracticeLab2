using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookObjects
{
    public static class BookRepository
    {
        private static readonly Dictionary<Guid, (string Title, string Content)> _storage = new()
        {
            {
                Guid.Parse("f1a7bb3f-6f4e-4a43-8d71-0a7f90cb95ea"), ("First", "FirstContent")
            },
            {
                Guid.Parse("58a02eb7-c18a-4b16-a5e7-812fd5b2586f"), ("Second", "SecondContent")
            },
        };

        public static (string Title, string Content) GetBook(Guid id)
        {
            return _storage[id];
        }

        public static string GetBookTitle(Guid id)
        {
            return _storage[id].Title;
        }

        public static List<Guid> GetAllBooks()
        {
            return [.. _storage.Keys];
        }
    }
}
