using System;
using System.Collections.Generic;
using System.Text;
using Twitter.Schedule.Context;
using Twitter.Schedule.Model;

namespace Twitter.Schedule.DAL
{
    class TweetDao
    {
        private readonly AppDbContext _context;

        public TweetDao(AppDbContext context)
        {
            _context = context;
        }

        public void Inserir(TweetsRetorno tweets)
        {
            try
            {
                foreach(var t in tweets.Data)
                {
                   var tweet = new Tweet
                    {
                        Authorid = t.Authorid,
                        Text = t.Text
                    };

                    _context.Tweets.Add(tweet);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.GetType();
            }
        }
    }
}
