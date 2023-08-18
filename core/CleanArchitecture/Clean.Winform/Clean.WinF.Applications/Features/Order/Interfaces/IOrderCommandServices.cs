using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.WinF.Applications.Features.Order.DTOs;

namespace Clean.WinF.Applications.Features.Order.Interfaces
{
    public interface IOrderCommandServices
    {
        Task<OrderDto> CreateNewOrder(OrderDto addedOrder);
        Task<OrderDto> UpdateOrder(OrderDto updatedOrder);
        Task<OrderDto> DeleteOrder(OrderDto deletedOrder);
    }
}
