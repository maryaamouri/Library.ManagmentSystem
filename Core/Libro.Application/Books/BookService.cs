using AutoMapper;
using ValidationException = Libro.Application.Common.Exceptions.ValidationException;
using FluentValidation;
using Libro.Domain.Books;
using Libro.Application.Authors;
using Libro.Application.Common.Exceptions;
using Libro.Application.Books.Exceptions;
using Libro.Domain.Authors;

namespace Libro.Application.Books
{
    internal class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<BookRequest> _validator;
        private readonly IAuthorService _authorService;
        public BookService
        (
        IBookRepository bookRepository,
        IMapper mapper,
        IValidator<BookRequest> validator
,
        IAuthorService authorService)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _validator = validator;
            _authorService = authorService;
        }
        public async Task<IList<BookDto>> GetListAsync()
        {
            var books = await _bookRepository.GetAsync();
            return books == null ? throw new NotFoundException(typeof(Book).Name) : _mapper.Map<IList<BookDto>>(books);
        }
        public async Task<BookDto> CreateAsync(BookRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var books = await _bookRepository.GetAsync();
            if (books.Count > 0)
            {
                if (books.Any(a => a.Title == request.Title))
                {
                    throw new BookAlreadyExists(request.Title);
                }
            }

            var newBook = await _bookRepository.CreateAsync(_mapper.Map<Book>(request));
            return _mapper.Map<BookDto>(newBook);
        }

        public async Task DeleteAsync(Guid id)
        {
            var book = await GetByIdAsync(id);
            await _bookRepository.DeleteAsync(_mapper.Map<Book>(book));
        }

        public async Task<BookDto> GetByIdAsync(Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id)
                ?? throw new NotFoundException(typeof(Book).Name, id);
            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> UpdateAsync(Guid id, BookRequest request)
        {
            var book = await GetByIdAsync(id);
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            await _bookRepository.UpdateAsync(_mapper.Map<Book>(book));
            return _mapper.Map<BookDto>(book);
        }
        public async Task<BookDto> RemoveAuthor(Guid bookId)
        {
            var book = await GetByIdAsync(bookId);

            if (book.Author == null)
                throw new BookDoseNotHaveAuthor(book.Title);
            book.Author = null;
            book.AuthorId = null;

            await _bookRepository.UpdateAsync(_mapper.Map<Book>(book));
            return book;
        }
        public async Task<BookDto> AddAuthor(Guid authorId, Guid bookId)
        {
            var author = await _authorService.GetByIdAsync(authorId);

            var book = await GetByIdAsync(bookId);

            if (book.Author != null)
                throw new BookAlreadyHasAuthor(book.Title, author.Name, book.Author.Name);
            book.Author = _mapper.Map<Author>(author);
            book.AuthorId = author.AuthorId;
            await _bookRepository.UpdateAsync(_mapper.Map<Book>(book));

            return book;
        }
    }
}
