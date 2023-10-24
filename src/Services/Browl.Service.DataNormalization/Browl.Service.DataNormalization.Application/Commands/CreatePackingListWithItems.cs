using System;
using Browl.Service.DataNormalization.Domain.Consts;
using Browl.Service.DataNormalization.Shared.Abstractions.Commands;

namespace Browl.Service.DataNormalization.Application.Commands
{
    public record CreatePackingListWithItems(Guid Id, string Name, ushort Days, Gender Gender,
        LocalizationWriteModel Localization) : ICommand;

    public record LocalizationWriteModel(string City, string Country);
}