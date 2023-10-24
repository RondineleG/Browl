using Browl.Service.AuthSecurity.API.Contracts.Notifications;

namespace Browl.Service.AuthSecurity.API.Abstractions.Infrastructure;

public interface INotificationService
{
	IResult SendNotification(SendNotificationRequest request);
}

