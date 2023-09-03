using Microsoft.EntityFrameworkCore;

namespace BookStore.Models.Repositories
{
    public class AuthorRepo : IBaseRepo<Author>
    {
        private readonly ApplicationDbContext _context;

        public AuthorRepo(ApplicationDbContext context)
        {
           _context = context;
        }

        public Author Add(Author entity)
        {
            _context.Authors.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Author Delete(Author entity)
        {
            _context.Authors.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<Author> GetAll()
        {
            var authors = _context.Authors.Include(b => b.books).ToList();
            return authors;
        }

        public Author GetById(int id)
        {
            var result = _context.Authors.SingleOrDefault(a => a.Id == id);
             return result;
        }

        public List<Author> Search(string term)
        {
           var result =_context.Authors.Include(b => b.books).Where(a=>a.Name.Contains(term)).ToList();
            return result;
        }

        public Author Update(Author entity)
        {
           _context.Authors.Update(entity);
           _context.SaveChanges();
            return entity;
        }

     
    }
}
