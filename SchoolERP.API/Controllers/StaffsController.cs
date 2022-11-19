using Microsoft.AspNetCore.Mvc;
using SchoolERP.Services;

namespace SchoolERP.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class StaffsController : ControllerBase
{
    private readonly IStaffServices _staffServices;
    private readonly ILogger<StaffsController> _logger;

    public StaffsController(IStaffServices staffServices, ILogger<StaffsController> logger)
    {
        _staffServices = staffServices;
        _logger = logger;
    }
    
    
}