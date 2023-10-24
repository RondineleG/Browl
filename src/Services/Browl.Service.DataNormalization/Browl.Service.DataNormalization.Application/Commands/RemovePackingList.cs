using System;
using Browl.Service.DataNormalization.Shared.Abstractions.Commands;

namespace Browl.Service.DataNormalization.Application.Commands
{
    public record RemovePackingList(Guid Id) : ICommand;
}