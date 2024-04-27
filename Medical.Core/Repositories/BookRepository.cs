using Medical.Core.Interfaces;
using Medical.EF.Data;
using Medical.EF.Models;
using Medical.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Core.Repositories
{
    public class BookRepository : BaseRepository<Book> ,IBookRepository
    {

        public BookRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllDoctorBooksAsync(string Doctor_Phone)
        {
            var books = _context.Books.Where(m => m.Doctor_Phone == Doctor_Phone).OrderBy(m => m.Date).ThenBy(m => m.Am_Pm).ThenBy(m => m.Time).ToList();

            return books;
        }

        public async Task<IEnumerable<Book>> GetAllDoctorBooksInDayAsync(string Doctor_Phone, string Date)
        {
            var books = _context.Books.Where(m => m.Doctor_Phone == Doctor_Phone & m.Date == Date).OrderBy(m => m.Am_Pm).ThenBy(m => m.Time).ToList();

            return books;
        }
    }
}
