using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Twitter.Schedule.Context;
using Twitter.Schedule.DAL;
using Twitter.Schedule.Model;
using Twitter.Schedule.Service;
using Twitter.Schedule.ServiceApplication;

namespace Twitter.Schedule
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var Twieets = new TwitterApplication(_configuration);
                Twieets.ObterTweets();


                _logger.LogInformation("Dados recuperados do Twitter e salvos na Base", DateTimeOffset.Now);
                await Task.Delay(50000, stoppingToken);
            }
        }
    }
}
