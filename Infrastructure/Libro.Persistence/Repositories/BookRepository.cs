﻿using AutoMapper;
using Libro.Domain.Books;

namespace Libro.Persistence.Repositories
{
    internal sealed class BookRepository : GenericRepository<Book, DbModels.Book>, IBookRepository
    {
        public BookRepository(LiboDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
