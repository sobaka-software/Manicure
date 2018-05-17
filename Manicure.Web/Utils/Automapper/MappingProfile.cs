using AutoMapper;
using Manicure.BusinessLogic.Dtos;
using Manicure.Common.Domain;
using Manicure.Web.Models;

namespace Manicure.Web.Utils.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReviewClient, ReviewViewModel>().ReverseMap();

            CreateMap<User, UserViewModel>().ReverseMap();

            CreateMap<Master, UserViewModel>().ReverseMap();

            CreateMap<Client, UserViewModel>().ReverseMap();

            CreateMap<Master, UserViewModel>().ReverseMap();

            CreateMap<User, MasterToViewViewModel>().ReverseMap();

            CreateMap<Procedure, ProcedureViewModel>().ReverseMap();

            CreateMap<ProcedureDto, ProcedureEntryViewModel>().ReverseMap();

            CreateMap<ProcedureDto, Schedule>().ReverseMap();

            CreateMap<ProcedureDto, ProcedureEntry>().ReverseMap();

            CreateMap<User, UserProfileViewModel>().ReverseMap();

            CreateMap<ExampleWork, ExampleWorkViewModel>().ForMember(c => c.WorkDescription, opt => opt
                .MapFrom(g => g.Description)).ReverseMap();

            CreateMap<ExampleWork, GalleryViewModel>().ForMember(c => c.WorkDescription, opt => opt
                .MapFrom(g => g.Description)).ReverseMap();
        }
    }
}