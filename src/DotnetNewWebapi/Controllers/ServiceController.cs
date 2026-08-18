using DotnetNewWebapi.Config;
using DotnetNewWebapi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace DotnetNewWebapi.Controllers;

[ApiController]
[Route("")]
public class CServicesController: ControllerBase
{
    ISingletonService m_SingleService;
    IScopedService m_ScopedService;
    ITransientService m_TransientService;
    IOptions<CApplicationOptions> m_AppOptions;
    IOptions<CExternalApiOptions> m_ExtApiOptions;

    public CServicesController
    (
        IOptions<CApplicationOptions> p_AppOptions,
        IOptions<CExternalApiOptions> p_ExtApiOptions,
        ISingletonService p_SingleService,
        IScopedService p_ScopedService,
        ITransientService p_TransientService
    )
    {
        m_SingleService = p_SingleService;   
        m_ScopedService = p_ScopedService;
        m_TransientService = p_TransientService;

        m_AppOptions = p_AppOptions;
        m_ExtApiOptions = p_ExtApiOptions;
    }
    
    [HttpGet("lifetime")]
    public IEnumerable<Guid> GetServiceIDs()
    {
        return new Guid[3]
        {
            m_SingleService.InstanceId,
            m_ScopedService.InstanceId,
            m_TransientService.InstanceId
        };
    }

    [HttpGet("configuration")]
    public IActionResult GetConfigVals()
    {
        string v_FirstPart = JsonSerializer.Serialize(m_AppOptions);
        string v_SecondPart = JsonSerializer.Serialize(m_ExtApiOptions);

        return Ok(
            new
            {
                Application = m_AppOptions.Value,
                ExternalApi = m_ExtApiOptions.Value          
            }
        );
    }
}