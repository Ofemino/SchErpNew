using System.Net;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SchoolERP.Domain.Dtos;
using SchoolERP.Domain.Dtos.Out;
using SchoolERP.Domain.Models;
using SchoolERP.Persistent.IRepositories;
using SchoolERP.Services.Interfaces;

namespace SchoolERP.Services;

public class ParentServices : IParentServices
{
    private readonly IParentRepository _parentRepository;
    private readonly ILogger<ParentServices> _logger;
    private List<ParentDtoOut> _parents;
    private ParentDtoOut _parent;

    public ParentServices(IParentRepository parentRepository,
        ILogger<ParentServices> logger)
    {
        _parentRepository = parentRepository;
        _logger = logger;
    }


    public async Task<ResponseObject<ParentDtoOut>> GetAllParents()
    {
        _parents = new List<ParentDtoOut>();
        try
        {
            _parents = await _parentRepository.GetAll();
            if (_parents.Count > 0)
            {
                return new ResponseObject<ParentDtoOut>
                {
                    ObjectResponseList = _parents, ReturnedObjectCount = _parents.Count(), HasRecords = true,
                    ResponseMessage = "successful", StatusCode = (int)HttpStatusCode.OK
                };
            }
        }
        catch (Exception exc)
        {
            _logger.LogError($"An error occured at ParentServices GetAllParents: {exc}");
        }

        return new ResponseObject<ParentDtoOut>
        {
            ObjectResponseList = _parents, HasRecords = false, ResponseMessage = "has no record!",
            StatusCode = (int)HttpStatusCode.NoContent, ReturnedObjectCount = _parents.Count()
        };
    }

    public async Task<ResponseObject<ParentDtoOut>> GetParentsById(long id)
    {
        _parent = new ParentDtoOut();
        try
        {
            _parent = await _parentRepository.GetById(id);
            if (_parent!=null)
            {
                return new ResponseObject<ParentDtoOut>
                {
                    ObjectResponse = _parent, HasRecords = true,
                    ResponseMessage = "successful", StatusCode = (int)HttpStatusCode.OK
                };
            }
        }
        catch (Exception exc)
        {
            _logger.LogError($"An error occured at ParentServices GetAllParents: {exc}");
        }

        return new ResponseObject<ParentDtoOut>
        {
            ObjectResponse = _parent, HasRecords = false, ResponseMessage = "has no record!",
            StatusCode = (int)HttpStatusCode.NoContent
        };
    }

    public async Task<ResponseObject<ParentDtoOut>> GetParentsByName(string name)
    {
        _parents = new List<ParentDtoOut>();
        try
        {
            _parents = await _parentRepository.GetByName(name);
            if (_parents.Count > 0)
            {
                return new ResponseObject<ParentDtoOut>
                {
                    ObjectResponseList = _parents, ReturnedObjectCount = _parents.Count(), HasRecords = true,
                    ResponseMessage = "successful", StatusCode = (int)HttpStatusCode.OK
                };
            }
        }
        catch (Exception exc)
        {
            _logger.LogError($"An error occured at ParentServices GetParentsByName: {exc}");
        }

        return new ResponseObject<ParentDtoOut>
        {
            ObjectResponseList = _parents, HasRecords = false, ResponseMessage = "has no record!",
            StatusCode = (int)HttpStatusCode.NoContent, ReturnedObjectCount = _parents.Count()
        };
    }

    public async Task<ResponseObject<ParentDtoOut>> GetParentsByClassName(string className)
    {
        _parents = new List<ParentDtoOut>();
        try
        {
            _parents = await _parentRepository.GetByClass(className);
            if (_parents.Count > 0)
            {
                return new ResponseObject<ParentDtoOut>
                {
                    ObjectResponseList = _parents, ReturnedObjectCount = _parents.Count(), HasRecords = true,
                    ResponseMessage = "successful", StatusCode = (int)HttpStatusCode.OK
                };
            }
        }
        catch (Exception exc)
        {
            _logger.LogError($"An error occured at ParentServices GetParentsByClassName: {exc}");
        }

        return new ResponseObject<ParentDtoOut>
        {
            ObjectResponseList = _parents, HasRecords = false, ResponseMessage = "has no record!",
            StatusCode = (int)HttpStatusCode.NoContent, ReturnedObjectCount = _parents.Count()
        };
    }
}