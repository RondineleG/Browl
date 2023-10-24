using System;
using System.Threading.Tasks;
using Browl.Service.DataNormalization.Application.DTO.External;
using Browl.Service.DataNormalization.Application.Services;
using Browl.Service.DataNormalization.Domain.ValueObjects;

namespace Browl.Service.DataNormalization.Infrastructure.Services
{
    internal sealed class DumbWeatherService : IWeatherService
    {
        public Task<WeatherDto> GetWeatherAsync(Localization localization)
            => Task.FromResult(new WeatherDto(new Random().Next(5, 30)));
    }
}