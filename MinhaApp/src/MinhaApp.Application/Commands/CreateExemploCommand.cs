namespace MinhaApp.Application.Commands
{
    // Placeholder command class — MediatR não está como dependência obrigatória
    public class CreateExemploCommand
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        public CreateExemploCommand() { }

        public CreateExemploCommand(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}