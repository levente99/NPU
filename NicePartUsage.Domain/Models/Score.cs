using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NicePartUsage.Domain.Models
{
    public class Score
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [ForeignKey("NpuCreation")]
        public int CreationId { get; set; }

        [Range(1, 10)]
        public int CreativityScore { get; set; }

        [Range(1, 10)]
        public int UniquenessScore { get; set; }

        public virtual User User { get; set; }
        public virtual NpuCreation NpuCreation { get; set; }
    }
}
