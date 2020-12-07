using System.Threading;
using System.Threading.Tasks;
using Core.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace WorkerService
{
    public class Worker : IHostedService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _services;

        public Worker(ILogger<Worker> logger, IServiceProvider services)
        {
            _logger = logger;
            _services = services;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                using (var scope = _services.CreateScope())
                {
                    var scopedProcessingService =
                        scope.ServiceProvider
                            .GetRequiredService<IHolidayOffersService>();

                    await scopedProcessingService.RefreshAllOffers();
                }


                await Task.Delay(3000 * 1000);
               
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
