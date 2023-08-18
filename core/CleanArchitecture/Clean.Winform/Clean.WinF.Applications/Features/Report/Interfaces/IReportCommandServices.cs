using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.WinF.Applications.Features.Report.DTOs;

namespace Clean.WinF.Applications.Features.Report.Interfaces
{
    public interface IReportCommandServices
    {
        Task<List<ReportDto>> CreateNewReport(ReportDto addedReport);
        Task<ReportDto> UpdateReport(ReportDto updateReport);
        Task<List<ReportDto>> DeleteReport(ReportDto deletedReport);
    }
}
