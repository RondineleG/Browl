using Browl.Shared.Constants.Application;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace Browl.Client.Extensions
{
    public static class HubExtensions
    {
        public static HubConnection TryInitialize(this HubConnection hubConnection, NavigationManager navigationManager)
        {
            if (hubConnection == null)
            {
                hubConnection = new HubConnectionBuilder().WithUrl(navigationManager.ToAbsoluteUri(ApplicationConstants.SignalR.HubUrl)).Build();
            }
            return hubConnection;
        }
    }
}