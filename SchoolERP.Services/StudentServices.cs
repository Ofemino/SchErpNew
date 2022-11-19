using System.Reflection.Metadata.Ecma335;
using SchoolERP.Domain.Dtos;
using SchoolERP.Domain.Dtos.Out;
using SchoolERP.Services.Interfaces;

namespace SchoolERP.Services;

public class StudentServices : IStudentServices
{
    private ResponseObject<StudentDtoOut> _response;

    public async Task<ResponseObject<StudentDtoOut>> GetStudents()
    {
        _response = new ResponseObject<StudentDtoOut>();
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        return _response;
    }

    public async Task<ResponseObject<StudentDtoOut>> GetStudentById(long id)
    {
        _response = new ResponseObject<StudentDtoOut>();
        try
        {
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }

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
            Console.WriteLine(ex);
        }

        return _response;
    }
}