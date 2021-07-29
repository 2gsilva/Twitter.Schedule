using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Twitter.Schedule.Model;
using Twitter.Schedule.Service;

namespace Twitter.Schedule
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // var authenticationService = new AuthenticationService();
                // var authentication = new Authentication();
                var TweetService = new TweetService();
                
                TweetsRetorno getTweets = await TweetService.GetTweets();

                // authenticationService.GetAuthentication(authentication);

                _logger.LogInformation("Isso é um teste.", DateTimeOffset.Now);
                await Task.Delay(50000, stoppingToken);
            }
        }
    }
}
