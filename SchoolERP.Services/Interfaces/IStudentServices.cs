using SchoolERP.Domain.Dtos;
using SchoolERP.Domain.Dtos.In;
using SchoolERP.Domain.Dtos.Out;

namespace SchoolERP.Services.Interfaces;

public interface IStudentServices
{
    Task<ResponseObject<StudentDtoOut>> GetStudents();
}

