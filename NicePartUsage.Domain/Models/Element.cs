using System.ComponentModel.DataAnnotations;

namespace NicePartUsage.Domain.Models
{
    public class Element
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public virtual List<NpuCreation> NpuCreations { get; set; }
        public virtual ICollection<NpuCreationElement> NpuCreationElements { get; set; }
    }
}
