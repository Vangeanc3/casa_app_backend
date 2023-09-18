using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using casa_app_backend.Models;

namespace casa_app_backend.Data.Dtos.PetDto
{
    public class ReadPetDto
    {
         public int Id { get; set; }
        public string Name { get; set; }  = null!;
        public PetType Type { get; set; }
        public object House { get; set; } = null!;
    }
}