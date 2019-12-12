using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VideoRent.Dtos;
using VideoRent.Models;
using AutoMapper;

namespace VideoRent.App_Start
{
    public class MappingProfile 
    {

        //public MappingProfile()
        //{
        //    var configuration = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<Customer, CustomerDto>();
        //        cfg.CreateMap<MembershipType, MembershipTypeDto>();
        //    });

        //    configuration.AssertConfigurationIsValid();
        //    IMapper mapper = configuration.CreateMapper();
        //}

        //public static void Initialize()
        //{
        //    Mapper.Initialize
        //}
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>();
            });
        }


    }
}
