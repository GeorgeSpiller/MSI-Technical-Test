using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace ValuationModel;

public class CacheManager
{
    private Dictionary<string, Tuple<DateTime, dynamic>> _cache = new();
    private readonly TimeSpan cacheLifetime = new(0, 0, 2); // 0h, 1m, 0s
    public CacheManager()
    {
    }
    
    public void AddCache(string key, dynamic data) 
    {
        // Tuple<DateTime, dynamic> cacheObj = new(datetime.now, data);
        // _cache[key] = cacheObj; 
        throw new NotImplementedException();
    }

    public dynamic? ReadCache(string key) 
    {
        // Tuple<DateTime, dynamic> cacheObj = _cache[key];
        // remove if reached end-of-life (cacheLifetime)
        // ret cacheObj
        throw new NotImplementedException();
    }

}