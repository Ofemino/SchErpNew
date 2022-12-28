using Microsoft.AspNetCore.Mvc;
using SchoolERP.Services.Interfaces;

namespace SchoolERP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentServices _studentServices;
    private readonly ILogger<StudentController> _logger;

    public StudentController(IStudentServices studentServices, ILogger<StudentController> logger)
    {
        _studentServices = studentServices;
        _logger = logger;
    }

    [HttpGet("GetAllStudents")]
    public async Task<IActionResult> GetAllStudents()
    {
        try
        {
            var allStudents = await _studentServices.GetStudents();
            return Ok(allStudents);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error getting all students. ex : {S}", ex.ToString());
            Console.WriteLine(ex);
        }
        return BadRequest();
    }
    
    [HttpGet("GetStudentById/{id}")]
    public async Task<IActionResult> GetStudentById(long id)
    {
        try
        {
            var allStudents = await _studentServices.GetStudentById(id);
            return Ok(allStudents);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error getting all students. ex : {S}", ex.ToString());
            Console.WriteLine(ex);
        }
        return BadRequest();
    }
    
    [HttpGet("GetStudentsByClass/{className}")]
    public async Task<IActionResult> GetStudentsByClass(string className){
        try
        {
            var allStudents = await _studentServices.GetStudentByClass(className);
            return Ok(allStudents);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error getting all students. ex : {S}", ex.ToString());
            Console.WriteLine(ex);
        }
        return BadRequest();
    }
    
    [HttpGet("GetStudentsByName/{name}")]
    public async Task<IActionResult> GetStudentsByName(string name){
        try
        {
            var students = await _studentServices.GetStudentByName(name);
            return Ok(students);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error getting all students. ex : {S}", ex.ToString());
            Console.WriteLine(ex);
        }
        return BadRequest();
    }
}