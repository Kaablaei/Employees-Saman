using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.Extensions.Hosting;

namespace Application.Services
{
    public class DailyStatsUpdater :BackgroundService
    {
        private readonly IDailyCacheService _cache;

        public DailyStatsUpdater(IDailyCacheService cache)
        {
            _cache = cache;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var now = DateTime.Now;
                var next = DateTime.Today.AddDays(1).AddMinutes(1);

                var delay = next - now;

                await Task.Delay(delay, stoppingToken);

                _cache.UpdateStats();
            }
        }
    }
}
