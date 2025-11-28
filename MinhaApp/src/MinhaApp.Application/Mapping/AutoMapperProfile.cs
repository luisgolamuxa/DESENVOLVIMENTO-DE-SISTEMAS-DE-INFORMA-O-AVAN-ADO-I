using Mapster;
using MinhaApp.Application.DTOs;
using MinhaApp.Domain.Entities;

namespace MinhaApp.Application.Mapping
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<ExemploEntity, ExemploDto>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Nome, src => src.Nome)
                .Map(dest => dest.Descricao, src => src.Descricao)
                .Map(dest => dest.DataCriacao, src => src.DataCriacao)
                .Map(dest => dest.Status, src => src.Status.ToString());

            TypeAdapterConfig<ExemploDto, ExemploEntity>.NewConfig()
                .ConstructUsing(src => new ExemploEntity(src.Nome ?? string.Empty, src.Descricao ?? string.Empty))
                .IgnoreNullValues(true);

            // Categoria <-> CategoriaDto
            TypeAdapterConfig<MinhaApp.Domain.Entities.CategoriaEntity, MinhaApp.Application.DTOs.CategoriaDto>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Nome, src => src.Nome)
                .Map(dest => dest.Produtos, src => src.Produtos);

            TypeAdapterConfig<MinhaApp.Application.DTOs.CategoriaDto, MinhaApp.Domain.Entities.CategoriaEntity>.NewConfig()
                .IgnoreNullValues(true)
                .Map(dest => dest.Nome, src => src.Nome);

            // Produto <-> ProdutoDto
            TypeAdapterConfig<MinhaApp.Domain.Entities.ProdutoEntity, MinhaApp.Application.DTOs.ProdutoDto>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Nome, src => src.Nome)
                .Map(dest => dest.CategoriaId, src => src.CategoriaId);

            TypeAdapterConfig<MinhaApp.Application.DTOs.ProdutoDto, MinhaApp.Domain.Entities.ProdutoEntity>.NewConfig()
                .IgnoreNullValues(true)
                .Map(dest => dest.Nome, src => src.Nome)
                .Map(dest => dest.CategoriaId, src => src.CategoriaId);
        }
    }
}