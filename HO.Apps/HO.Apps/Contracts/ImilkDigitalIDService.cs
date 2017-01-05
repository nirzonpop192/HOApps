using HO.Apps.Models;
using System.Collections.Generic;

namespace HO.Apps.Contracts
{
    public interface ImilkDigitalIDService
    {
        List<milkDigitalID> GetDigitalIDs();
        milkDigitalID GetDigitalID(int id);
        void CreateDigitalID(milkDigitalID digitalId);
        void UpdateDigitalID(milkDigitalID digitalId);
    }
}
