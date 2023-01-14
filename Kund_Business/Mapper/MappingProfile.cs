using AutoMapper;
using Kund_DataAccess;
using Kund_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kund_Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Companies, CompanyDTO>().ReverseMap();
        }
        
    }
}
