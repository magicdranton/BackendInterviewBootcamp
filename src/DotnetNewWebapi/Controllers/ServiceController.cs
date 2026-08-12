using DotnetNewWebapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetNewWebapi.Controllers;

[ApiController]
[Route("[controller]")]
public class CServicesController: ControllerBase
{
    ISingletonService m_SingleService;
    IScopedService m_ScopedService;
    ITransientService m_TransientService;
    public CServicesController
    (
        ISingletonService p_SingleService,
        IScopedService p_ScopedService,
        ITransientService p_TransientService
    )
    {
        m_SingleService = p_SingleService;   
        m_ScopedService = p_ScopedService;
        m_TransientService = p_TransientService;
    }
    
    [HttpGet(Name = "lifetime")]
    public IEnumerable<Guid> GetServiceIDs()
    {
        return new Guid[3]
        {
            m_SingleService.InstanceId,
            m_ScopedService.InstanceId,
            m_TransientService.InstanceId
        };
    }
}