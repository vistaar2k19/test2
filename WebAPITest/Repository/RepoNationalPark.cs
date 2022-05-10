using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Models;
using WebAPITest.Repository.IRepository;
using AutoMapper;
namespace WebAPITest.Repository
{
    public class RepoNationalPark : IRepoNationalPark
    {
        private readonly ApplicationDbContext _db;
       // private readonly Mapper _mapper;
        //AutoMapper _ap;
        public RepoNationalPark(ApplicationDbContext db)
        {
            this._db = db;
            //this._mapper = mapper;
        }


        public bool CreateNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Add(nationalPark);
            return Save();
        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Remove(nationalPark);
            return Save();

        }

        public NationalPark GetNationalPark(int Id)
        {
            return _db.NationalParks.FirstOrDefault(m => m.Id == Id);
        }

        

        public ICollection<NationalPark> GetNationalParks()
        {
           return  _db.NationalParks.ToList();
        }

        public bool NationalParkExists(int Id)
        {
            return _db.NationalParks.Any(m => m.Id == Id);

        }

        public bool NationalParkExists(string Name)
        {
            return _db.NationalParks.Any(m => m.Name == Name);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
             _db.NationalParks.Update(nationalPark);
            return Save();
        }
    }
}
