using System.ComponentModel.DataAnnotations;

// ReSharper disable once IdentifierTypo
namespace Markel.Models
{
    public class ClaimRequest
    {
        public bool IsClosed { get; set; }

        [Required(ErrorMessage = "Assured Name is required")]
        public string AssuredName { get; set; } = null!;

        [Required(ErrorMessage = "Incurred Loss is required")]
        [Range(0, double.MaxValue, ErrorMessage = "IncurredLoss must be a non-negative value")]
        public decimal IncurredLoss { get; set; }
    }
}
