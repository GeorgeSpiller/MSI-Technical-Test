using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace ValuationModel;

public class CacheManager
{
    private Dictionary<string, Tuple<DateTime, dynamic>> _cache = new();
    private readonly TimeSpan cacheLifetime = new(0, 0, 2); // 0h, 1m, 0s
    public bool Freeze = false;

    public CacheManager()
    {
    }
    
    public void AddCache(string key, dynamic data) 
    {
        if (Freeze) 
        {
            throw new Exception("Attempting to add to cache while cache is frozen");
        }
        DateTime dt = DateTime.Now;
        Tuple<DateTime, dynamic> cacheObj = new(dt, data);
        _cache[key] = cacheObj; 
    }

    public dynamic? ReadCache(string key) 
    {
        if (!_cache.ContainsKey(key)) 
        {
            Console.WriteLine("No cache Hit.");
            return null;
        }

        Console.WriteLine("Cache Hit.");
        Tuple<DateTime, dynamic> cacheObj = _cache[key];
        if (cacheObj.Item1 + cacheLifetime < DateTime.Now) 
        {
            return cacheObj.Item2;
        } else 
        {
            if (!Freeze) 
            {
                _cache.Remove(key);
            }
        }
        return null;
    }

    public string GetHashAsString(string inp) 
    {
        byte[] tmpSource;
        byte[] tmpHash;
        tmpSource = ASCIIEncoding.UTF8.GetBytes(inp);
        tmpHash = MD5.HashData(tmpSource);
        // return ASCIIEncoding.UTF8.GetString(tmpHash) ?? "";
        return BitConverter.ToString(tmpHash).Replace("-", string.Empty);
    }

}