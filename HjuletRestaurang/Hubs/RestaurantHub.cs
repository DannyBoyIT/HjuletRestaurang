using Microsoft.AspNet.SignalR;

namespace HjuletRestaurang.Hubs
{
    public class RestaurantHub : Hub
    {
        public void Hello(string message)
        {
            Clients.All.hello(message);
        }
    }
}