using BookStore.Models;

namespace BookStore.Dto
{
    public class BookDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string author { get; set; }
    }
}
