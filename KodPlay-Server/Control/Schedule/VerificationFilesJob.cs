using Furion.Schedule;
using KodPlay_Server.Server.FileSys;

namespace KodPlay_Server.Control.Schedule
{
    [JobDetail("KodPlay - VerificationFilesJob", Concurrent = false, Description = "KodPlay - 文件系统 - 资产目录扫描作业")]
    [PeriodMinutes(1,TriggerId = "KodPlay - VerificationFilesJob")]
    public class VerificationFilesJob : IJob
    {

        private readonly ILogger<VerificationFilesJob> _logger;

        public VerificationFilesJob(ILogger<VerificationFilesJob> logger)
        {
            _logger = logger;
        }

        public Task ExecuteAsync(JobExecutingContext context, CancellationToken stoppingToken)
        {

            VerificationFiles.VerificationFolder();
            _logger.LogInformation(context.JobDetail.ConvertToMonitor());
            return Task.CompletedTask;
        }
    }
}
