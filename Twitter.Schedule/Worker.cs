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
        private string _mensagem;

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
                
                try
                {
                    Twieets.ObterTweets();
                    _mensagem = "Dados recuperados do Twitter e salvos na Base";
                }
                catch (Exception e)
                {
                    _mensagem = "Falha na recuperação de dados do Twitter";
                    var log = e.Message;
                }
                finally
                {
                    _logger.LogInformation(_mensagem, DateTimeOffset.Now);
                    await Task.Delay(50000, stoppingToken);
                }
            }
        }
    }
}
