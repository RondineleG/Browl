﻿using System.Threading.Tasks;
using Browl.Service.DataNormalization.Application.Exceptions;
using Browl.Service.DataNormalization.Domain.Repositories;
using Browl.Service.DataNormalization.Shared.Abstractions.Commands;

namespace Browl.Service.DataNormalization.Application.Commands.Handlers
{
    internal sealed class PackItemHandler : ICommandHandler<PackItem>
    {
        private readonly IPackingListRepository _repository;

        public PackItemHandler(IPackingListRepository repository)
            => _repository = repository;

        public async Task HandleAsync(PackItem command)
        {
            var packingList = await _repository.GetAsync(command.PackingListId);

            if (packingList is null)
            {
                throw new PackingListNotFoundException(command.PackingListId);
            }
            
            packingList.PackItem(command.Name);
            
            await _repository.UpdateAsync(packingList);
        }
    }
}