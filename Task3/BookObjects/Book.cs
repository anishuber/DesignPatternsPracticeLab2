namespace BookObjects
{
    public class Book : IBook
    {
        public Guid Id { get; }
        public readonly string _title;
        private readonly string _content;

        public Book(Guid id)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            _title = BookRepository.GetBook(id).Title;
            _content = BookRepository.GetBook(id).Content;
        }

        public string StartReading()
        {
            return $"\t\"{_title}\"\n{_content}";
        }
    }
}
