using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SchoolERP.Domain.Dtos;
using SchoolERP.Domain.Dtos.Out;
using SchoolERP.Persistent.IRepositories;

namespace SchoolERP.Services;

public class StaffServices : IStaffServices
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<StaffServices> _logger;
    private readonly IStaffRepository _repository;
    private ResponseObject<StaffDtoOut> _response;

    public StaffServices(IConfiguration configuration, ILogger<StaffServices> logger, IStaffRepository repository)
    {
        _configuration = configuration;
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
                return new ResponseObject<StaffDtoOut> { ObjectResponseList = staffs, ResponseMessage = "Has records.", ReturnedObjectCount = staffs.Count(), StatusCode = HttpStatusCode.OK};
            }

            return new ResponseObject<StaffDtoOut> { ObjectResponseList = null, ResponseMessage = "Has no record.", ReturnedObjectCount = staffs.Count(), StatusCode = HttpStatusCode.NoContent};
        }
        catch (Exception ex)
        {
            _logger.LogError("Repo Error at GetStaffs : {S}", ex.ToString());
            return new ResponseObject<StaffDtoOut>
            {
                ObjectResponseList = null, ResponseMessage = $"Error : {ex.Message}",
                StatusCode = HttpStatusCode.InternalServerError
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
                return new ResponseObject<StaffDtoOut> { ObjectResponse = staff, ResponseMessage = "Has records.",  StatusCode = HttpStatusCode.OK};
            }
            return new ResponseObject<StaffDtoOut> { ObjectResponse = staff, ResponseMessage = "Has no record."};
        }
        catch (Exception ex)
        {
            _logger.LogError("Repo Error at GetStaffById : {S}", ex.ToString());
            return new ResponseObject<StaffDtoOut>
            {
                ObjectResponseList = null, ResponseMessage = $"Error : {ex.Message}",
                StatusCode = HttpStatusCode.InternalServerError
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
                return new ResponseObject<StaffDtoOut> { ObjectResponseList = staffs, ResponseMessage = "Has records.", ReturnedObjectCount = staffs.Count(), StatusCode = HttpStatusCode.OK};
            }

            return new ResponseObject<StaffDtoOut> { ObjectResponseList = null, ResponseMessage = "Has no record.", ReturnedObjectCount = staffs.Count(), StatusCode = HttpStatusCode.NoContent};

        }
        catch (Exception ex)
        {
            _logger.LogError("Repo Error at GetStaffByClass : {S}", ex.ToString());
            return new ResponseObject<StaffDtoOut>
            {
                ObjectResponseList = null, ResponseMessage = $"Error : {ex.Message}",
                StatusCode = HttpStatusCode.InternalServerError
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
                return new ResponseObject<StaffDtoOut> { ObjectResponseList = staffs, ResponseMessage = "Has records.", ReturnedObjectCount = staffs.Count(), StatusCode = HttpStatusCode.OK};
            }
            return new ResponseObject<StaffDtoOut> { ObjectResponseList = staffs, ResponseMessage = "Has no record.", ReturnedObjectCount = staffs.Count(), StatusCode = HttpStatusCode.NoContent};
        }
        catch (Exception ex)
        {
            _logger.LogError("Repo Error at GetStaffByName : {S}", ex.ToString());
            return new ResponseObject<StaffDtoOut>
            {
                ObjectResponseList = null, ResponseMessage = $"Error : {ex.Message}",
                StatusCode = HttpStatusCode.InternalServerError
            };
        }

        return _response;
    }
}