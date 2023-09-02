using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository
{
    public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamentoRepository
    {
        protected readonly ApiIncidenciasContext _context;

        public DepartamentoRepository(ApiIncidenciasContext context) : base(context)
        {
            this._context = context;
        }

        public override async Task<IEnumerable<Departamento>> GetAllAsync()
        {
            return await this._context.Departamentos
                .Include(d => d.Ciudades)
                .ToListAsync();
        }

        public override async Task<Departamento> GetByIdAsync(int id)
        {
            return await this._context.Departamentos
            .Include(d => d.Ciudades)
            .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}