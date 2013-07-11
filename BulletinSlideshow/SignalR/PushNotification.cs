using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace BulletinSlideshow
{
    public class PushNotification : Hub
    {
        public void Refresh()
        {
            // Call the refreshPage method to update clients.
            Clients.All.refreshPage();
        }
    }
}