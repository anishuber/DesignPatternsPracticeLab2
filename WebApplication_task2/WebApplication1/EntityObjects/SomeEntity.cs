using System.ComponentModel.DataAnnotations;

namespace Task2.EntityObjects
{
    public class SomeEntity
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        public SomeEntityStatus Status { get; set; }
    }
}
