namespace DotnetNewWebapi.Services;

public class CSomeBackgroundService: BackgroundService
{
    private readonly ILogger<CSomeBackgroundService> m_Logger;

    public CSomeBackgroundService(ILogger<CSomeBackgroundService> p_Logger)
    {
        m_Logger = p_Logger;
    }

    public override async Task StartAsync(CancellationToken p_Token)
    {
        m_Logger.LogInformation("Background service started");
        await base.StartAsync(p_Token);
    }

    protected override async Task ExecuteAsync(CancellationToken p_Token)
    {
        try
        {
        while (!p_Token.IsCancellationRequested) 
        {
            await Task.Delay(5000, p_Token);
        }
        }
        catch(OperationCanceledException ex)
        {
            m_Logger.LogInformation("ExecuteAsync was canceled");
        }
    }

    public override async Task StopAsync(CancellationToken p_Token)
    {
        m_Logger.LogInformation("Background service stopped");
        await base.StopAsync(p_Token);
    }
}