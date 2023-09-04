using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace API.Dtos
{
    public class PaisxDepDto : BaseEntity
    {
        public string NombrePais { get; set; }
        public List<DepartamentoDto> departamentos { get; set; }
    }
}