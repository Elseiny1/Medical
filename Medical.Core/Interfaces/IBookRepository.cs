using Medical.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Core.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllDoctorBooksAsync(string Doctor_Phone);

        Task<IEnumerable<Book>> GetAllDoctorBooksInDayAsync(string Doctor_Phone,string Date);
    }
}
