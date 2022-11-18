using SchoolERP.Domain.Dtos;
using SchoolERP.Domain.Dtos.Out;
using SchoolERP.Services.Interfaces;

namespace SchoolERP.Services;

public class StudentServices : IStudentServices
{
    public async Task<ResponseObject<StudentDtoOut>> GetStudents()
    {
        var response = new ResponseObject<StudentDtoOut>();
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        return response;
    }
}