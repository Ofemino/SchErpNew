using Microsoft.Extensions.Logging;
using SchoolERP.Domain.Dtos;
using SchoolERP.Domain.Dtos.Out;
using SchoolERP.Persistent.IRepositories;
using SchoolERP.Services.Interfaces;

namespace SchoolERP.Services;

public class StudentServices : IStudentServices
{
    private readonly ILogger<StudentServices> _logger;
    private readonly IStudentRepository _repository;
    private ResponseObject<StudentDtoOut> _response;

    public StudentServices(ILogger<StudentServices> logger, IStudentRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async Task<ResponseObject<StudentDtoOut>> GetStudents()
    {
        _response = new ResponseObject<StudentDtoOut>();
        try
        {
            var students = await _repository.GetStudents();
            if (students.Count > 0)
            {
                return new ResponseObject<StudentDtoOut>
                    { ObjectResponseList = students, ResponseMessage = "success" };
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Repo Error at GetStudents : {S}", ex.ToString());
            return new ResponseObject<StudentDtoOut>
                { ObjectResponseList = null, ResponseMessage = $"Error : {ex.Message}" };
        }

        return new ResponseObject<StudentDtoOut> { ObjectResponseList = null, ResponseMessage = "No record!" };
    }

    public async Task<ResponseObject<StudentDtoOut>> GetStudentById(long id)
    {
        _response = new ResponseObject<StudentDtoOut>();
        try
        {
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return new ResponseObject<StudentDtoOut>
                { ObjectResponseList = null, ResponseMessage = $"Error : {ex.Message}" };}

        return _response;
    }

    public async Task<ResponseObject<StudentDtoOut>> GetStudentByClass(string className)
    {
        _response = new ResponseObject<StudentDtoOut>();
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return new ResponseObject<StudentDtoOut>
                { ObjectResponseList = null, ResponseMessage = $"Error : {ex.Message}" }; }

        return _response;
    }

    public async Task<ResponseObject<StudentDtoOut>> GetStudentByName(string name)
    {
        _response = new ResponseObject<StudentDtoOut>();
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return new ResponseObject<StudentDtoOut>
                { ObjectResponseList = null, ResponseMessage = $"Error : {ex.Message}" };  }

        return _response;
    }
}