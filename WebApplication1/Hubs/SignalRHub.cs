using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Hubs
{
    public class SignalRHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            ConnectedUser.Ids.Add(Context.ConnectionId);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            ConnectedUser.Ids.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
