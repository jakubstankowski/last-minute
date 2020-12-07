using System.Threading;
using System.Threading.Tasks;
using Core.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;

namespace WorkerService
{
    public class Worker : IHostedService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHolidayOffersService _holidayOffersService;

        public Worker(ILogger<Worker> logger, IHolidayOffersService holidayOffersService)
        {
            _logger = logger;
            _holidayOffersService = holidayOffersService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(10000);
                await _holidayOffersService.RefreshAllOffers();
                _logger.LogInformation("Hosted service call refresh holiday offers method");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Printing worker stopping");
            return Task.CompletedTask;
        }
    }
}
