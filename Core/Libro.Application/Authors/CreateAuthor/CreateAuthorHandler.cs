using Libro.Domain.Authors.Repository;
using Libro.Domain.Common.Results;
using Libro.Domain.Authors.Factory;
using MediatR;

namespace Libro.Application.Authors.CreateAuthor
{
    public class CreateAuthorHandler : IRequestHandler<CreateAuthorCommand, Result<CreateAuthorResponse>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IAuthorFactory _authorFacory;

        public CreateAuthorHandler(
            IAuthorRepository authorRepository,
            IAuthorFactory authorFacory)
        {
            _authorRepository = authorRepository;
            _authorFacory = authorFacory;
        }

        public Task<Result<CreateAuthorResponse>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            // validate the request
            // create author
            // save to db
            // return the result
           
            throw new NotImplementedException();
        }
    }
}
