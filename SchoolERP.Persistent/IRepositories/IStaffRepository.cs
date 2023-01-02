using SchoolERP.Domain.Dtos.Out;

namespace SchoolERP.Persistent.IRepositories;

public interface IStaffRepository
{
    Task<List<StaffDtoOut>> GetStaffs();
    Task<StaffDtoOut> GetStaffById(long id);
    Task<List<StaffDtoOut>> GetStaffByClass(string className);
    Task<List<StaffDtoOut>> GetStaffByName(string name);
}