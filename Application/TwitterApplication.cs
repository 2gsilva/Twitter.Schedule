using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Twitter.Schedule.Context;
using Twitter.Schedule.DAL;
using Twitter.Schedule.Service;

namespace Twitter.Schedule.ServiceApplication
{
    public class TwitterApplication
    {
        private readonly IConfiguration _configuration;

        public TwitterApplication(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async void ObterTweets()
        { 
        var tweetService = new TweetService(_configuration);
        var getTweets = await tweetService.GetTweets();
        var _context = new AppDbContext(_configuration);
        var tweetDao = new TweetDao(_context);
        tweetDao.Inserir(getTweets);
        }
    }
}
