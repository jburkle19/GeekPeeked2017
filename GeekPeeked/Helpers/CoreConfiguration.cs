using System;
using System.Configuration;

namespace GeekPeeked.Helpers
{
    public class CoreConfiguration
    {
        public static int? ActiveContestId
        {
            get
            {
                int result = 0;
                if (ConfigurationManager.AppSettings["ActiveContestId"] != null && Int32.TryParse(ConfigurationManager.AppSettings["ActiveContestId"].ToString(), out result))
                    return result;

                return null; // default value
            }
        }
        public static bool IsActiveContestSignUpOpen
        {
            get
            {
                bool result = false; // default value
                if (ConfigurationManager.AppSettings["IsActiveContestSignUpOpen"] != null && Boolean.TryParse(ConfigurationManager.AppSettings["IsActiveContestSignUpOpen"].ToString(), out result))
                    return result;

                return false;
            }
        }

        public static string ErrorEmailAddress
        {
            get
            {
                if (ConfigurationManager.AppSettings["ErrorEmailAddress"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["ErrorEmailAddress"].ToString()))
                    return ConfigurationManager.AppSettings["ErrorEmailAddress"].ToString();
                else
                    return "jburkle19@gmail.com"; // default
            }
        }
        public static string EmailSubjectTitle
        {
            get
            {
                if (ConfigurationManager.AppSettings["EmailSubjectTitle"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["EmailSubjectTitle"].ToString()))
                    return ConfigurationManager.AppSettings["EmailSubjectTitle"].ToString();
                else
                    return "Geek Peeked"; // default
            }
        }

        public static string MailFromName
        {
            get
            {
                if (ConfigurationManager.AppSettings["smtpFromName"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["smtpFromName"].ToString()))
                    return ConfigurationManager.AppSettings["smtpFromName"].ToString();
                else
                    return string.Empty;
            }
        }
        public static string MailFromEmail
        {
            get
            {
                if (ConfigurationManager.AppSettings["smtpFromEmail"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["smtpFromEmail"].ToString()))
                    return ConfigurationManager.AppSettings["smtpFromEmail"].ToString();
                else
                    return string.Empty;
            }
        }
        public static string MailUserName
        {
            get
            {
                if (ConfigurationManager.AppSettings["smtpUserName"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["smtpUserName"].ToString()))
                    return ConfigurationManager.AppSettings["smtpUserName"].ToString();
                else
                    return string.Empty;
            }
        }
        public static string MailPassword
        {
            get
            {
                if (ConfigurationManager.AppSettings["smtpPassword"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["smtpPassword"].ToString()))
                    return ConfigurationManager.AppSettings["smtpPassword"].ToString();
                else
                    return string.Empty;
            }
        }
        public static string MailHost
        {
            get
            {
                if (ConfigurationManager.AppSettings["smtpHost"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["smtpHost"].ToString()))
                    return ConfigurationManager.AppSettings["smtpHost"].ToString();
                else
                    return string.Empty;
            }
        }
        public static int MailPort
        {
            get
            {
                int result = 0;

                if (ConfigurationManager.AppSettings["smtpPort"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["smtpPort"].ToString()))
                    int.TryParse(ConfigurationManager.AppSettings["smtpPort"].ToString(), out result);

                return result;
            }
        }
        public static bool MailTLS
        {
            get
            {
                bool result = false;

                if (ConfigurationManager.AppSettings["smtpTLS"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["smtpTLS"].ToString()))
                    bool.TryParse(ConfigurationManager.AppSettings["smtpTLS"].ToString(), out result);

                return result;
            }
        }

        public static string VerifyContestFormatURL
        {
            get
            {
                if (ConfigurationManager.AppSettings["verifyContestFormatString"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["verifyContestFormatString"].ToString()))
                    return ConfigurationManager.AppSettings["verifyContestFormatString"].ToString();
                else
                    return string.Empty;
            }
        }
    }
}