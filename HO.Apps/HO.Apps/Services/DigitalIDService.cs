using HO.Apps.Contracts;
using HO.Apps.Data;
using HO.Apps.Models;
using HO.Apps.Services;
using Java.Lang;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

[assembly: Dependency(typeof(DigitalIDService))]
namespace HO.Apps.Services
{
    public class DigitalIDService : IDigitalIDService
    {
        private readonly SQLiteClientBase<DigitalId> _digitalIdContext;
        private readonly ILogService _logService;
        public DigitalIDService()
        {
            _digitalIdContext = new SQLiteClientBase<DigitalId>();
            _logService = DependencyService.Get<ILogService>();
        }
        public void CreateDigitalID(DigitalId digitalId)
        {
            try
            {
                _digitalIdContext.Save(digitalId);
            }
            catch (Exception ex)
            {
                _logService.LogException(ex);
            }
        }

        public DigitalId GetDigitalID(int id)
        {
            return _digitalIdContext.Get(id);
        }

        public List<DigitalId> GetDigitalIDs()
        {
            return _digitalIdContext.All().ToList();
        }

        public void UpdateDigitalID(DigitalId digitalId)
        {
            try
            {
                _digitalIdContext.Update(digitalId);
            }
            catch (Exception ex)
            {
                _logService.LogException(ex);
            }
        }
    }
}
