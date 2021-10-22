using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Twitter.Schedule.Context;
using Twitter.Schedule.DAL;
using Twitter.Schedule.Model;
using Twitter.Schedule.Service;

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
                //var authenticationService = new AuthenticationService(_configuration);
                //authenticationService.GetAuthentication();             

                var tweetService = new TweetService(_configuration);                
                var getTweets = await tweetService.GetTweets();
                var _context = new AppDbContext(_configuration);
                var tweetDao = new TweetDao(_context);
                    tweetDao.Inserir(getTweets);

                _logger.LogInformation("Dados recuperados do Twitter e salvos na Base", DateTimeOffset.Now);
                await Task.Delay(50000, stoppingToken);
            }
        }
    }
}
