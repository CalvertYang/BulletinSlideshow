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

            // Call the addInformationTab method to add information category
            Clients.All.addInformationTab();

            // Call the addInformationTab method to add information content
            Clients.All.addInformationContent();
        }
    }
}