using SchoolERP.Domain.Dtos;
using SchoolERP.Domain.Dtos.Out;

namespace SchoolERP.Services;

public interface IStaffServices
{
    Task<ResponseObject<StaffDtoOut>> GetStaffs();
    Task<ResponseObject<StaffDtoOut>> GetStaffById(long id);
    Task<ResponseObject<StaffDtoOut>> GetStaffByClass(string className);
}