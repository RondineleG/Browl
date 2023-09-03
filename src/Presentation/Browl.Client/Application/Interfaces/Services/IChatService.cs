using Browl.Application.Responses.Identity;
using Browl.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Browl.Application.Interfaces.Chat;
using Browl.Application.Models.Chat;

namespace Browl.Application.Interfaces.Services
{
    public interface IChatService
    {
        Task<Result<IEnumerable<ChatUserResponse>>> GetChatUsersAsync(string userId);

        Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> message);

        Task<Result<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string userId, string contactId);
    }
}