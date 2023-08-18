using Clean.WinF.Applications.Features.Order.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.WinF.Applications.Features.Order.Interfaces
{
    public interface IOrderQueryServices
    {
        Task<OrderDto> GetOrderById(int id);
        Task<List<OrderDto>> GetOrderByArticleName(string articleName);
        Task<List<OrderDto>> GetOrderByArticleCode(string articleCode);
        Task<List<OrderDto>> GetOrderByOrderQuantity(string orderQuantity);
        Task<List<OrderDto>> GetOrderByActualQuantity(string actualQuantity);
        Task<OrderDto> GetOrderBySABLable(string sabLabel);
        Task<List<OrderDto>> GetAllOrders();
        Task<IEnumerable<OrderDto>> ListAllAsync();
    }
}
