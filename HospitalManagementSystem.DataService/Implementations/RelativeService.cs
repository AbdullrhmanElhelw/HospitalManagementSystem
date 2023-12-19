using AutoMapper;
using HospitalManagementSystem.DataService.Abstracts;
using HospitalManagementSystem.DataService.DTOs.Relative;
using HospitalManagementSystem.Entites.Entites;
using HospitalManagementSystem.Infrastructure.Abstracts.RelativeRepository;
using HospitalManagementSystem.Infrastructure.DapperQueries.RelativeQueries;
using HospitalManagementSystem.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.DataService.Implementations;

public class RelativeService : IRelativeService
{
    private readonly IMapper _mapper;
    private readonly IRelativeQuery _relativeQuery;
    private readonly IUnitOfWork _unitOfWork;

    public RelativeService(IMapper mapper, IRelativeQuery relativeQuery, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _relativeQuery = relativeQuery;
        _unitOfWork = unitOfWork;
    }

    public void DeleteRelative(string id)
    {
         var relative = _relativeQuery.FindById(id);
        if(relative is not null)
        {
            _unitOfWork.RelativeRepository.Delete(relative);
            _unitOfWork.Commit();
        }
    }

    public RelativeReadDTO? GetRelative(string id)
    {
        var relative = _relativeQuery.FindById(id);
        return _mapper.Map<RelativeReadDTO>(relative);
    }

    public void UpdateRelative(RelativeUpdateDTO relativeUpdateDTO)
    {
        var relative = _relativeQuery.FindById(relativeUpdateDTO.Id);
        if(relative is not null)
        {
            _mapper.Map(relativeUpdateDTO, relative);
            _unitOfWork.RelativeRepository.Update(relative);
            _unitOfWork.Commit();
        }
    }

    public void UpdateRelative(string id, JsonPatchDocument relativeToUpdate)
    {
        _unitOfWork.RelativeRepository.PartialUpdate(id, relativeToUpdate);
        _unitOfWork.Commit();
    }

}
