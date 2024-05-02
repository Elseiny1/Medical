using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Core.Interfaces
{
    public interface IimageRepo
    {
        public Task<string> AddImageAsync(IFormFile file, string phone);

    }
}
