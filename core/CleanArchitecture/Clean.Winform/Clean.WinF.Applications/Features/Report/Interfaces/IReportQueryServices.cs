using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.WinF.Applications.Features.Report.DTOs;
namespace Clean.WinF.Applications.Features.Report.Interfaces
{
    public interface IReportQueryServices
    {
        Task<ReportDto> GetReportById(int id);
        Task<List<ReportDto>> GetReportByName(string name);        
        Task<List<ReportDto>> GetAllReports();
        Task<IEnumerable<ReportDto>> ListAllAsync();
    }
}
