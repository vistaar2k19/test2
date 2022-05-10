using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPITest.Models.DTO
{
    public class NationalParkDTO
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
       
        public string State { get; set; }
        public int DateCreated { get; set; }
    }
}
