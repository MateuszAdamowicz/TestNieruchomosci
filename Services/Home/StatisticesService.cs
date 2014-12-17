using System;
using System.Collections.Generic;
using System.Linq;
using Context;
using Models.ApplicationModels;
using Models.EntityModels;
using Models.ViewModels;

namespace Services.Home
{
    public class StatisticesService : IStatisticesService
    {
        private readonly IApplicationContext _applicationContext;

        public StatisticesService(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public Result AddDailyUser(string session)
        {
            var statistices = _applicationContext.Statisticses.ToList();

            var stat = statistices.Where(x => x.CreatedAt.Date == DateTime.Now.Date).FirstOrDefault();


            if (stat == null)
            {
                var newStat = new Statistics();
                newStat.Sessions = new List<Session>();
                newStat.Sessions.Add(new Session{SessionId = session});
                _applicationContext.Statisticses.Add(newStat);
            }
            else
            {
                if (stat.Sessions == null)
                {
                    stat.Sessions = new List<Session>();
                }
                if (stat.Sessions.Count(x => x.SessionId == session) > 0)
                {
                    return new Result(false, null, "");
                }

                stat.Sessions.Add(new Session{SessionId = session});
            };
            _applicationContext.SaveChanges();
            return new Result(true, null, "");
        }

        public Result AddDailyView(string number)
        {
            var statistices = _applicationContext.Statisticses.ToList();

            var stat = statistices.Where(x => x.CreatedAt.Date == DateTime.Now.Date).FirstOrDefault();

            if (stat == null)
            {
                var newStat = new Statistics();
                newStat.Visits = new List<Visit>();
                newStat.Visits.Add(new Visit {Number = number, Count = 1});
                _applicationContext.Statisticses.Add(newStat);
            }
            else
            {
                if (stat.Visits == null)
                {
                    stat.Visits = new List<Visit>();
                }
                var visited = stat.Visits.FirstOrDefault(x => x.Number == number);

                if (visited == null)
                {
                    stat.Visits.Add(new Visit {Count = 1, Number = number});
                }
                else
                {
                    visited.Count += 1;
                }
            }
            _applicationContext.SaveChanges();
            return new Result(true, null, "");
        }
    }
}