using SQLite.Net.Attributes;

namespace HO.Apps.Models
{
    public class LanguagePack
    {
        [PrimaryKey]
        public int LanguagePackId { get; set; }

        [NotNull]
        public string StringKey { get; set; }

        [Column("en-US")]
        public string EnUS { get; set; }

        [Column("es")]
        public string ES { get; set; }

        [Column("zh-CN")]
        public string ZHCN { get; set; }

        [Column("fr-CA")]
        public string FrCA { get; set; }
    }
}
