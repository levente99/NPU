using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NicePartUsage.Domain.Models
{
    public class NpuCreationElement
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("NpuCreation")]
        public int NpuCreationId { get; set; }

        [ForeignKey("Element")]
        public int ElementId { get; set; }

        public virtual NpuCreation NpuCreation { get; set; }

        public virtual Element Element { get; set; }
    }
}
