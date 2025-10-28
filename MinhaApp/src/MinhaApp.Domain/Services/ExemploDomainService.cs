using System;
using System.Collections.Generic;
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

        public void AddExemplo(ExemploEntity exemplo)
        {
            // Lógica de negócio para adicionar um exemplo
            _exemploRepository.Add(exemplo);
        }

        public void UpdateExemplo(ExemploEntity exemplo)
        {
            // Lógica de negócio para atualizar um exemplo
            _exemploRepository.Update(exemplo);
        }

        public void DeleteExemplo(Guid exemploId)
        {
            // Lógica de negócio para deletar um exemplo
            _exemploRepository.Delete(exemploId);
        }

        public ExemploEntity GetExemploById(Guid exemploId)
        {
            // Lógica de negócio para obter um exemplo por ID
            return _exemploRepository.GetById(exemploId);
        }

        public IEnumerable<ExemploEntity> GetAllExemplos()
        {
            // Lógica de negócio para obter todos os exemplos
            return _exemploRepository.GetAll();
        }
    }
}