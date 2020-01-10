using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Base.Infrastructure.Config
{
    public class Settings : ConfigurationSection, IBaseSettings, IWebSettings
    {
        #region Unuses members

        [ConfigurationProperty("connectionStringName", IsRequired = true)]
        public string ConnectionStringName
        {
            get { return (string)this["connectionStringName"]; }
        }

        [ConfigurationProperty("host", IsRequired = true)]
        public string Host
        {
            get { return (string)this["host"]; }
        }

        [ConfigurationProperty("resourcesUrl", IsRequired = true)]
        public string ResourcesUrl
        {
            get { return (string)this["resourcesUrl"]; }
        }

        [ConfigurationProperty("resourcesVersion", IsRequired = true)]
        public int ResourcesVersion
        {
            get { return (int)this["resourcesVersion"]; }
        }

        [ConfigurationProperty("passwordLength", DefaultValue = 8)]
        public int PasswordLength
        {
            get { return (int)this["passwordLength"]; }
        }

        [ConfigurationProperty("passwordChars", DefaultValue = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890")]
        public string PasswordChars
        {
            get { return (string)this["passwordChars"]; }
        }

        [ConfigurationProperty("persistentAuthCookie", DefaultValue = true)]
        public bool PersistentAuthCookie
        {
            get { return (bool)this["persistentAuthCookie"]; }
        }

        [ConfigurationProperty("publicStorageUrl", IsRequired = true)]
        public string PublicStorageUrl
        {
            get { return (string)this["publicStorageUrl"]; }
        }

        [ConfigurationProperty("publicStoragePath", IsRequired = true)]
        public string PublicStoragePath
        {
            get { return (string)this["publicStoragePath"]; }
        }

        [ConfigurationProperty("privateStoragePath", IsRequired = true)]
        public string PrivateStoragePath
        {
            get { return (string)this["privateStoragePath"]; }
        }

        [ConfigurationProperty("geoLocationDatabasePath", IsRequired = true)]
        public string GeoLocationDatabasePath
        {
            get { return (string)this["geoLocationDatabasePath"]; }
        }

        [ConfigurationProperty("fileMaxSize", IsRequired = true)]
        public int FileMaxSize
        {
            get { return (int)this["fileMaxSize"]; }
        }

        #endregion

        #region IWebSettings members

        [ConfigurationProperty("webApiUrl", IsRequired = true)]
        public string WebApiUrl
        {
            get { return (string)this["webApiUrl"]; }
        }

        [ConfigurationProperty("webFormUrl", IsRequired = true)]
        public string WebFormUrl
        {
            get { return (string)this["webFormUrl"]; }
        }

        [ConfigurationProperty("webMvcUrl", IsRequired = true)]
        public string WebMvcUrl
        {
            get { return (string)this["webMvcUrl"]; }
        }

        #endregion

        #region IBaseSettings members

        [ConfigurationProperty("tempPath", IsRequired = true)]
        public string TempPath
        {
            get { return (string)this["tempPath"]; }
        }

        [ConfigurationProperty("isProduction", IsRequired = true)]
        public bool IsProduction
        {
            get { return (bool)this["isProduction"]; }
        }

        [ConfigurationProperty("generateSchema", IsRequired = true)]
        public bool GenerateSchema
        {
            get { return (bool)this["generateSchema"]; }
        }

        #endregion
    }
}

