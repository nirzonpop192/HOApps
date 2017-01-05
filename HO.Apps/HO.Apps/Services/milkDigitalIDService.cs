using HO.Apps.Contracts;
using HO.Apps.Data;
using HO.Apps.Models;
using HO.Apps.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

[assembly: Dependency(typeof(milkDigitalIDService))]
namespace HO.Apps.Services
{
    public class milkDigitalIDService : ImilkDigitalIDService
    {
        private readonly SQLiteClientBase<milkDigitalID> _milkDigitalIdContext;
        private readonly ILogService _logService;
        public milkDigitalIDService()
        {
            _milkDigitalIdContext = new SQLiteClientBase<milkDigitalID>();
            _logService = DependencyService.Get<ILogService>();
        }
        public void CreateDigitalID(milkDigitalID digitalId)
        {
            try
            {
                _milkDigitalIdContext.Save(digitalId);
            }
            catch (Exception ex)
            {
                _logService.LogException(ex);
            }
        }

        public milkDigitalID GetDigitalID(int id)
        {
            return _milkDigitalIdContext.Get(id);
        }

        public List<milkDigitalID> GetDigitalIDs()
        {
            return _milkDigitalIdContext.All().ToList();
        }

        public void UpdateDigitalID(milkDigitalID digitalId)
        {
            try
            {
                _milkDigitalIdContext.Update(digitalId);
            }
            catch (Exception ex)
            {
                _logService.LogException(ex);
            }
        }
    }
}
