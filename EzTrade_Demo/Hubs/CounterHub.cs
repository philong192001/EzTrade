using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzTrade_Demo.Hubs
{
    public class CounterHub : Hub
    {
        public static List<string> Users = new List<string>();

        
        //public void Send(int count)
        //{
        //    // Call the addNewMessageToPage method to update clients.
        //    var context = GlobalHost.ConnectionManager.GetHubContext<CounterHub>();
        //    context.Clients.All.updateUsersOnlineCount(count);
        //}

        //public override async Task OnConnectedAsync()
        //{
        //    string clientId = GetClientId();

        //    if (Users.IndexOf(clientId) == -1)
        //    {
        //        Users.Add(clientId);
        //    }

        //    // Send the current count of users
        //    Send(Users.Count);

        //    return base.OnConnected();
        //}

        //public override Task OnReconnected()
        //{
        //    string clientId = GetClientId();
        //    if (Users.IndexOf(clientId) == -1)
        //    {
        //        Users.Add(clientId);
        //    }

        //    // Send the current count of users
        //    Send(Users.Count);

        //    return base.OnReconnected();
        //}

        //public override Task OnDisconnected()
        //{
        //    string clientId = GetClientId();

        //    if (Users.IndexOf(clientId) > -1)
        //    {
        //        Users.Remove(clientId);
        //    }

        //    // Send the current count of users
        //    Send(Users.Count);

        //    return base.OnDisconnected();
        //}

        //private string GetClientId()
        //{
        //    string clientId = "";
        //    if (Context.QueryString["clientId"] != null)
        //    {
        //        // clientId passed from application 
        //        clientId = this.Context.QueryString["clientId"];
        //    }

        //    if (string.IsNullOrEmpty(clientId.Trim()))
        //    {
        //        clientId = Context.ConnectionId;
        //    }

        //    return clientId;
        //}
    }
}
