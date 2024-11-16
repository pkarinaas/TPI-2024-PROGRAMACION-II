
using LaboratorioWebApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioWebApi.Data.Repositories
{
    public class EstadosRepository : IEstadosRepository
    {
        private LaboratorioDbContext _context;
        public EstadosRepository(LaboratorioDbContext context)
        {
            _context = context;
        }
        public async Task<List<string>> ObtenerNombresEstadosAsync()
        {
            return await _context.Set<TiposEstados>()
                              .Select(e => e.Estado)
                              .ToListAsync();
        }
    }
}
