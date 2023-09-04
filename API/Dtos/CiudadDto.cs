using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace API.Dtos
{
    public class CiudadDto : BaseEntity
    {
        public string NombreCiudad {    get; set; }
        public int IdDepFk { get; set; }
        
    }
}