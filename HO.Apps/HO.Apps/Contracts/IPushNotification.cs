using System;
using System.Collections.Generic;

namespace HO.Apps.Contracts
{
    public interface IPushNotification
    {
        void RegisterForPushNotifications();
    }

    public class IncomingPushNotificationEventArgs : EventArgs
    {
        public Dictionary<string, object> Payload
        {
            get;
            set;
        }
    }
}