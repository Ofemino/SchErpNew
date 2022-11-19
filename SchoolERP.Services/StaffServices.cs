using SchoolERP.Domain.Dtos;
using SchoolERP.Domain.Dtos.Out;

namespace SchoolERP.Services;

public class StaffServices : IStaffServices
{
    private ResponseObject<StaffDtoOut> _response;

    public async Task<ResponseObject<StaffDtoOut>> GetStaffs()
    {
        _response = new ResponseObject<StaffDtoOut>();
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

    public async Task<ResponseObject<StaffDtoOut>> GetStaffById(long id)
    {
        _response = new ResponseObject<StaffDtoOut>();
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

    public async Task<ResponseObject<StaffDtoOut>> GetStaffByClass(string className)
    {
        _response = new ResponseObject<StaffDtoOut>();
        try
        {

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        return _response;
    }
}