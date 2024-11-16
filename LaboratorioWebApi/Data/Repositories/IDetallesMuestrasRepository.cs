using LaboratorioWebApi.Data.Entities;

namespace LaboratorioWebApi.Data.Repositories
{
    public interface IDetallesMuestrasRepository
    {
        bool CreateDetalleMuestra(DetallesMuestras detalle);
        Task<bool> UpdateDetallesMuestrasAsync(DetallesMuestras muestra);
        List<DetallesMuestras> GetDetallesMuestras();
        Task<List<MuestraConsultaResultado>> GetDetallesMuestrasAsync();

        bool UpdateDetallesMuestras(int id);
    }
}
