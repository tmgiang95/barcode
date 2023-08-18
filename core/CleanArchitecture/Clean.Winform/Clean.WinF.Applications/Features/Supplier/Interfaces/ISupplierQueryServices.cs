using Clean.WinF.Applications.Features.Supplier.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.WinF.Applications.Features.Supplier.Interfaces
{
    public interface ISupplierQueryServices
    {
        Task<SupplierDto> GetSupplierById(int id);
        Task<List<SupplierDto>> GetSupplierByName(string name);
        Task<List<SupplierDto>> GetSupplierByCode(string code);
        Task<SupplierDto> GetAllSuppliers();
        Task<IEnumerable<SupplierDto>> ListAllAsync();
    }
}
