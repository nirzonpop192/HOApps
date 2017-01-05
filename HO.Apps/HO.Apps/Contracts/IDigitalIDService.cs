using HO.Apps.Models;
using System.Collections.Generic;

namespace HO.Apps.Contracts
{
    public interface IDigitalIDService
    {
        List<DigitalId> GetDigitalIDs();
        DigitalId GetDigitalID(int id);
        void CreateDigitalID(DigitalId digitalId);
        void UpdateDigitalID(DigitalId digitalId);
    }
}
