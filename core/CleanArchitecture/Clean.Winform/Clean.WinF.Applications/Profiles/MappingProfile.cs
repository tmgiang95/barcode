using AutoMapper;
using Clean.WinF.Applications.Features.Article.DTOs;
using Clean.WinF.Applications.Features.Bobbin.DTOs;
using Clean.WinF.Applications.Features.Computer.DTOs;
using Clean.WinF.Applications.Features.Order.DTOs;
using Clean.WinF.Applications.Features.Part.DTOs;
using Clean.WinF.Applications.Features.Protocol.DTOs;
using Clean.WinF.Applications.Features.Report.DTOs;
using Clean.WinF.Applications.Features.Setting.DTOs;
using Clean.WinF.Applications.Features.Supplier.DTOs;
using Clean.WinF.Applications.Features.Thread.DTOs;
using Clean.WinF.Domain.Entities;

namespace Clean.WinF.Applications.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleDto, Article>();

            CreateMap<Bobbin, BobbinDto>();
            CreateMap<BobbinDto, Bobbin>();

            CreateMap<Computer, ComputerDto>();
            CreateMap<ComputerDto, Computer>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<Part, PartDto>();
            CreateMap<PartDto, Part>();

            CreateMap<Protocol, ProtocolDto>();
            CreateMap<ProtocolDto, Protocol>();

            CreateMap<Report, ReportDto>();
            CreateMap<ReportDto, Report>();

            CreateMap<Setting, SettingDto>();
            CreateMap<SettingDto, Setting>();

            CreateMap<Supplier, SupplierDto>();
            CreateMap<SupplierDto, Supplier>();

            CreateMap<Thread, ThreadDto>();
            CreateMap<ThreadDto, Thread>();

            //CreateMap<Role, RoleDto>();
            //CreateMap<RoleDto, Role>();

            //CreateMap<RoleGroup, RoleGroupDto>();
            //CreateMap<RoleGroupDto, RoleGroup>();

            //CreateMap<Permission, PermissionDto>()
            //    .ForMember(src => src.RolePermissions, dest => dest.MapFrom(x => x.RolePermissions));
            //CreateMap<PermissionDto, Permission>();

            //CreateMap<RolePermissionDto, RolePermission>();
            //CreateMap<RolePermission, RolePermissionDto>();

            //CreateMap<Domain.Entities.Users.Group, GroupDto>();
            //CreateMap<GroupDto, Domain.Entities.Users.Group> ();

            //CreateMap<User, UserDto>();
            //CreateMap<UserDto, User>();
        }
    }
}
