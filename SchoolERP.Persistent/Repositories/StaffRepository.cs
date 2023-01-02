using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SchoolERP.Domain.Dtos.Out;
using SchoolERP.Persistent.IRepositories;

namespace SchoolERP.Persistent.Repositories;

public class StaffRepository : IStaffRepository
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<StudentRepository> _logger;
    private List<StudentDtoOut> StudentDtoOuts { get; set; } 
    public StaffRepository(IConfiguration configuration, ILogger<StudentRepository> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }
    
    public async Task<List<StaffDtoOut>> GetStaffs()
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

    public Task<StaffDtoOut> GetStaffById(long id)
    {
        throw new NotImplementedException();
    }

    public Task<List<StaffDtoOut>> GetStaffByClass(string className)
    {
        throw new NotImplementedException();
    }

    public Task<List<StaffDtoOut>> GetStaffByName(string name)
    {
        throw new NotImplementedException();
    }
}