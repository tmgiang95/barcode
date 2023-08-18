using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.WinF.Applications.Features.Supplier.DTOs;

namespace Clean.WinF.Applications.Features.Supplier.Interfaces
{
    public interface ISupplierCommandServices
    {
        Task<List<SupplierDto>> CreateNewSupplier(SupplierDto addedSupplier);
        Task<SupplierDto> UpdateSupplier(SupplierDto updatedSupplier);
        Task<List<SupplierDto>> DeleteSupplier(SupplierDto deletedSupplier);
    }
}
