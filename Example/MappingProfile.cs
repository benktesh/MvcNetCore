using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Example.Models;
using Example.ViewModel;

namespace Toy
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DataProcessorEditViewModel, DataProcessor>().ReverseMap();
            CreateMap<ContactEditViewModel, Contact>().ForMember(dest=>dest.Name, opt => opt.MapFrom(src=>src.ContactName)).ReverseMap();
        }
    }
}
