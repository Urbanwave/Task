using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Owin;
using SongsLogicLayer.Services;
using Songs.Hubs;
using Microsoft.Owin.Hosting;
using Songs.Services;
using Microsoft.AspNet.SignalR.Client;


namespace Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            ParseService ParseService = new ParseService();
            ParseService.ParseSingersName(1);
            LoggerService Log = new LoggerService();
            int SongsAmount = 0;

            for (int i = 0; i < 30; i++)
            {
                Log.TryLog("\r\nИсполнитель: " + ParseService.AllSingersNames[i] + "\r\nКоличество песен: " + ParseService.AllSingerSongsAmountAndViews[i * 2]);
                SongsAmount += Convert.ToInt32(ParseService.AllSingerSongsAmountAndViews[i * 2]);
            }

            IHubProxy _hub;
            string url = @"http://localhost:63373/";
            var connection = new HubConnection(url);
            _hub = connection.CreateHubProxy("TestHub");
            connection.Start().Wait();
            _hub.Invoke("Send", SongsAmount.ToString()).Wait();

        }
    }
}
