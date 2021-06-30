using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace Sem3Project.Areas.Admin.Hubs
{
    public class ChatHub : Hub
    {

        public async Task SendMessage(string user, string message,string image)
        {
           
            await Clients.All.SendAsync("ReceiveMessage", user, message, image);
        }
       
    }
}
