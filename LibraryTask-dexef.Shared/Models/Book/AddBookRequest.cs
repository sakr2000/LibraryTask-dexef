namespace LibraryTask_dexef.Shared.Models.Book
{

    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;

        public int PublishedYear { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class AddBookRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int PublishedYear { get; set; }
        
    }
    public class UpdateBookRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int PublishedYear { get; set; }
        public bool IsAvailable { get; set; }
        
    }
}