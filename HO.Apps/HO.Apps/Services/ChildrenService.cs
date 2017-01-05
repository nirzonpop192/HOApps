using HO.Apps.Contracts;
using HO.Apps.Models;
using HO.Apps.Services;
using System.Collections.Generic;
using Xamarin.Forms;

[assembly: Dependency(typeof(ChildrenService))]
namespace HO.Apps.Services
{
    public class ChildrenService : IChildrenService
    {
        public ChildrenService()
        {
            Children = GetChildren();
        }
        public List<Child> Children { get; set; }

        private List<Child> GetChildren()
        {
            return new List<Child>
            {
                new Child (100, "Afsana", "icon.png"),
                new Child (200, "Shaon", "icon.png"),
                new Child (300, "Samia", "icon.png"),
                new Child (400, "Tanha", "icon.png"),
                new Child (500, "Nawshad", "icon.png"),
            };
        }
    }
}
