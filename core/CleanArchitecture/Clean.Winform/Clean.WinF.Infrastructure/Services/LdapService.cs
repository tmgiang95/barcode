using Clean.WinF.Domain.IServices;
using Clean.WinF.Shared.DTOs.LDAP;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text.RegularExpressions;

namespace Clean.WinF.Infrastructure.Services
{
    public class LdapService : ILdapService
    {
        private readonly IConfiguration _config;
        public LdapService(IConfiguration config)
        {
            _config = config;
        }
        #region Public Methods
        public LdapDto LdapGet(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || username.Length < 3)
                {
                    throw new Exception("Length of username has to be at least 3!");
                }
                if (!Authenticate(username, password))
                {
                    return null;
                }
                username = Regex.Replace(username, @"\([^\)]+\)", "");
                return FindByUserId(username);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return null;
            }
        }

        public LdapDto FindByUserId(string username)
        {
            try
            {
                DirectorySearcher search = new DirectorySearcher(CreateDirectory());
                search.Filter = "(&(objectclass=user)(sAMAccountName=" + username + "))";
                SearchResult result = search.FindOne();
                if (result != null)
                {
                    LdapDto ldapResult = LdapResultMapper(result.Properties);
                    return ldapResult;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return null;
            }

        }

        public List<LdapDto> SearchUser(string searchUser)
        {
            try
            {
                DirectorySearcher search = new DirectorySearcher(CreateDirectory());
                search.Filter = "(&(objectCategory=user)(|(displayName=" + searchUser + "*)(sAMAccountName=" + searchUser + "*)))";
                SearchResultCollection results = search.FindAll();
                if (results != null && results.Count > 0)
                {
                    List<LdapDto> ldapDtos = new List<LdapDto>();
                    for (int i = 0; i < results.Count; i++)
                    {
                        LdapDto ldapDto = LdapResultMapper(results[i].Properties);
                        ldapDtos.Add(ldapDto);
                    }
                    return ldapDtos;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return null;
            }
        }

        public LdapDto SearchLoginName(string loginName)
        {
            try
            {
                DirectorySearcher search = new DirectorySearcher(CreateDirectory());
                search.Filter = "(&(objectCategory=user)(sAMAccountName=" + loginName + "*))";
                SearchResultCollection results = search.FindAll();
                if (results != null && results.Count > 0)
                {
                    List<LdapDto> ldapDtos = new List<LdapDto>();
                    if (results != null && results.Count > 0)
                    {
                        return LdapResultMapper(results[0].Properties);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return null;
            }
        }

        public List<LdapDto> SearchDistributionList(string searchDistributionList)
        {
            try
            {
                DirectorySearcher search = new DirectorySearcher(CreateDirectory());
                search.Filter = "(&(objectCategory=group)(displayName=" + searchDistributionList + "*))";
                SearchResultCollection results = search.FindAll();
                if (results != null && results.Count > 0)
                {
                    List<LdapDto> ldapDtos = new List<LdapDto>();
                    for (int i = 0; i < results.Count; i++)
                    {
                        LdapDto ldapDto = LdapResultMapper(results[i].Properties);
                        ldapDtos.Add(ldapDto);
                    }
                    return ldapDtos;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return null;
            }
        }

        public bool Authenticate(string userName, string password)
        {
            bool authentic = false;
            try
            {
                string ldapUrl = _config["LDAPSetting:Url"];
                DirectoryEntry entry = new DirectoryEntry(ldapUrl, userName, password);
                DirectorySearcher ds = new DirectorySearcher(entry);
                ds.FindOne();
                return true;
            }
            catch (DirectoryServicesCOMException ex)
            {
                Console.Write(ex.ToString());
            }
            return authentic;
        }
        #endregion
        #region Private Methods
        private LdapDto LdapResultMapper(ResultPropertyCollection fields)
        {
            LdapDto ldapDto = new LdapDto();
            if (fields["cn"] != null && fields["cn"].Count > 0)
                ldapDto.Cn = (string)fields["cn"][0];
            if (fields["sAMAccountName"] != null && fields["sAMAccountName"].Count > 0)
                ldapDto.UserId = (string)fields["sAMAccountName"][0];
            if (fields["mail"] != null && fields["mail"].Count > 0)
                ldapDto.Email = (string)fields["mail"][0];
            if (fields["department"] != null && fields["department"].Count > 0)
                ldapDto.Department = (string)fields["department"][0];
            if (fields["displayname"] != null && fields["displayname"].Count > 0)
                ldapDto.DisplayName = (string)fields["displayname"][0];
            if (fields["givenname"] != null && fields["givenname"].Count > 0 && fields["sn"] != null && fields["sn"].Count > 0)
                ldapDto.FullName = (string)fields["sn"][0] + " " + (string)fields["givenname"][0];
            if (fields["telephoneNumber"] != null && fields["telephoneNumber"].Count > 0)
                ldapDto.PhoneNumber = (string)fields["telephoneNumber"][0];
            if (fields["l"] != null && fields["l"].Count > 0)
                ldapDto.City = (string)fields["l"][0];
            if (fields["co"] != null && fields["co"].Count > 0)
                ldapDto.Country = (string)fields["co"][0];
            return ldapDto;
        }

        private DirectoryEntry CreateDirectory()
        {
            string ldapUsername = _config["LDAPSetting:Username"];
            string ldapPassword = _config["LDAPSetting:Password"];
            string ldapUrl = _config["LDAPSetting:Url"];
            return new DirectoryEntry(ldapUrl, ldapUsername, ldapPassword, AuthenticationTypes.Secure);
        }
        #endregion
    }
}
