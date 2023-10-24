﻿using System.Threading.Tasks;
using Browl.Service.DataNormalization.Application.Exceptions;
using Browl.Service.DataNormalization.Domain.Repositories;
using Browl.Service.DataNormalization.Domain.ValueObjects;
using Browl.Service.DataNormalization.Shared.Abstractions.Commands;

namespace Browl.Service.DataNormalization.Application.Commands.Handlers
{
    internal sealed class AddPackingItemHandler : ICommandHandler<AddPackingItem>
    {
        private readonly IPackingListRepository _repository;

        public AddPackingItemHandler(IPackingListRepository repository)
            => _repository = repository;

        public async Task HandleAsync(AddPackingItem command)
        {
            var packingList = await _repository.GetAsync(command.PackingListId);

            if (packingList is null)
            {
                throw new PackingListNotFoundException(command.PackingListId);
            }

            var packingItem = new PackingItem(command.Name, command.Quantity);
            packingList.AddItem(packingItem);

            await _repository.UpdateAsync(packingList);
        }
    }
}