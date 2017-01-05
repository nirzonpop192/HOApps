using HO.Apps.Models;
using System.Collections.Generic;

namespace HO.Apps.Contracts
{
    public interface ISponsorService
    {
        List<Sponsor> GetSponsors();
        List<Sponsor> GetDownloadedSponsors();
        Sponsor GetSponsor(int id);
        void SaveSponsor(Sponsor sponsor);
        void SaveSponsor(SponsorZip sponsorZip);
    }
}
