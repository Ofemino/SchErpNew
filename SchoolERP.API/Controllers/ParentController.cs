using Microsoft.AspNetCore.Mvc;

namespace SchoolERP.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ParentController : ControllerBase
{
   private readonly ILogger<ParentController> _logger;

   public ParentController(ILogger<ParentController> logger)
   {
      _logger = logger;
   }
}