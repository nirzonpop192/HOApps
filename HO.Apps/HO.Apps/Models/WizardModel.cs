using HO.Apps.Messaging;
using System;

namespace HO.Apps.Models
{
    public class FirstStepModel
    {
        public MediaFileResponse FrontPhoto { get; set; }
        public MediaFileResponse SidePhoto { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string NickName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
    }

    public class FinalStepModel
    {
        public string CurrentAge { get; set; }
        public string HairColor { get; set; }
        public string BloodType { get; set; }
        public string EyeColor { get; set; }
        public string Race { get; set; }
        public string Glasses { get; set; }
        public string DistinguishingMarks { get; set; }
        public string Contact { get; set; }
        public string Comments { get; set; }
    }
}
