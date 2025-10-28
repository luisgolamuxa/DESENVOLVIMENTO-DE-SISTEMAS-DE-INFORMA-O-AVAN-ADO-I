using MediatR;
using System.Collections.Generic;

namespace MinhaApp.Application.Queries
{
    public class GetExemploQuery : IRequest<List<ExemploDto>>
    {
        // Add any necessary parameters for the query here
    }
}