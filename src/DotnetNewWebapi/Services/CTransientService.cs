namespace DotnetNewWebapi.Services;

public interface ITransientService
{
    public Guid InstanceId {get;}
}

public class CTransientService: ITransientService
{
    private Guid m_Guid = Guid.NewGuid();

    public CTransientService(ILogger<CTransientService> p_Logger)
    {
        p_Logger.LogInformation("Transient created");
    }

    public Guid InstanceId 
    {
        get {return this.m_Guid;}
    }
}