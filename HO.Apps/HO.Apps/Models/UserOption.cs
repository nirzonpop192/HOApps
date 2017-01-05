using SQLite.Net.Attributes;

namespace HO.Apps.Models
{
    public class UserOption
    {
        [PrimaryKey, AutoIncrement]
        public int UserOptionId { get; set; }

        [NotNull]
        public string UserName { get; set; }
        public string OptionValue { get; set; }
    }
}
