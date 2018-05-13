using AutoMapper;
using Manicure.Common.Domain;
using Manicure.Web.Models;

namespace Manicure.Web.Utils.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReviewClient, ReviewViewModel>().ReverseMap();
        }
    }
}