using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.Common
{
    public class PlatformServiceCache
    {
        private static PlatformServiceCache _instance = new PlatformServiceCache();
        public static PlatformServiceCache Instance
        {
            get
            {
                return _instance;
            }
        }
        private Dictionary<string, object> _caches = new Dictionary<string, object>();
        public Object GetCache(string interfaceName)
        {
            if (_caches.ContainsKey(interfaceName))
                return _caches[interfaceName];
            else
                return null;
        }
        public void CacheClear(string interfaceName)
        {
            _caches.Remove(interfaceName);
        }
        public void AddCache(string interfaceName, Object classObject)
        {
            _caches.Add(interfaceName, classObject);
        }
        public bool IsExists(string interfaceName)
        {
            return _caches.ContainsKey(interfaceName);            
        }
    }
}
