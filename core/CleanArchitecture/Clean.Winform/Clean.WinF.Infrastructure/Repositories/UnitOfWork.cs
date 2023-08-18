using Clean.WinF.Domain.Entities;
using Clean.WinF.Domain.Entities.Users;
using Clean.WinF.Domain.IRepository;
using Clean.WinF.Infrastructure.DBContext;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.WinF.Infrastructure.Repositories
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        public string DatabaseName { get; set; }
        private ApplicationDBContext _appDBContext;
        public IAsyncRepository<Part> PartRepository { get; private set; }
        public IAsyncRepository<Thread> ThreadRepository { get; private set; }
        public IAsyncRepository<Supplier> SupplierRepository { get; private set; }
        public IAsyncRepository<Setting> SettingRepository { get; private set; }
        public IAsyncRepository<Report> ReportRepository { get; private set; }
        public IAsyncRepository<Protocol> ProtocolRepository { get; private set; }
        public IAsyncRepository<Order> OrderRepository { get; private set; }
        public IAsyncRepository<Computer> ComputerRepository { get; private set; }
        public IAsyncRepository<Bobbin> BobbinRepository { get; private set; }
        public IAsyncRepository<Article> ArticleRepository { get; private set; }
        public IAsyncRepository<User> UserRepository { get; private set; }
        public IAsyncRepository<UserGroup> UserGroupRepository { get; private set; }
        public UnitOfWork(ApplicationDBContext appDBContext)
        {
            _appDBContext = appDBContext;
            PartRepository = new EFRepository<Part>(_appDBContext);
            ThreadRepository = new EFRepository<Thread>(_appDBContext);
            SupplierRepository = new EFRepository<Supplier>(_appDBContext);
            SettingRepository = new EFRepository<Setting>(_appDBContext);
            ReportRepository = new EFRepository<Report>(_appDBContext);
            ProtocolRepository = new EFRepository<Protocol>(_appDBContext);
            OrderRepository = new EFRepository<Order>(_appDBContext);
            ComputerRepository = new EFRepository<Computer>(_appDBContext);
            BobbinRepository = new EFRepository<Bobbin>(_appDBContext);
            ArticleRepository = new EFRepository<Article>(_appDBContext);
            UserRepository = new EFRepository<User>(_appDBContext);
            UserGroupRepository = new EFRepository<UserGroup>(_appDBContext);
        }

        public int Complete()
        {
            return _appDBContext.SaveChanges();
        }

        public void Dispose()
        {
            _appDBContext.Dispose();
        }
    }
}
