namespace DotnetNewWebapi.Services;

public interface IScopedService
{
    public Guid InstanceId {get;}
}

public class CScopedService: IScopedService
{
    private Guid m_Guid = Guid.NewGuid();

    public CScopedService(ILogger<CScopedService> p_Logger)
    {
        p_Logger.LogInformation("Scoped created");
    }

    public Guid InstanceId 
    {
        get {return this.m_Guid;}
    }
}