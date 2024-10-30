using System.ComponentModel.DataAnnotations;

namespace NicePartUsage.Domain.Models
{
    public class NpuCreation
    {
        [Key]
        public int Id { get; set; }
        public List<Element> Elements { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public byte[] FileData { get; set; }

        public DateTime UploadDate { get; set; } = DateTime.UtcNow;

        public virtual User Creator { get; set; }

        public virtual List<Score> Scores { get; set; }

        public virtual ICollection<NpuCreationElement> NpuCreationElements { get; set; }
    }
}
