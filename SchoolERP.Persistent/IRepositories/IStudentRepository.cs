using SchoolERP.Domain.Dtos.Out;

namespace SchoolERP.Persistent.IRepositories;

public interface IStudentRepository
{
    Task<List<StudentDtoOut>> GetStudents();
}