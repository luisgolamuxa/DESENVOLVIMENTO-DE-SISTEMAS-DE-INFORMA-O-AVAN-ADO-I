using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MinhaApp.Domain.Entities;
using MinhaApp.Domain.Interfaces;

namespace MinhaApp.Domain.Services
{
    public class ExemploDomainService
    {
        private readonly IExemploRepository _exemploRepository;

        public ExemploDomainService(IExemploRepository exemploRepository)
        {
            _exemploRepository = exemploRepository;
        }

        public async Task AddExemploAsync(ExemploEntity exemplo)
        {
            await _exemploRepository.AddAsync(exemplo);
        }

        public async Task UpdateExemploAsync(ExemploEntity exemplo)
        {
            await _exemploRepository.UpdateAsync(exemplo);
        }

        public async Task DeleteExemploAsync(Guid exemploId)
        {
            await _exemploRepository.DeleteAsync(exemploId);
        }

        public async Task<ExemploEntity?> GetExemploByIdAsync(Guid exemploId)
        {
            return await _exemploRepository.GetByIdAsync(exemploId);
        }

        public async Task<IEnumerable<ExemploEntity>> GetAllExemplosAsync()
        {
            return await _exemploRepository.GetAllAsync();
        }
    }
}