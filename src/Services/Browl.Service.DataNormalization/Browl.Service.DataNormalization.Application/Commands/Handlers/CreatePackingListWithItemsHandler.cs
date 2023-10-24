using System.Threading.Tasks;
using Browl.Service.DataNormalization.Application.Exceptions;
using Browl.Service.DataNormalization.Application.Services;
using Browl.Service.DataNormalization.Domain.Factories;
using Browl.Service.DataNormalization.Domain.Repositories;
using Browl.Service.DataNormalization.Domain.ValueObjects;
using Browl.Service.DataNormalization.Shared.Abstractions.Commands;

namespace Browl.Service.DataNormalization.Application.Commands.Handlers
{
    public class CreatePackingListWithItemsHandler : ICommandHandler<CreatePackingListWithItems>
    {
        private readonly IPackingListRepository _repository;
        private readonly IPackingListFactory _factory;
        private readonly IPackingListReadService _readService;
        private readonly IWeatherService _weatherService;

        public CreatePackingListWithItemsHandler(IPackingListRepository repository, IPackingListFactory factory, 
            IPackingListReadService readService, IWeatherService weatherService)
        {
            _repository = repository;
            _factory = factory;
            _readService = readService;
            _weatherService = weatherService;
        }

        public async Task HandleAsync(CreatePackingListWithItems command)
        {
            var (id, name, days, gender, localizationWriteModel) = command;
            
            if (await _readService.ExistsByNameAsync(name))
            {
                throw new PackingListAlreadyExistsException(name);
            }

            var localization = new Localization(localizationWriteModel.City, localizationWriteModel.Country);
            var weather = await _weatherService.GetWeatherAsync(localization);

            if (weather is null)
            {
                throw new MissingLocalizationWeatherException(localization);
            } 

            var packingList = _factory.CreateWithDefaultItems(id, name, days, gender, weather.Temperature, 
                localization);

            await _repository.AddAsync(packingList);
        }
    }
}