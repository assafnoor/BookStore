using Microsoft.EntityFrameworkCore;

namespace BookStore.Models.Repositories
{
    public class BookRepo : IBaseRepo<Book>
    {
        private readonly ApplicationDbContext _context;

        public BookRepo(ApplicationDbContext context)
        {
           _context = context;
        }

        public Book Add(Book entity)
        {
            _context.Books.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Book Delete(Book entity)
        {
            _context.Books.Remove(entity);
            _context.SaveChanges();
             return entity;
        }

        public IEnumerable<Book> GetAll()
        {
            var Books = _context.Books.Include(a=>a.author).ToList();
            return Books;
        }

        public Book GetById(int id)
        {
            var result = _context.Books.Include(a=>a.author).SingleOrDefault(a => a.Id == id);
             return result;
        }

        public Book Update(Book entity)
        {
           _context.Books.Update(entity);
           _context.SaveChanges();
            return entity;
        }

     
    }
}
