using SQLite.Net.Attributes;
using System;

namespace HO.Apps.Models
{
    public class Sponsor
    {
        public Sponsor()
        {
            DateCreated = DateTime.UtcNow;
            LastModified = DateTime.UtcNow;
            StatusId = 10;
        }
        [PrimaryKey]
        public Guid SponsorKey { get; set; }

        [NotNull]
        [MaxLength(100)]
        public string SponsorName { get; set; }
        public string SponsorDescription { get; set; }
        public string SponsorIcon { get; set; }
        public string SponsorUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public int StatusId { get; set; }
        public string MiscData { get; set; }
    }
}
