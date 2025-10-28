namespace MinhaApp.Application.Interfaces
{
    public interface IExemploService
    {
        Task<ExemploDto> CreateAsync(ExemploDto exemploDto);
        Task<ExemploDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ExemploDto>> GetAllAsync();
        Task UpdateAsync(ExemploDto exemploDto);
        Task DeleteAsync(Guid id);
    }
}