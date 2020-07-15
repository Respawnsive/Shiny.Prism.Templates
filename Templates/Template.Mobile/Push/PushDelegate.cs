using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shiny.Notifications;
using Shiny.Push;
using Template.Mobile.Models;

namespace Template.Mobile.Push
{
    public class PushDelegate : IPushDelegate
    {
        private readonly INotificationManager _notificationManager;
        private readonly IPushManager _pushManager;


        public PushDelegate(INotificationManager notificationManager, IPushManager pushManager)
        {
            _notificationManager = notificationManager;
            _pushManager = pushManager;
        }

        public Task OnEntry(PushEntryArgs args)
            => Insert("PUSH ENTRY");

        public Task OnReceived(IDictionary<string, string> data)
            => Insert($"PUSH RECEIVED: { string.Join(',', data.Select(kvp => $"{kvp.Key}: {kvp.Value}"))}");

        public Task OnTokenChanged(string token)
            => Insert($"PUSH TOKEN CHANGE: {token}");

        Task Insert(string info) => Task.Run(() => Console.WriteLine(info));
    }
}
