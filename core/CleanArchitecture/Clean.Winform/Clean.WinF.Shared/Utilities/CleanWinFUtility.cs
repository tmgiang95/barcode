using Clean.WinF.Shared.Constants;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace Clean.WinF.Infrastructure.Utilities
{
    public static class CleanWinFUtility
    {
        public static string accessToken = string.Empty;
        public static string userNTIT = string.Empty;
        public static string[] ConvertStringToArray(string inputValue, string operatorValue)
        {
            string[] arrRet = null;
            string[] arrOperator = { operatorValue };

            if (!string.IsNullOrEmpty(inputValue))
                arrRet = inputValue.Split(arrOperator, StringSplitOptions.None);

            return arrRet;
        }

        public static string GetFullNameAndDepartmentFromLDAPUser(string ldapUserDisplayName, bool isDepartment)
        {
            string nameRet = string.Empty;

            if (!string.IsNullOrEmpty(ldapUserDisplayName))
            {
                var arrDepartName = ConvertStringToArray(ldapUserDisplayName, "(");
                if (arrDepartName != null && arrDepartName.Length > 1)
                {
                    if (isDepartment)
                        nameRet = arrDepartName[1].Trim().Replace("(", string.Empty).Replace(")", string.Empty);
                    else
                        nameRet = arrDepartName[0].Trim();
                }
            }

            return nameRet;
        }

        //public static bool SendEmailInBosch(ILogger _logger, EmailDto emailDto, bool autoSending)
        //{
        //    if (!autoSending)
        //    {
        //        return true;
        //    }
        //    var smtpClient = new SmtpClient();
        //    smtpClient.Host = emailDto.Host;

        //    var mailFrom = new MailAddress(emailDto.Sender);

        //    var emailReceiver = emailDto.EmailReceiver;
        //    var mailTo = new MailAddress(emailReceiver);
        //    var mailMessage = new MailMessage(mailFrom, mailTo);

        //    var emailTemplateFile = emailDto.EmailFileTemplate;
        //    _logger.LogInformation(string.Concat("Email template file: ", emailDto.EmailFileTemplate));

        //    using (StreamReader SourceReader = System.IO.File.OpenText(emailTemplateFile))
        //    {
        //        string htmlBody = SourceReader.ReadToEnd();

        //        htmlBody = htmlBody.Replace("[title]", emailDto.EmailTitle);
        //        htmlBody = htmlBody.Replace("[ntid]", emailDto.UserNTID);
        //        htmlBody = htmlBody.Replace("[reason]", emailDto.Reason);

        //        mailMessage.Body = htmlBody;
        //        mailMessage.IsBodyHtml = true;
        //        mailMessage.BodyEncoding = Encoding.UTF8;
        //        mailMessage.Subject = emailDto.Subject;
        //        mailMessage.SubjectEncoding = Encoding.UTF8;
        //    }
        //    try
        //    {
        //        smtpClient.Send(mailMessage);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(string.Concat("SendEmailInBosch() Error at: ", ex.ToString()));
        //        return false;
        //    }

        //    return true;
        //}

        public static bool HasSpecialCharacters(string inputValue)
        {
            bool result = false;

            var withoutSpecial = new string(inputValue.Where(c => Char.IsLetterOrDigit(c)
                                            || Char.IsWhiteSpace(c)).ToArray());

            if (inputValue != withoutSpecial)
                result = true;

            return result;
        }

        //public static bool CheckValidToken(string token)
        //{
        //    bool result = false;
        //    var jwtToken = new JwtSecurityToken(token);
        //    var currentDate = DateTime.UtcNow;
        //    if (currentDate >= jwtToken.ValidFrom.Date && currentDate <= jwtToken.ValidTo.Date)
        //    {
        //        result = true;
        //    }
        //    return result;
        //}

        //public static string GetUserNameFromToken(IConfiguration config, string token)
        //{
        //    string result = string.Empty;
        //    if (string.IsNullOrEmpty(token)) return string.Empty;
        //    var jwtToken = new JwtSecurityToken(token);

        //    if (jwtToken.Claims != null && jwtToken.Claims.Count() > 0)
        //    {
        //        foreach (var claim in jwtToken.Claims)
        //        {
        //            if (!string.IsNullOrEmpty(claim.Value))
        //            {
        //                var ldap = new LdapService(config);
        //                var existedLdapUser = ldap.FindByUserId(claim.Value);
        //                if (existedLdapUser != null)
        //                {
        //                    result = claim.Value;
        //                    break;
        //                }
        //            }
        //        }
        //    }

        //    return result;
        //}

        //public static string GetUserNTIDFromToken(IConfiguration _config)
        //{
        //    string result = string.Empty;
        //    if (!string.IsNullOrEmpty(accessToken) && string.IsNullOrEmpty(userNTIT))
        //    {
        //        result = GetUserNameFromToken(_config, accessToken);
        //        userNTIT = result;
        //    }
        //    else
        //    {
        //        result = userNTIT;
        //    }

        //    if (string.IsNullOrEmpty(result))
        //        result = CommonConstant.ADMIN;

        //    return result;
        //}

        public static bool CheckSpecialCharacter(string text)
        {            
            //just allow white space, dot, question symbol, comma, colon, equal, plus and minus characters            
            string pattern = @"[~`!#$%^&*(){}|\\;/<>\[\]\""']";
            var regex = new Regex(pattern);
            var result = regex.IsMatch(text);            
            return result;
        }

        public static bool IsValidEmailAddress(string emailAddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailAddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
