
using LaboratorioWebApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioWebApi.Data.Repositories
{
    public class PracticaRepository : IPracticaRepository
    {
        private LaboratorioDbContext _context;
        public PracticaRepository(LaboratorioDbContext context)
        {
            _context = context;
        }
        public async Task<List<string>> ObtenerNombresPracticasActivasAsync()
        {
            return await _context.Set<Practicas>()
                             .Where(p => p.EsActiva)
                             .Select(p => p.NomPractica)
                             .ToListAsync();
        }
    }
}
