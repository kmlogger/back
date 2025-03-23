using System;
using Application.BackGround;

namespace Presentation.BackGround;

public class LogTransferWorker : BackgroundService
{
    private readonly LogTransferJob  _job;
    private readonly ILogger<LogTransferWorker> _logger;

    public LogTransferWorker(LogTransferJob job, ILogger<LogTransferWorker> logger)
    {
        _job = job;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Iniciando job de transferência de logs...");
            try
            {
                await _job.ExecuteAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro durante execução do job.");
            }

            // Executar 1x por dia
            await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
        }
    }
}