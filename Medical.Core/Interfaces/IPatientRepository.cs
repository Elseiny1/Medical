using Medical.Core.Dtos;
using Medical.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Core.Interfaces
{
    public interface IPatientRepository
    {
        public Task<AuthModel> AddPatientAsync(PatientDto patient);
    }
}
