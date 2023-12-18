using Libro.Domain.Authors.AuthorEntity;
using Libro.Domain.Common.Results;
using MediatR;

namespace Libro.Application.Authors.CreateAuthor
{
    public record CreateAuthorCommand(
        string Name,
        string Description,
        string Nationality,
        DateOnly BirthDate,
        DateOnly DeathDate)
        :IRequest<Result<CreateAuthorResponse>>;
}
