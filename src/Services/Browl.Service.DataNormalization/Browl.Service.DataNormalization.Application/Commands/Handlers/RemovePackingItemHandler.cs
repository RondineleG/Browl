using System.Threading.Tasks;
using Browl.Service.DataNormalization.Application.Exceptions;
using Browl.Service.DataNormalization.Domain.Repositories;
using Browl.Service.DataNormalization.Shared.Abstractions.Commands;

namespace Browl.Service.DataNormalization.Application.Commands.Handlers
{
    internal sealed class RemovePackingItemHandler : ICommandHandler<RemovePackingItem>
    {
        private readonly IPackingListRepository _repository;

        public RemovePackingItemHandler(IPackingListRepository repository)
            => _repository = repository;

        public async Task HandleAsync(RemovePackingItem command)
        {
            var packingList = await _repository.GetAsync(command.PackingListId);

            if (packingList is null)
            {
                throw new PackingListNotFoundException(command.PackingListId);
            }

            packingList.RemoveItem(command.Name);

            await _repository.UpdateAsync(packingList);
        }
    }
}