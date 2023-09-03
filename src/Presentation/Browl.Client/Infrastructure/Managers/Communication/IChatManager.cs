using Browl.Application.Interfaces.Chat;
using Browl.Application.Models.Chat;
using Browl.Application.Responses.Identity;
using Browl.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Browl.Client.Infrastructure.Managers.Communication
{
    public interface IChatManager : IManager
    {
        Task<IResult<IEnumerable<ChatUserResponse>>> GetChatUsersAsync();

        Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> chatHistory);

        Task<IResult<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string cId);
    }
}