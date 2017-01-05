using HO.Apps.Models;
using System.Collections.Generic;

namespace HO.Apps.Contracts
{
    public interface IChildrenService
    {
        List<Child> Children { get; set; }
    }
}
