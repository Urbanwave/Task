using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Songs.Hubs;

namespace Songs.Services
{
    public class HubService
    {
        public void SendMessage(string message)
        {
            // Получаем контекст хаба
            var context =
                Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            // отправляем сообщение
            context.Clients.All.displayMessage(message);
        }
    }
}