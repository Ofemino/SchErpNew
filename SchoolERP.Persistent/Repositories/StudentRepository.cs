using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SchoolERP.Domain.Dtos.Out;
using SchoolERP.Domain.Models;
using SchoolERP.Persistent.DataContext;
using SchoolERP.Persistent.IRepositories;

namespace SchoolERP.Persistent.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<StudentRepository> _logger;
    private readonly SchoolErpDbContext _dbContext;
    private readonly IMapper _mapper;
    private StudentDtoOut _studentDtoOut;
    private List<StudentDtoOut> _studentsDtoOut { get; set; }

    public StudentRepository(IConfiguration configuration, ILogger<StudentRepository> logger,
        SchoolErpDbContext dbContext, IMapper mapper)
    {
        _configuration = configuration;
        _logger = logger;
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<StudentDtoOut>> GetStudents()
    {
        try
        {
            _studentsDtoOut = new List<StudentDtoOut>();
            var students = await _dbContext.Students.ToListAsync();
            if (students.Count > 0)
            {
                _studentsDtoOut = _mapper.Map<List<Student>, List<StudentDtoOut>>(students);
            }

            return _studentsDtoOut;
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception occured at GetStudents StudentRepository. " + ex.ToString());
        }

        return _studentsDtoOut;
    }

    public async Task<StudentDtoOut> GetStudentById(long id)
    {
        try
        {
            var student = await _dbContext.Students.Where(s => s.Id.Equals(id)).FirstOrDefaultAsync();
            if (student != null)
            {
                _studentDtoOut = _mapper.Map<Student, StudentDtoOut>(student);
            }

            return _studentDtoOut;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
        }

        return _studentDtoOut;
    }

    public async Task<StudentDtoOut> GetStudentByCurrentClass(long id)
    {
        try
        {
            var student = await _dbContext.Students.Where(s => s.Id.Equals(id))
                .FirstOrDefaultAsync();
            var studentClassHistory = await _dbContext.ClassHistories.Where(studentId => studentId.StudentId == id)
                .OrderByDescending(id => id.Id).Take(1).FirstOrDefaultAsync();
            if (student != null)
            {
                _studentDtoOut = _mapper.Map<Student, StudentDtoOut>(student);
            }

            return _studentDtoOut;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
        }

        return _studentDtoOut;
    }
}