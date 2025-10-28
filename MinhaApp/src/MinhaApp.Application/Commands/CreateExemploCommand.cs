using MediatR;

namespace MinhaApp.Application.Commands
{
    public class CreateExemploCommand : IRequest<int>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        // Adicione outras propriedades necessárias para a criação do Exemplo

        public CreateExemploCommand(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}