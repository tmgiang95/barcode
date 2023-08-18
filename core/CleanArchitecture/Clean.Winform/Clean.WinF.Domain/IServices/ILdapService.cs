using Clean.WinF.Shared.DTOs.LDAP;
using System.Collections.Generic;

namespace Clean.WinF.Domain.IServices
{
    public interface ILdapService
    {
        LdapDto LdapGet(string username, string password);
        LdapDto FindByUserId(string username);
        List<LdapDto> SearchUser(string strSearchUser);
        LdapDto SearchLoginName(string userName);
        List<LdapDto> SearchDistributionList(string strSearchDistributionList);
        bool Authenticate(string userName, string password);
    }
}
