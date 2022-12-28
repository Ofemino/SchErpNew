using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SchoolERP.Domain.Dtos.Out;
using SchoolERP.Persistent.IRepositories;

namespace SchoolERP.Persistent.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<StudentRepository> _logger;
    public List<StudentDtoOut> StudentDtoOuts { get; set; } 
    public StudentRepository(IConfiguration configuration, ILogger<StudentRepository> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }
    public async Task<List<StudentDtoOut>> GetStudents()
    {
        try
        {
            StudentDtoOuts = new List<StudentDtoOut>();
            
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
        }

        return null;
    }
}