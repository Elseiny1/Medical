using AutoMapper;
using Medical.Core.Dtos;
using Medical.Core.Interfaces;
using Medical.Core.Models;
using Medical.EF;
using Medical.EF.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Core.Repositories
{
    public class PatientRepository : IPatientRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IAuthoRepository _authoRepository;
        private readonly IMapper _mapper;

        public PatientRepository(ApplicationDbContext context,
                                 IAuthoRepository authoRepository,
                                 IMapper mapper)
        {
            _context = context;
            _authoRepository = authoRepository;
            _mapper = mapper;
        }

        public async Task<AuthModel> AddPatientAsync(PatientDto patient)
        {
            var authModel = new AuthModel();
            if (patient is null)
            {
                var deleted = await DeleteUser(patient.Phone);
                if (deleted != "ok")
                { authModel.Message = deleted; }
                authModel.Message = authModel.Message + " Please Insert Data to be Add";
                return authModel;
            }
            var checkPhone = await CheckPhoneExcist(patient.Phone);
            if (checkPhone == true)
            {
                var deleted = await DeleteUser(patient.Phone);
                if (deleted != "ok")
                { authModel.Message = deleted; }
                authModel.Message = authModel.Message + " This Phone number already excist";
                return authModel;
            }

            var user = _context.Users.Where(x => x.PhoneNumber == patient.Phone).FirstOrDefault();
            if (user is null)
            {
                var deleted = await DeleteUser(patient.Phone);
                if (deleted != "ok")
                { authModel.Message = deleted; }
                authModel.Message = authModel.Message + " Wrong Phone number";
                return authModel;
            }

            var newPatient = _mapper.Map<Patient>(patient);

            var jwtSecurityToken = await _authoRepository.CreateJwtToken(user);
            if (jwtSecurityToken is null)
            {
                var deleted = await DeleteUser(patient.Phone);
                if (deleted != "ok")
                { authModel.Message = deleted; }
                authModel.Message = authModel.Message + " Token didn't been created";
                return authModel;
            }

            _context.Patients.Add(newPatient);
            _context.SaveChanges();

            //_context.patients.Add(newPatient);
            return new AuthModel
            {
                Phone = user.PhoneNumber,
                //Expiration = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Role = "Patient",
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Message = "Token Created Succesfully"
            };
        }

        private async Task<bool> CheckPhoneExcist(string phone)
        {
            var checkPhone = _context.Patients.Find(phone);
            if (checkPhone is null)
                return false;
            return true;
        }

        private async Task<string> DeleteUser(string phone)
        {
            var user = await _authoRepository.GetUser(phone);
            if (user is null)
                return "phone number not found";
            var deleted = await _authoRepository.DeleteUser(user);
            if (deleted != "ok")
                return "can't delete this account";
            return deleted;

        }
    }
}
