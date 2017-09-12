using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace MP.Hubs
{
    public class ChatHub : Hub
    {
        public static Propertyclass pro = new Propertyclass();
        public void Send()
        {
            Clients.All.send("{trang: 'abc'}");
        }
        public static void Show()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context.Clients.All.displayStatus(pro.data);
        }
    }
}