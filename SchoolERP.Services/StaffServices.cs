using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SchoolERP.Domain.Dtos;
using SchoolERP.Domain.Dtos.Out;
using SchoolERP.Persistent.IRepositories;

namespace SchoolERP.Services;

public class StaffServices : IStaffServices
{
    private readonly ILogger<StaffServices> _logger;
    private readonly IStaffRepository _repository;
    private ResponseObject<StaffDtoOut> _response;

    public StaffServices(ILogger<StaffServices> logger, IStaffRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async Task<ResponseObject<StaffDtoOut>> GetStaffs()
    {
        _response = new ResponseObject<StaffDtoOut>();
        try
        {
            var staffs = await _repository.GetStaffs();
            if (staffs.Count > 0)
            {
                return new ResponseObject<StaffDtoOut> { ObjectResponseList = staffs, ResponseMessage = "Has records.", ReturnedObjectCount = staffs.Count(), StatusCode = (int)HttpStatusCode.OK};
            }

            return new ResponseObject<StaffDtoOut> { ObjectResponseList = null, ResponseMessage = "Has no record.", ReturnedObjectCount = staffs.Count(), StatusCode = (int)HttpStatusCode.NoContent};
        }
        catch (Exception ex)
        {
            _logger.LogError("Repo Error at GetStaffs : {S}", ex.ToString());
            return new ResponseObject<StaffDtoOut>
            {
                ObjectResponseList = null, ResponseMessage = $"Error : {ex.Message}",
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }

        return _response;
    }

    public async Task<ResponseObject<StaffDtoOut>> GetStaffById(long id)
    {
        _response = new ResponseObject<StaffDtoOut>();
        try
        {
            var staff = await _repository.GetStaffById(id);
            if (staff != null)
            {
                return new ResponseObject<StaffDtoOut> { ObjectResponse = staff, ResponseMessage = "Has records.",  StatusCode = (int)HttpStatusCode.OK};
            }
            return new ResponseObject<StaffDtoOut> { ObjectResponse = staff, ResponseMessage = "Has no record."};
        }
        catch (Exception ex)
        {
            _logger.LogError("Repo Error at GetStaffById : {S}", ex.ToString());
            return new ResponseObject<StaffDtoOut>
            {
                ObjectResponseList = null, ResponseMessage = $"Error : {ex.Message}",
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }

        return _response;
    }

    public async Task<ResponseObject<StaffDtoOut>> GetStaffByClass(string className)
    {
        _response = new ResponseObject<StaffDtoOut>();
        try
        {
            var staffs = await _repository.GetStaffByClass(className);
            if (staffs.Count > 0)
            {
                return new ResponseObject<StaffDtoOut> { ObjectResponseList = staffs, ResponseMessage = "Has records.", ReturnedObjectCount = staffs.Count(), StatusCode = (int)HttpStatusCode.OK};
            }

            return new ResponseObject<StaffDtoOut> { ObjectResponseList = null, ResponseMessage = "Has no record.", ReturnedObjectCount = staffs.Count(), StatusCode = (int)HttpStatusCode.NoContent};

        }
        catch (Exception ex)
        {
            _logger.LogError("Repo Error at GetStaffByClass : {S}", ex.ToString());
            return new ResponseObject<StaffDtoOut>
            {
                ObjectResponseList = null, ResponseMessage = $"Error : {ex.Message}",
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }

        return _response;
    }

    public async Task<ResponseObject<StaffDtoOut>> GetStaffByName(string name)
    {
        _response = new ResponseObject<StaffDtoOut>();
        try
        {
            var staffs = await _repository.GetStaffByClass(name);
            if (staffs.Count > 0)
            {
                return new ResponseObject<StaffDtoOut> { ObjectResponseList = staffs, ResponseMessage = "Has records.", ReturnedObjectCount = staffs.Count(), StatusCode = (int)HttpStatusCode.OK};
            }
            return new ResponseObject<StaffDtoOut> { ObjectResponseList = staffs, ResponseMessage = "Has no record.", ReturnedObjectCount = staffs.Count(), StatusCode = (int)HttpStatusCode.NoContent};
        }
        catch (Exception ex)
        {
            _logger.LogError("Repo Error at GetStaffByName : {S}", ex.ToString());
            return new ResponseObject<StaffDtoOut>
            {
                ObjectResponseList = null, ResponseMessage = $"Error : {ex.Message}",
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }

        return _response;
    }
}