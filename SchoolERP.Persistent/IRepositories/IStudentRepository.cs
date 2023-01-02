using SchoolERP.Domain.Dtos.Out;

namespace SchoolERP.Persistent.IRepositories;

public interface IStudentRepository
{
    Task<List<StudentDtoOut>> GetStudents();
    Task<StudentDtoOut> GetStudentById(long id);
    Task<StudentDtoOut> GetStudentByCurrentClass(long id);

}