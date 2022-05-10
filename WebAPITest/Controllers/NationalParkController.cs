using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Models;
using WebAPITest.Models.DTO;
using WebAPITest.Repository;
using WebAPITest.Repository.IRepository;

namespace WebAPITest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NationalParkController : Controller
    {
        private IRepoNationalPark _db;
        private readonly IMapper _mapper;

        public NationalParkController(IRepoNationalPark db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var objList = _db.GetNationalParks();
            var objListDTO = new List<NationalParkDTO>();

            foreach (var i in objList)
            {
                objListDTO.Add(_mapper.Map<NationalParkDTO>(i));
            }

            return Ok(objListDTO);

        }

        [HttpGet("{Id:int}", Name="GetNationalPark")]
        public IActionResult GetNationalPark(int Id)
        {
            var obj = _db.GetNationalPark(Id);
            if (obj == null)
                return NotFound();

            var objDTO = new NationalParkDTO();
            objDTO=_mapper.Map<NationalParkDTO>(obj);

            return Ok(objDTO);

        }

        [HttpPost]
        public IActionResult Post([FromBody] NationalParkDTO nationalParkDTO)
        {
            if(nationalParkDTO == null  || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(_db.NationalParkExists(nationalParkDTO.Name))
            {
                ModelState.AddModelError("", $"Entry already exist for {nationalParkDTO.Name}");
                return StatusCode(404, ModelState);
            }

            var objCreate = _mapper.Map<NationalPark>(nationalParkDTO);

            if (!_db.CreateNationalPark(objCreate))
            {
                ModelState.AddModelError("", $"Something went wrong while creating {nationalParkDTO.Name}");
                return NotFound();
            }
            else return CreatedAtRoute("GetNationalPark", new { Id = objCreate.Id }, objCreate);


        }
        [HttpPatch("{Id:int}", Name = "UpdateNationalPark")]
        public IActionResult UpdateNationalPark(int Id, [FromBody] NationalParkDTO nationalParkDTO)
         {
          
            if (nationalParkDTO == null || !ModelState.IsValid || Id != nationalParkDTO.Id)
            {
                return BadRequest(ModelState);
            }

            var objUpdate = _mapper.Map<NationalPark>(nationalParkDTO);

            if (!_db.UpdateNationalPark(objUpdate))
            {
                ModelState.AddModelError("", $"Something went wrong while updating {nationalParkDTO.Name}");
                return NotFound();
            }
            else return NoContent();

        }

    }
}
