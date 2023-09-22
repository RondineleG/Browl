using Browl.Service.AuthSecurity.API.Contracts.Notifications;

namespace HyBe.Application.Abstractions.Infrastructure
{
	public interface INotificationService
	{
		IResult SendNotification(SendNotificationRequest request);
	}
}

