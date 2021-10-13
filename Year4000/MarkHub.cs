using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Year4000
{
    public class MarkHub : Hub
    {
        public const string NewMark = "NewMark";

        public async Task SendMessage(decimal mark)
        {
            await Clients.All.SendAsync(NewMark, mark);
        }
    }
}
