using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain.Requests.Enums;
using Infrastructure.EF_Core;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services
{
    public  class DailyCacheService : IDailyCacheService
    {
        private DailyStatsDTO _stats;
        private readonly IServiceProvider _provider;

        public DailyCacheService(IServiceProvider provider)
        {
            _provider = provider;
            UpdateStats();
        }

        public DailyStatsDTO GetStats()
        {
            return _stats;
        }

        public void UpdateStats()
        {

            using var scope = _provider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var today = DateTime.Today;

            _stats = new DailyStatsDTO
            {
                Total = context.Requests.Count(r => r.CratedDate.Date == today),
                Accepted = context.Requests.Count(r => r.CratedDate.Date == today && r.Status == RequestStatus.Accepted),
                Rejected = context.Requests.Count(r => r.CratedDate.Date == today && r.Status == RequestStatus.Rejected)
            };
        }
    }
}
