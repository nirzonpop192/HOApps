using SQLite.Net.Attributes;
using System;

namespace HO.Apps.Models
{
    public class milkDigitalID
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        [NotNull]
        public string NickName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Age { get; set; }
        public string Gender { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BloodType { get; set; }
        public string DistinguishingMarks { get; set; }
        public string Contact { get; set; }
        public string Comments { get; set; }
        public byte[] PortraitView { get; set; }
        public string ImagePortraitView { get; set; }
        public byte[] SideView { get; set; }
        public string ImageSideView { get; set; }
        public DateTime PhotoDate { get; set; }
        public string Race { get; set; }
        public string Glasses { get; set; }
    }
}
