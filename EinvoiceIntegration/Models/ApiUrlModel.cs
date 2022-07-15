using EinvoiceIntegration.Enum;
using EinvoiceIntegration.Enum.B2B;
using EinvoiceIntegration.Enum.B2C;
using EinvoiceIntegration.Interfaces;
using EinvoiceIntegration.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace EinvoiceIntegration.Models
{
    internal class ApiUrlModel : IApiUrlModel
    {
        private string cacheName = "apiList";
        private ObjectCache cache = MemoryCache.Default;

        public ApiUrlModel()
        {
        }

        public List<ApiUrl> GetList()
        {
            var apiUrls = (List<ApiUrl>)cache.Get(cacheName);

            if (apiUrls == null) apiUrls = GetApiUrls();

            return apiUrls;
        }

        private List<ApiUrl> GetApiUrls()
        {
            ResourceSet resourceSet;
            var list = new List<ApiUrl>();

            resourceSet = B2C_ApiUrl_Resource.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                list.Add
                (
                    new ApiUrl
                    {
                        apiUrl = entry.Value.ToString(),
                        env = (EnvironmentEnum)System.Enum.Parse(typeof(EnvironmentEnum), entry.Key.ToString()),
                        Category = EinvoiceCategory.B2C
                    }
                );
            }

            resourceSet = B2B_ApiUrl_Resource.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                list.Add
                (
                    new ApiUrl
                    {
                        apiUrl = entry.Value.ToString(),
                        env = (EnvironmentEnum)System.Enum.Parse(typeof(EnvironmentEnum), entry.Key.ToString()),
                        Category = EinvoiceCategory.B2B
                    }
                );
            }

            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.AddHours(12);
            cache.Set(cacheName, list, policy);
            return list;
        }
    }

    public class ApiUrl
    {
        /// <summary>
        /// B2C or B2B
        /// </summary>
        public EinvoiceCategory Category { get; set; }

        /// <summary>
        /// API位置
        /// </summary>
        public string apiUrl { get; set; }

        /// <summary>
        /// API環境
        /// </summary>
        public EnvironmentEnum env { get; set; }
    }
}
