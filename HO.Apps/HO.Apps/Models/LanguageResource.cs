using SQLite.Net.Attributes;
using System;

namespace HO.Apps.Models
{
    public class LanguageResource
    {
        public int LanguageResourceId { get; set; }
        public Guid LanguageKey { get; set; }
        public string ResourceName { get; set; }
        public string ResourceValue { get; set; }

        [NotNull]
        public Guid ResourceKey { get; set; }
    }
}
