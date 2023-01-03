using Microsoft.AspNetCore.Mvc;
using SchoolERP.Services.Interfaces;

namespace SchoolERP.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ParentController : ControllerBase
{
   private readonly ILogger<ParentController> _logger;
   private readonly IParentServices _parentServices;

   public ParentController(ILogger<ParentController> logger, IParentServices parentServices)
   {
      _logger = logger;
      _parentServices = parentServices;
   }
}