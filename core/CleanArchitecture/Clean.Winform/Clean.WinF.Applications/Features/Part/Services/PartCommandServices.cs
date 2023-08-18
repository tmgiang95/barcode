using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Clean.WinF.Applications.Features.Part.Interfaces;
using Clean.WinF.Domain.IRepository;
using Clean.WinF.Domain.Entities;
using Clean.WinF.Applications.Features.Part.DTOs;
using Clean.WinF.Shared.ErrorMessage;
using Microsoft.EntityFrameworkCore;
using Clean.WinF.Infrastructure.Utilities;
using Clean.WinF.Shared;
using AutoMapper;
using Clean.WinF.Shared.Constants;

namespace Clean.WinF.Applications.Features.Part.Services
{
    public  class PartCommandServices: IPartCommandServices
    {
        private readonly IAsyncRepository<Clean.WinF.Domain.Entities.Part> _partRepository;
        private readonly IUnitOfWork _unitOfWork;
      
        public PartCommandServices(IAsyncRepository<Clean.WinF.Domain.Entities.Part> partRepository, IUnitOfWork unitOfWork) 
        {
            _partRepository= partRepository;
            _unitOfWork = unitOfWork;
            //ConfigureAutoMapper();
        }

        //private void ConfigureAutoMapper()
        //{
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<PartDto, Domain.Entities.Part>();
        //        cfg.CreateMap<Domain.Entities.Part, PartDto>();
        //    });

        //    var mapper = config.CreateMapper();
        //}

        public async Task<PartDto> CreateNewPart(PartDto addPart)
        {
            var result = new PartDto();            

            if (string.IsNullOrEmpty(addPart.Name.Trim()))
            {
                result.CustomErrorCode = CustomErrorCode.APP_PART_CODE_EMPTY;
                result.MessageRet = string.Format(CustomErrorMessage.BP_GROUP_NAME_EMPTY);
                return result;
            }

            if (string.IsNullOrEmpty(addPart.Code.Trim()))
            {
                result.CustomErrorCode = CustomErrorCode.APP_PART_NAME_EMPTY;
                result.MessageRet = string.Format(CustomErrorMessage.BP_GROUP_NAME_EMPTY);
                return result;
            }

            var existedPart = await _unitOfWork.PartRepository.Query().FirstOrDefaultAsync(x => x.Code.Equals(addPart.Code) && x.IsActive == true);
            if (existedPart != null)
            {
                result.MessageRet = string.Format(CustomErrorMessage.APP_PART_EXISTED_ALREADY);                
                return result;
            }

            if (CleanWinFUtility.HasSpecialCharacters(addPart.Code.Trim()))
            {
                result.CustomErrorCode = CustomErrorCode.APP_PART_INVALID_NAME;
                result.MessageRet = CustomErrorMessage.APP_PART_INVALID_NAME;                
                return result;
            }

            if (CleanWinFUtility.HasSpecialCharacters(addPart.Name.Trim()))
            {
                result.CustomErrorCode = CustomErrorCode.APP_PART_INVALID_CODE;
                result.MessageRet = CustomErrorMessage.APP_PART_INVALID_CODE;
                return result;
            }

            //add new to db
            var newPart = new Domain.Entities.Part()
            {                
                Name = addPart.Name.Trim(),
                Code = addPart.Code.Trim(),
                CreatedBy = "Test",
                CreatedOn = DateTime.UtcNow,
                IsActive = true
            };            

            try
            {
                var partResult = await _unitOfWork.PartRepository.AddAsync(newPart);
                var resultAdd = _unitOfWork.Complete();
                if(resultAdd > 0)
                {
                    result.CustomErrorCode = CustomOperationCodes.APP_PART_ADD_SUCCESS;
                }
                else
                {
                    result.CustomErrorCode = CustomOperationCodes.APP_PART_ADD_FAIL;
                    result.MessageRet = CustomOperationCodes.APP_PART_ADD_FAIL;
                }
            }
            catch (Exception ex)
            {
                Log.Error(string.Concat("CreateNewPart() ", ex.ToString()));
                result.MessageRet = CustomOperationCodes.APP_PART_ADD_FAIL;
                return result;
            }

            return result;
        }

        public async Task<PartDto> UpdatePart(PartDto updatedPart)
        {
            var result = new PartDto();

            if (string.IsNullOrEmpty(updatedPart.Name.Trim()))
            {
                result.MessageRet = string.Format(CustomErrorMessage.BP_GROUP_NAME_EMPTY);                
                return result;
            }

            if (string.IsNullOrEmpty(updatedPart.Code.Trim()))
            {
                result.MessageRet = string.Format(CustomErrorMessage.BP_GROUP_NAME_EMPTY);
                return result;
            }

            if (CleanWinFUtility.HasSpecialCharacters(updatedPart.Name) || CleanWinFUtility.HasSpecialCharacters(updatedPart.Code))
            {
                result.MessageRet = string.Format(CustomErrorMessage.BP_GROUP_NAME_EMPTY);
                return result;
            }

            var existedPart = await _unitOfWork.PartRepository.Query().FirstOrDefaultAsync(x => x.Code.Equals(updatedPart.Code) && x.IsActive == true);

            if (existedPart is null)
            {                
                result.MessageRet = string.Format(CustomErrorMessage.BP_GROUP_NOT_FOUND, updatedPart.ID);
                return result;
            }                        

            try
            {
                var resultUpdated = await _unitOfWork.PartRepository.UpdateAsync(existedPart);
                result = UpdatePartInfo(resultUpdated);
            }
            catch (Exception ex)
            {
                Log.Error($"UpdateGroup() error: {ex.ToString()}");               
                
                return result;
            }

            return result;
        }

        public async Task<PartDto> DeletePart(PartDto deletedPart)
        {
            var result = new PartDto();

            var existedPart = await _unitOfWork.PartRepository.Query().FirstOrDefaultAsync(x => x.ID == deletedPart.ID);

            if (existedPart is null || existedPart.IsActive == false)
            {                
                result.MessageRet = string.Format(CustomErrorMessage.BP_GROUP_NOT_FOUND, deletedPart.ID);
                return result;
            }

            existedPart.UpdatedOn = DateTime.UtcNow;
            existedPart.UpdatedBy = "Test";
            existedPart.IsActive = false;

            try
            {
                var resultUpdated = await _unitOfWork.PartRepository.UpdateAsync(existedPart);
            }
            catch (Exception ex)
            {
                Log.Error($"DeletePart() error: {ex.ToString()}");
                result.MessageRet = string.Format(CustomErrorMessage.BP_GROUP_REMOVED_FAIL, existedPart.Code);                
                return result;
            }

            return result;
        }

        #region private functions
        private PartDto UpdatePartInfo(Domain.Entities.Part part)
        {
            if (part is null) return null;

            var partDTO = new PartDto()
            {
                ID = part.ID,
                Name = part.Name,
                Code = part.Code,
                CreatedBy = part.CreatedBy,
                CreatedOn = part.CreatedOn,
                UpdatedBy = part.UpdatedBy,
                UpdatedOn = part.UpdatedOn,
                MessageRet = "Updated Part information sucessfully",
                IsActive = part.IsActive                
            };

            return partDTO;
        }
        #endregion
    }
}
