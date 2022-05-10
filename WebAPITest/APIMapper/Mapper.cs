using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Models;
using WebAPITest.Models.DTO;

namespace WebAPITest.APIMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
           CreateMap<NationalPark, NationalParkDTO>().ReverseMap();
        }
    }
}
