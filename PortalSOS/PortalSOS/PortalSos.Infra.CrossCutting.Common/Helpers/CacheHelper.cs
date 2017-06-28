using System;
using System.Collections;
using System.Runtime.Caching;
using System.Web.Security;

namespace FidelizarMais.Infra.CrossCutting.Common.Helpers
{
    public static class CacheHelper
    {
        private const string KeySeparator = "_";
        public const string KeyOne = "_Key_Cache_Logged_Is_Null_";
        private const string DefaultDomain = "DefaultDomain";

        // -----------------------------------------------------------------------------------------------------------------------------
        // The default instance of the MemoryCache is used.
        // Memory usage can be configured in standard config file.
        // -----------------------------------------------------------------------------------------------------------------------------
        // cacheMemoryLimitMegabytes:   The amount of maximum memory size to be used. Specified in megabytes. 
        //                              The default is zero, which indicates that the MemoryCache instance manages its own memory
        //                              based on the amount of memory that is installed on the computer. 
        // physicalMemoryPercentage:    The percentage of physical memory that the cache can use. It is specified as an integer value from 1 to 100. 
        //                              The default is zero, which indicates that the MemoryCache instance manages its own memory 
        //                              based on the amount of memory that is installed on the computer. 
        // pollingInterval:             The time interval after which the cache implementation compares the current memory load with the 
        //                              absolute and percentage-based memory limits that are set for the cache instance.
        //                              The default is two minutes.
        // -----------------------------------------------------------------------------------------------------------------------------
        //  <configuration>
        //    <system.runtime.caching>
        //      <memoryCache>
        //        <namedCaches>
        //          <add name="default" cacheMemoryLimitMegabytes="0" physicalMemoryPercentage="0" pollingInterval="00:02:00" />
        //        </namedCaches>
        //      </memoryCache>
        //    </system.runtime.caching>
        //  </configuration>
        // -----------------------------------------------------------------------------------------------------------------------------

        private static MemoryCache Cache
        {
            get { return MemoryCache.Default; }
        }

        public static void Remove(string Key, string domain = null)
        {
            Cache.Remove(CombinedKey(Key, domain));
        }

        public static void RemoveAll(string Key, string domain = null)
        {
            IDictionaryEnumerator enumerator = System.Web.HttpRuntime.Cache.GetEnumerator();

            while (enumerator.MoveNext())
            {
                string key = (string)enumerator.Key;
                //object value = enumerator.Value;
                Cache.Remove(CombinedKey(key, domain));
            }

            FormsAuthentication.SignOut();
            Remove(domain);
        }

        public static void SetSliding(string Key, object data, double minutes, string domain = null)
        {
            CacheItemPolicy policy = new CacheItemPolicy { SlidingExpiration = TimeSpan.FromMinutes(minutes) };
            Set(Key, data, policy, domain);
        }

        public static void SetAbsolute(string Key, object data, double minutes, CacheEntryRemovedCallback callback, string domain = null)
        {
            CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(minutes), RemovedCallback = callback };
            Set(Key, data, policy, domain);
        }

        public static void SetAbsolute(string Key, object data, double minutes = 30, string domain = null)
        {
            CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(minutes) };
            Set(Key, data, policy, domain);
        }

        public static void SetPermanent(string Key, object data, string domain = null)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            Set(Key, data, policy, domain);
        }

        public static bool Exists(string Key, string domain = null)
        {
            return Cache[CombinedKey(Key, domain)] != null;
        }

        public static T Get<T>(string domain = null)
        {
            return (T)Get(domain);
        }

        public static object Get(string Key, string domain = null)
        {
            return Cache.Get(CombinedKey(Key, domain));
        }

        public static string ParseKey(string combinedKey)
        {
            return combinedKey.Substring(combinedKey.IndexOf(KeySeparator) + KeySeparator.Length);
        }

        private static void Set(object key, object data, CacheItemPolicy expires, string domain = null)
        {
            Cache.Set(CombinedKey(key, domain), data, expires);
        }

        private static string CombinedKey(object key, string domain)
        {
            return string.Format("{0}{1}{2}", string.IsNullOrEmpty(domain) ? DefaultDomain : domain, KeySeparator, key);
        }
    }
}