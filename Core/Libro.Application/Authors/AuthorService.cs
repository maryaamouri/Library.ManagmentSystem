using AutoMapper;
using FluentValidation;
using Libro.Application.Authors.Exceptions;
using Libro.Application.Common.Exceptions;
using Libro.Domain.Authors;
using ValidationException = Libro.Application.Common.Exceptions.ValidationException;

namespace Libro.Application.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<AuthorRequest> _validator;

        public AuthorService
        (
        IAuthorRepository authorRepository,
        IMapper mapper,
        IValidator<AuthorRequest> validator
        )
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<AuthorDto> CreateAsync(AuthorRequest request)
        {

            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var authors = await _authorRepository.GetAsync();
            if (authors.Count > 0)
            {
                if (authors.Any(a => a.Name == request.AuthorName))
                {
                    throw new AuthorAreadyExistsException(request.AuthorName);
                }

            }
            var author = new Author (request.AuthorName );
            var createdAuthor = await _authorRepository.CreateAsync(author);
            await _authorRepository.SaveChangesAsync();
            return _mapper.Map<AuthorDto>(createdAuthor);
        }

        public async Task DeleteAsync(Guid id)
        {
            var author = await _authorRepository.GetByIdAsync(id)
                ?? throw new NotFoundException(typeof(Author).Name, id);
            await _authorRepository.DeleteAsync(author);
            await _authorRepository.SaveChangesAsync();
        }

        public async Task<AuthorDto> GetByIdAsync(Guid id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            return author == null
                ? throw new NotFoundException(typeof(Author).Name, id) : _mapper.Map<AuthorDto>(author);
        }

        public async Task<IList<AuthorDto>> GetListAsync()
        {
            var authorList = await _authorRepository.GetAsync();
            if (authorList.Count == 0)
                throw new NotFoundException(typeof(Author).Name);
            authorList = authorList.OrderBy(a => a.Name).ToList();
            return _mapper.Map<IList<AuthorDto>>(authorList);
        }

        public async Task<AuthorDto> UpdateAsync(Guid id, AuthorRequest request)
        {
            var author = await _authorRepository.GetByIdAsync(id)
                ?? throw new NotFoundException(typeof(Author).Name, id);
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            author.Name = request.AuthorName;
            await _authorRepository.UpdateAsync(author);
            await _authorRepository.SaveChangesAsync();
            return _mapper.Map<AuthorDto>(author);
        }
    }
}
