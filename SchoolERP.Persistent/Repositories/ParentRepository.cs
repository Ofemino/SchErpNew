using System.Collections;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SchoolERP.Domain.Dtos.Out;
using SchoolERP.Domain.Models;
using SchoolERP.Persistent.DataContext;
using SchoolERP.Persistent.IRepositories;

namespace SchoolERP.Persistent.Repositories;

public class ParentRepository : IParentRepository
{
    private readonly SchoolErpDbContext _dbContext;
    private readonly IConfiguration _configuration;
    private readonly ILogger<ParentRepository> _logger;
    private readonly IMapper _mapper;
    private List<ParentDtoOut> _parents;
    private ParentDtoOut _parent;

    public ParentRepository(SchoolErpDbContext dbContext, IConfiguration configuration,
        ILogger<ParentRepository> logger,
        IMapper mapper
    )
    {
        _dbContext = dbContext;
        _configuration = configuration;
        _logger = logger;
        _mapper = mapper;
        _parents = new List<ParentDtoOut>();
    }


    public async Task<List<ParentDtoOut>> GetAll()
    {
        try
        {
            var parents = await _dbContext.Parents.ToListAsync();
            if (parents.Count > 0)
            {
                _parents = _mapper.Map<List<Parent>, List<ParentDtoOut>>(parents);
            }

            return _parents;
        }
        catch (Exception exc)
        {
            _logger.LogError($"Error occured at ParentRepository GetAll, {exc.ToString()}");
        }

        return _parents;
    }

    public async Task<ParentDtoOut> GetById(long id)
    {
        try
        {
            var parent = await _dbContext.Parents.Where(i => i.Id.Equals(id)).FirstOrDefaultAsync();
            if (parent != null)
            {
                _parent = _mapper.Map<Parent, ParentDtoOut>(parent);
            }

            return _parent;
        }
        catch (Exception exc)
        {
            _logger.LogError($"Error occured at ParentRepository GetAll, {exc.ToString()}");
        }

        return _parent;
    }

    public Task<List<ParentDtoOut>> GetByClass(string className)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ParentDtoOut>> GetByName(string name)
    {
        try
        {
            var parents = await _dbContext.Parents.Where(n =>
                    n.FirstName.StartsWith(name) || n.LastName.StartsWith(name) || n.MiddleName.StartsWith(name))
                .ToListAsync();
            if (parents.Count > 0)
            {
                _parents = _mapper.Map<List<Parent>, List<ParentDtoOut>>(parents);
            }

            return _parents;
        }
        catch (Exception exc)
        {
            _logger.LogError($"Error occured at ParentRepository GetByName, {exc.ToString()}");
        }

        return _parents;
    }
}