using AutoMapper;
using Medical.Core.Dtos;
using Medical.Core.Models;
using Medical.EF.Models;

namespace Medical.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Doctor, DoctorDto>().ReverseMap();

            CreateMap<Patient, PatientDto>().ReverseMap();

            CreateMap<Post, PostDto>().ReverseMap();

            CreateMap<Comment, CommentDto>().ReverseMap();

            CreateMap<PatientDto, RegisterDTO>().ReverseMap();

            CreateMap<DoctorDto, RegisterDTO>().ReverseMap();

            CreateMap<Book, BookDto>().ReverseMap();
        }

    }
}
