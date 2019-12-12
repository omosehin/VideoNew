using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VideoRent.Dtos;
using VideoRent.Models;

namespace VideoRent.Controllers.Api
{
    public abstract class AutoMapperBase
    {
        protected readonly IMapper _mapper;

        protected AutoMapperBase()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<Customer, CustomerDto>()
                .ForMember(m => m.Id, opt => opt.Ignore()); ;
                x.CreateMap<Customer, CustomerDto>()
                .ForMember(m => m.Id, opt => opt.Ignore()); ;
                
            });

            _mapper = config.CreateMapper();
        }
    }
}