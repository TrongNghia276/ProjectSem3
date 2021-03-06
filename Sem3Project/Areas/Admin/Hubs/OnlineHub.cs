using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sem3Project.Areas.Admin.Hubs
{
    public class OnlineHub : Hub
    {
        private static int Count;

        public override Task OnConnectedAsync()
        {
            Count++;
            base.OnConnectedAsync();
            this.Clients.All.SendAsync("updateCount", Count);
            return Task.CompletedTask;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Count--;
            base.OnDisconnectedAsync(exception);
            this.Clients.All.SendAsync("updateCount", Count);
            return Task.CompletedTask;
        }
    }
}
