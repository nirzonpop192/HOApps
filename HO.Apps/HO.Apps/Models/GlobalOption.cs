using SQLite.Net.Attributes;

namespace HO.Apps.Models
{
    public class GlobalOption
    {
        [PrimaryKey, MaxLength(100)]
        public string OptionKey { get; set; }

        [NotNull]
        public string OptionValue { get; set; }
    }
}
