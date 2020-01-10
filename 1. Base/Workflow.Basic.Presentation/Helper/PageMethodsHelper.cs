using Workflow.Dashboard.Interface.Presentation.Dto;
using Workflow.Basic.Presentation.BasicModels;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web;
using Conf = System.Configuration;
using Workflow.Basic.Presentation.Infrastructure;
using Workflow.Base.Interface.Application.BaseDto;
using Workflow.Base.Infrastructure.Config;
using System.Globalization;
using System.Web.Security;

namespace Workflow.Basic.Presentation.Helper
{
    public static class PageMethodsHelper
    {
        public static void SetDropDownList(DropDownList dropDownList, List<DictionaryDto> list)
        {
            dropDownList.DataSource = CreateDataSource(list);
            dropDownList.DataTextField = "Text";
            dropDownList.DataValueField = "Value";
            dropDownList.DataBind();
        }

        public static ICollection CreateDataSource(List<DictionaryDto> list)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("Text", typeof(String)));
            dt.Columns.Add(new DataColumn("Value", typeof(String)));

            dt.Rows.Add(CreateRow(string.Empty, "0", dt));

            foreach (var item in list)
                dt.Rows.Add(CreateRow(item.Name, item.Id.ToString(), dt));

            DataView dv = new DataView(dt);
            return dv;

        }

        public static DataRow CreateRow(String Text, String Value, DataTable dt)
        {
            DataRow dr = dt.NewRow();

            dr[0] = Text;
            dr[1] = Value;

            return dr;
        }

        public static List<T> InvokeWebAPI<T>(string url, string param = "")
        {
            string baseURL = SettingsProvider.WebSettings.WebApiUrl;

            var root = new Root<T>();
            using (WebClient proxy = new WebClient())
            {
                proxy.Encoding = System.Text.Encoding.UTF8;
                SetAuthCookies(proxy);
                var json = proxy.DownloadString(baseURL + url + param);
                root = JsonConvert.DeserializeObject<Root<T>>(json);
                return root.Items;
            }
        }

        public static List<T> GetDataFromWebAPI<T>(string url, string method,Object obj)
        {
            //TODO: KP
            string baseURL = SettingsProvider.WebSettings.WebApiUrl;

            var root = new Root<T>();
            using (WebClient proxy = new WebClient())
            {
                proxy.Encoding = System.Text.Encoding.UTF8;
                proxy.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                byte[] byteArray = ObjectToByteArray(obj);
                byte[] byteResult = proxy.UploadData(baseURL + url, method, byteArray);
                
                root = (Root<T>)ByteArrayToObject(byteResult);

                return root.Items;
            }
        }

        public static byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        public static Object ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);
            return obj;
        }

        public static string ObjectToUrlParam(Object obj)
        {
            var sessionUser = (SessionUser)HttpContext.Current.Session[SessionVariables.user];
            var o = obj as ApplicationActionResult;
            o.UserId = sessionUser.Id;

            string s = JsonConvert.SerializeObject(obj);
            s = s.Replace("{", "?");
            s = s.Replace("}", "");
            s = s.Replace(",", "&");
            s = s.Replace(@"""", "");
            s = s.Replace(":", "=");
            s = s.Replace("null", "");

            return s.Trim();
        }

        public static string Translate(string classKey, string resourceKey)
        {
            return HttpContext.GetGlobalResourceObject(classKey, resourceKey, CultureInfo.CurrentCulture).ToString();
        }

        public static void SetAuthCookies(WebClient proxy)
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                var cookie = string.Format("{0}={1};", authCookie.Name, authCookie.Value);
                proxy.Headers.Add(HttpRequestHeader.Cookie, cookie);
            }
            else
            {
                var value = HttpContext.Current.Request.Cookies[SessionVariables.externalTokenLive].Value;
                if (value != null)
                {
                    var cookie = string.Format("{0}={1};", FormsAuthentication.FormsCookieName, value.ToString());
                    proxy.Headers.Add(HttpRequestHeader.Cookie, cookie);
                    HttpContext.Current.Response.Cookies[SessionVariables.externalTokenLive].Value = value.ToString();
                    HttpContext.Current.Response.Cookies[SessionVariables.externalTokenLive].Expires = DateTime.Now.AddDays(1);
                    HttpContext.Current.Response.Cookies[SessionVariables.externalTokenLive].HttpOnly = true;
                    HttpContext.Current.Response.Cookies[SessionVariables.externalTokenLive].Shareable = true;
                }
            }
        }
    }
}
