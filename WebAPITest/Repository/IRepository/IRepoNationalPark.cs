using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Models;

namespace WebAPITest.Repository.IRepository
{
    public interface IRepoNationalPark
    {
         ICollection<NationalPark> GetNationalParks();
         NationalPark GetNationalPark(int Id);
         bool NationalParkExists(int Id);
         bool NationalParkExists(string Name);
         bool CreateNationalPark(NationalPark nationalPark);
         bool UpdateNationalPark(NationalPark nationalPark);
         bool DeleteNationalPark(NationalPark nationalPark);
         bool Save();


    }
}
