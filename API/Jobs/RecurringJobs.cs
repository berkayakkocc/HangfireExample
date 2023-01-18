using Core.Interfaces.Jobs;
using Hangfire;
using Hangfire.Common;
using Service;

namespace API.Jobs
{
    public static class RecurringJobs
    {
        [Obsolete]
        public static void HangfireJob()
        {
            JobService jobs = new();
            RecurringJob.AddOrUpdate<IJobService>(nameof(jobs.MailSend), x =>
             x.MailSend(), Cron.Daily(14, 50), TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time"));
        }
    }
}
