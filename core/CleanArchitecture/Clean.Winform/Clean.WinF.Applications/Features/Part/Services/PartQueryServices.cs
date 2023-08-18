using Clean.WinF.Applications.Features.Part.DTOs;
using Clean.WinF.Applications.Features.Part.Interfaces;
using Clean.WinF.Domain.Entities;
using Clean.WinF.Domain.IRepository;
using Clean.WinF.Infrastructure.Utilities;
using Clean.WinF.Shared.ErrorMessage;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.WinF.Applications.Features.Part.Services
{
    public sealed class PartQueryServices: IPartQueryServices
    {
        private readonly IAsyncRepository<Clean.WinF.Domain.Entities.Part> _partRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PartQueryServices(IAsyncRepository<Clean.WinF.Domain.Entities.Part> partRepository, IUnitOfWork unitOfWork)
        {
            _partRepository = partRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PartDto> GetPartById(int id)
        {
            var result = new PartDto();

            if (id <= 0)
            {
                result.MessageRet = string.Format(CustomErrorMessage.APP_PART_NOT_FOUND);
                return result;
            }                       
                        
            try
            {
                var existedPart = await _unitOfWork.PartRepository.Query().FirstOrDefaultAsync(x => x.ID == id && x.IsActive == true);
                if (existedPart != null)
                {
                    result.MessageRet = string.Format(CustomErrorMessage.APP_PART_NOT_FOUND);
                    return result;
                }
            }
            catch (Exception ex)
            {
                Log.Error(string.Concat("GetPartById() ", ex.ToString()));
                result.MessageRet = CustomErrorMessage.APP_PART_NOT_FOUND;
                return result;
            }

            return result;
        }

        public async Task<List<PartDto>> GetPartByName(string name)
        {
            var result = new List<PartDto>();

            try
            {
                IQueryable<Clean.WinF.Domain.Entities.Part> existedParts = null;
                if (!string.IsNullOrEmpty(name))
                {
                    existedParts=(IQueryable<Clean.WinF.Domain.Entities.Part>)_partRepository.Query().Where(p => p.Name.Contains(name) && p.IsActive == true).ToList();
                }
                else
                {
                    existedParts = (IQueryable<Clean.WinF.Domain.Entities.Part>)_partRepository.Query().Where(p => p.IsActive == true).ToList();
                }
                
                if (existedParts != null)
                {
                    foreach (var part in existedParts)
                    {
                        var partDto = new PartDto()
                        {
                            Name = part.Name,
                            ID = part.ID,
                            IsActive = part.IsActive,
                            Code = part.Code,
                            CreatedBy = part.CreatedBy,
                            CreatedOn = part.CreatedOn,
                            UpdatedBy = part.UpdatedBy,
                            UpdatedOn = part.UpdatedOn
                        };
                        result.Add(partDto);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(string.Concat("GetPartByName() ", ex.ToString()));                
                return null;
            }

            return result;
        }

        public async Task<List<PartDto>> GetPartByCode(string code)
        {
            var result = new List<PartDto>();

            try
            {
                IQueryable<Clean.WinF.Domain.Entities.Part> existedParts = null;
                if (!string.IsNullOrEmpty(code))
                {
                    existedParts = (IQueryable<Clean.WinF.Domain.Entities.Part>)_partRepository.Query().Where(p => p.Name.Contains(code) && p.IsActive == true).ToList();
                }
                else
                {
                    existedParts = (IQueryable<Clean.WinF.Domain.Entities.Part>)_partRepository.Query().Where(p => p.IsActive == true).ToList();
                }

                if (existedParts != null)
                {
                    foreach (var part in existedParts)
                    {
                        var partDto = new PartDto()
                        {
                            Name = part.Name,
                            ID = part.ID,
                            IsActive = part.IsActive,
                            Code = part.Code,
                            CreatedBy = part.CreatedBy,
                            CreatedOn = part.CreatedOn,
                            UpdatedBy = part.UpdatedBy,
                            UpdatedOn = part.UpdatedOn
                        };
                        result.Add(partDto);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(string.Concat("GetPartByCode() ", ex.ToString()));
                return null;
            }

            return result;
        }

        public async Task<List<PartDto>> GetAllParts()
        {
            var result = new List<PartDto>();

            try
            {
                IQueryable<Clean.WinF.Domain.Entities.Part> existedParts = null;                
                existedParts = (IQueryable<Clean.WinF.Domain.Entities.Part>)_partRepository.Query().Where(p => p.IsActive == true).ToList();
                
                if (existedParts != null)
                {
                    foreach (var part in existedParts)
                    {
                        var partDto = new PartDto()
                        {
                            Name = part.Name,
                            ID = part.ID,
                            IsActive = part.IsActive,
                            Code = part.Code,
                            CreatedBy = part.CreatedBy,
                            CreatedOn = part.CreatedOn,
                            UpdatedBy = part.UpdatedBy,
                            UpdatedOn = part.UpdatedOn
                        };
                        result.Add(partDto);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(string.Concat("GetAllParts() ", ex.ToString()));
                return null;
            }

            return result;
        }

        public async Task<IEnumerable<PartDto>> ListAllAsync()
        {
            var result = new List<PartDto>();

            try
            {
                IEnumerable<Clean.WinF.Domain.Entities.Part> existedParts = null;
                existedParts = _unitOfWork.PartRepository.ListAllAsync().Result;

                if (existedParts != null)
                {
                    foreach (var part in existedParts)
                    {
                        var partDto = new PartDto()
                        {
                            Name = part.Name,
                            ID = part.ID,
                            IsActive = part.IsActive,
                            Code = part.Code,
                            CreatedBy = part.CreatedBy,
                            CreatedOn = part.CreatedOn,
                            UpdatedBy = part.UpdatedBy,
                            UpdatedOn = part.UpdatedOn
                        };
                        result.Add(partDto);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(string.Concat("ListAllAsync() ", ex.ToString()));
                return null;
            }

            return result;
        }

    }
}
