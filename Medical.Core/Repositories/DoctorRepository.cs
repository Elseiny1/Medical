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
    public class DoctorRepository : IDoctorRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IAuthoRepository _authoRepository;
        private readonly IMapper _mapper;
        private readonly IimageRepo _image;

        public DoctorRepository(ApplicationDbContext context,
                               IAuthoRepository authoRepository,
                               IMapper mapper,
                               IimageRepo image)
        {
            _context = context;
            _authoRepository = authoRepository;
            _mapper = mapper;
            _image = image;
        }

        public async Task<AuthModel> AddDoctorAsync(DoctorDto doctor)
        {
            var authModel = new AuthModel();
            if (doctor is null)
            {
                var deleted = await DeleteUser(doctor.Phone);
                if (deleted != "ok")
                { authModel.Message = deleted; }
                authModel.Message = authModel.Message + " Please Insert Data to be Add";
                return authModel;
            }
            var user = _context.Users.Where(x => x.PhoneNumber == doctor.Phone).FirstOrDefault();
            if (user is null)
            {
                var deleted = await DeleteUser(doctor.Phone);
                if (deleted != "ok")
                { authModel.Message = deleted; }
                authModel.Message = authModel.Message + " Wrong Phone number";
                return authModel;
            }
            var newDoctor = _mapper.Map<Doctor>(doctor);
            newDoctor.ImageUrl = await _image.AddImageAsync(doctor.Image, doctor.Phone);
            var jwtSecurityToken = await _authoRepository.CreateJwtToken(user);
            if (jwtSecurityToken is null)
            {
                var deleted = await DeleteUser(doctor.Phone);
                if (deleted != "ok")
                { authModel.Message = deleted; }
                authModel.Message = authModel.Message + " Token didn't been created";
                return authModel;
            }
            _context.Doctors.Add(newDoctor);
            _context.SaveChanges();
            return new AuthModel
            {
                Phone = user.PhoneNumber,
                //Expiration = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Role = "Doctor",
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Message = "Token Created Succesfully"
            };
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
