using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.WinF.Domain.Entities;
using Clean.WinF.Domain.Entities.Users;

namespace Clean.WinF.Domain.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IAsyncRepository<Article> ArticleRepository { get; }
        IAsyncRepository<Bobbin> BobbinRepository { get; }
        IAsyncRepository<Computer> ComputerRepository { get; }
        IAsyncRepository<Order> OrderRepository { get; }
        IAsyncRepository<Part> PartRepository { get; }
        IAsyncRepository<Protocol> ProtocolRepository { get; }
        IAsyncRepository<Report> ReportRepository { get; }
        IAsyncRepository<Setting> SettingRepository { get; }
        IAsyncRepository<Supplier> SupplierRepository { get; }
        IAsyncRepository<Thread> ThreadRepository { get; }
        IAsyncRepository<User> UserRepository { get; }
        IAsyncRepository<UserGroup> UserGroupRepository { get; }
        string DatabaseName { get; set; }
        int Complete();
    }
}
