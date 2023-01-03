using Microsoft.AspNetCore.Mvc;
using SchoolERP.Domain.Dtos;
using SchoolERP.Domain.Dtos.Out;
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

    [HttpGet("GetStaffs")]
    public async Task<ActionResult> GetStaffs()
    {
        try
        {
            ResponseObject<StaffDtoOut> result = await _staffServices.GetStaffs();
            return Ok(result);
        }
        catch (Exception exc)
        {
            _logger.LogError($"Error occured in StaffsController GetStaffs {exc}");
        }

        return BadRequest();
    }

    [HttpGet("GetStaffById/{id}")]
    public async Task<ActionResult> GetStaffById(long id)
    {
        try
        {
            ResponseObject<StaffDtoOut> result = await _staffServices.GetStaffById(id);
            return Ok(result);
        }
        catch (Exception exc)
        {
            _logger.LogError($"Error occured in StaffsController GetStaffById {exc}");
        }

        return BadRequest(); 
    }

    [HttpGet("GetStaffByClass/{className}")]
    public async Task<ActionResult> GetStaffByClass(string className)
    {
        try
        {
            ResponseObject<StaffDtoOut> result = await _staffServices.GetStaffByClass(className);
            return Ok(result);
        }
        catch (Exception exc)
        {
            _logger.LogError($"Error occured in StaffsController GetStaffByClass {exc}");
        }

        return BadRequest(); 
    }

    [HttpGet("GetStaffByName/{name}")]
    public async Task<ActionResult> GetStaffByName(string name)
    {
        try
        {
            ResponseObject<StaffDtoOut> result = await _staffServices.GetStaffByName(name);
            return Ok(result);
        }
        catch (Exception exc)
        {
            _logger.LogError($"Error occured in StaffsController GetStaffByName {exc}");
        }

        return BadRequest(); 
    }
}