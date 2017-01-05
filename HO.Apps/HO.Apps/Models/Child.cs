namespace HO.Apps.Models
{
    public class Child
    {
        public int ChildId { get; set; }
        public string ChildName { get; set; }
        public string ChildAvatar { get; set; }
        public Child(int id, string name, string avatar)
        {
            ChildId = id;
            ChildName = name;
            ChildAvatar = avatar;
        }
    }
}