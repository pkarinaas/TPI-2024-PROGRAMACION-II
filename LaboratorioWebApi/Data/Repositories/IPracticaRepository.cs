namespace LaboratorioWebApi.Data.Repositories
{
    public interface IPracticaRepository
    {
        Task<List<string>> ObtenerNombresPracticasActivasAsync();
    }
}
