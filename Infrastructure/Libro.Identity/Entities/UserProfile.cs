using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libro.Identity.Entities
{
    public class UserProfile 
    {
        public Guid UserProfileId { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
