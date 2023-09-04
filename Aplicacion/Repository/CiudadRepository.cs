using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository
{
    public class CiudadRepository : GenericRepository<Ciudad>, ICiudadRepository
    {
        protected readonly ApiIncidenciasContext _context;

        public CiudadRepository(ApiIncidenciasContext context) : base(context)
        {
            this._context = context;
        }

        public override async Task<IEnumerable<Ciudad>> GetAllAsync()
        {
            return await this._context.Ciudades
                /* .Include(d => d.Ciudades) */
                .ToListAsync();
        }

        public override async Task<Ciudad> GetByIdAsync(int id)
        {
            return await this._context.Ciudades
            /* .Include(d => d.Ciudades) */
            .FirstOrDefaultAsync(d => d.Id == id);
        }

    }
}