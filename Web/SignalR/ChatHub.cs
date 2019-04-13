using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atheneum.Interface;
using Atheneum.Dto.Chat;

namespace Web.SignalR
{
    public class ChatHub : Hub<IChatHub>
    {

        //public async Task BroadCastMessage(string msg)
        //{
        //    await this.Clients.All.SendAsync("Send", msg);
        //}

    }
}
