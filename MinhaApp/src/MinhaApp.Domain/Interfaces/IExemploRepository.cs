namespace MinhaApp.Domain.Interfaces
{
    public interface IExemploRepository
    {
        void Add(ExemploEntity exemplo);
        void Update(ExemploEntity exemplo);
        void Delete(Guid id);
        ExemploEntity GetById(Guid id);
        IEnumerable<ExemploEntity> GetAll();
    }
}