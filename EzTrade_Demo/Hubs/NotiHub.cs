using EzTrade_Demo.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzTrade_Demo.Hubs
{
    public class NotiHub : Hub
    {
        public async Task SendNoti(string priceList)
        {
            await Clients.All.SendAsync("NotiMessage", priceList);
        }
        //public Task JoinGroup(string group)
        //{
        //     return Groups.AddToGroupAsync(Context.ConnectionId, group);
            
        //}
        //public Task SendNotiByGroup(string groupname,string sender,string message)
        //{
        //    return Clients.Group(groupname).SendAsync("SendNoti", sender, message);
        //}
    }
}
