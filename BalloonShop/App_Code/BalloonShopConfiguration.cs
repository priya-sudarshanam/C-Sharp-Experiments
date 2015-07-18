using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
/// Summary description for BalloonShopConfiguration
/// </summary>
public static class BalloonShopConfiguration
{
    /// <summary>
    /// Repository for BalloonShop configuration settings
    /// </summary>
        private static string mailServer;
        private static string mailUserName;
        private static string mailPassword;
        private static string mailFrom;
        private static string mailEnableErrorLogEmail;
        private static string mailErrorLogEmail;
        private static string dbConnectionString;
        private static string dbProviderName;
        private static readonly int productsPerPage;
        private static readonly int productsDescriptionLength;       
        private static readonly string siteName;

        static BalloonShopConfiguration()
        {
            mailServer = ConfigurationManager.AppSettings["MailServer"];
            mailUserName = ConfigurationManager.AppSettings["MailUsername"];
            mailPassword = ConfigurationManager.AppSettings["MailPassword"];
            mailFrom = ConfigurationManager.AppSettings["MailFrom"];
            mailEnableErrorLogEmail = ConfigurationManager.AppSettings["EnableErrorLogEmail"];
            mailErrorLogEmail = ConfigurationManager.AppSettings["ErrorLogEmail"];
            productsPerPage = System.Int32.Parse(ConfigurationManager.AppSettings["ProductsPerPage"]);
            productsDescriptionLength = System.Int32.Parse(ConfigurationManager.AppSettings["ProductsDescriptionLength"]);
            siteName = ConfigurationManager.AppSettings["SiteName"];
            dbConnectionString = ConfigurationManager.ConnectionStrings["BalloonShopConnection"].ConnectionString;
            dbProviderName = ConfigurationManager.ConnectionStrings["BalloonShopConnection"].ProviderName;
        }

        public static string DbConnectionString
        {
            get
            {
                return dbConnectionString;
            }
        }

        public static int ProductsPerPage
        {
            get
            {
                return productsPerPage;
            }
        }

        public static int ProductsDescriptionLength
        {
            get
            {
                return productsDescriptionLength;
            }
        }

        public static string SiteName
        {
            get
            {
                return siteName;
            }
        }

        public static string DbProviderName
        {
            get
            {
                return dbProviderName;
            }
        }

        public static string MailServer
        {
            get
            {
                return mailServer;

            }
        }

        public static string MailUsername
        {
            get
            {
                return mailUserName;

            }
        }
        public static string MailPassword
        {
            get
            {
                return mailPassword;

            }
        }

        public static string MailFrom
        {
            get
            {
                return mailFrom;

            }
        }

        public static bool EnableErrorLogEmail
        {
            get
            {
                return bool.Parse(mailEnableErrorLogEmail);

            }
        }

        public static string ErrorLogEmail
        {
            get
            {
                return mailErrorLogEmail;

            }
        }


    }
