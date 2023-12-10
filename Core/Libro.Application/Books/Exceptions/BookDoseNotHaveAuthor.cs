using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libro.Application.Books.Exceptions
{
    internal class BookDoseNotHaveAuthor : BadRequestException
    {
        public BookDoseNotHaveAuthor(string bookName)
            : base($"Book dose not have author.")
        {
        }
    }
}
