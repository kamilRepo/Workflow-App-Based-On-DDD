using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Web.Mvc;
using Workflow.Base.Infrastructure.Config;

namespace Workflow.Basic.Presentation.Extensions
{
    public static class UrlExtensions
    {
        public static string ReferenceToWebForm(this UrlHelper urlHelper, string path)
        {
            var settings = SettingsProvider.WebSettings;
            var url = string.Format("{0}{1}", settings.WebFormUrl, path);

            return urlHelper.IsLocalUrl(url) ? urlHelper.Content(url) : url;
        }

        public static string ReferenceToWebMvc(this UrlHelper urlHelper, string path)
        {
            var settings = SettingsProvider.WebSettings;
            var url = string.Format("{0}{1}", settings.WebMvcUrl, path);

            return urlHelper.IsLocalUrl(url) ? urlHelper.Content(url) : url;
        }

        public static string Reference(this UrlHelper urlHelper, string path)
        {
            throw new NotImplementedException();
            //TODO
            //var settings = SettingsProvider.WebSettings;
            //var url = string.Format("{0}{1}?version={2}", settings.ResourcesUrl, path, settings.ResourcesVersion);

            //return urlHelper.IsLocalUrl(url) ? urlHelper.Content(url) : url;
        }

        public static string ReferenceLocalized(this UrlHelper urlHelper, string path)
        {
            throw new NotImplementedException();
            //TODO
            //path = string.Format(path, CultureInfo.CurrentCulture.Name);

            //var settings = SettingsProvider.WebSettings;
            //var url = string.Format("{0}{1}?version={2}", settings.ResourcesUrl, path, settings.ResourcesVersion);

            //return urlHelper.IsLocalUrl(url) ? urlHelper.Content(url) : url;
        }
    }
}
