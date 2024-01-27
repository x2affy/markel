﻿namespace Markel.DomainObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class Claim
    {
        // ReSharper disable once InconsistentNaming
        public string? UCR { get; set; }
        public int CompanyId { get; set; }
        public DateTime ClaimDate { get; set; }
        public DateTime LossDate { get; set; }
        public string? AssuredName { get; set; }
        public decimal IncurredLoss { get; set; }
        public bool Closed { get; set; }

        // nothing linking claim to claimtype data, so added key
        public int ClaimTypeId { get; set; }
        public ClaimType? ClaimType { get; set; }
    }
}
