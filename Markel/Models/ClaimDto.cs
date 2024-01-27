namespace Markel.Models
{
    public class ClaimDto
    {
        // ReSharper disable once InconsistentNaming
        public string? UCR { get; set; }
        public int CompanyId { get; set; }
        public DateTime? ClaimDate { get; set; }
        public DateTime? LossDate { get; set; }
        public string? AssuredName { get; set; }
        public decimal IncurredLoss { get; set; }
        public bool Closed { get; set; }
        public string? ClaimTypeName { get; set; }

        public int DaysSinceClaim { get; set; }

    }
}
