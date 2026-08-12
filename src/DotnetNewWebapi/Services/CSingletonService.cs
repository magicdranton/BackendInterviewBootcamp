namespace DotnetNewWebapi.Services;

public interface ISingletonService
{
    public Guid InstanceId {get;}
}

public class CSingletonService: ISingletonService
{
    private Guid m_Guid = Guid.NewGuid();

    public CSingletonService(ILogger<CSingletonService> p_Logger)
    {
        p_Logger.LogInformation("Singleton created");
    }

    public Guid InstanceId 
    {
        get {return this.m_Guid;}
    }
}