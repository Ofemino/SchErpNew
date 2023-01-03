using SchoolERP.Domain.Dtos;
using SchoolERP.Domain.Dtos.Out;

namespace SchoolERP.Services.Interfaces;

public interface IParentServices
{
    Task<ResponseObject<ParentDtoOut>> GetAllParents();
    Task<ResponseObject<ParentDtoOut>> GetParentsById(long id);
    Task<ResponseObject<ParentDtoOut>> GetParentsByName(string name);
}