using SchoolERP.Domain.Dtos;
using SchoolERP.Domain.Dtos.Out;

namespace SchoolERP.Services.Interfaces;

public interface IStudentServices
{
    Task<ResponseObject<StudentDtoOut>> GetStudents();
    Task<ResponseObject<StudentDtoOut>> GetStudentById(long id);
    Task<ResponseObject<StudentDtoOut>> GetStudentByClass(string className);
}

