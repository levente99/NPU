using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace NicePartUsage.Domain.Models
{
    public class User : IdentityUser
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateJoined { get; set; } = DateTime.UtcNow;

        public virtual ICollection<NpuCreation> Creations { get; set; }

        public virtual ICollection<Score> Scores { get; set; }
    }
}
