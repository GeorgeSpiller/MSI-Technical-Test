namespace ValuationModel;
public class ValuationProcessor 
{

    private const double A = 0.001;
    private const int B = -1;
    private const int Constant = 0;
    private DbMock DB;
    private CacheManager cache;
    public ValuationProcessor(DbMock db)
    {
        DB = db;

        // enable cache
        cache = new CacheManager();
    }

    public List<Vessel> GetAllValuations(List<int> ValuationYears) 
    {
        List<Vessel> allData = DB.ReadAll();
        foreach(Vessel v in allData) 
        {
            Dictionary<uint, Dictionary<int, double>> _ = CalcFairMarketValue(new List<uint>() {v.IMO}, ValuationYears);
            Dictionary<int, double> evals = v.GetValuations();
            // Console.Write($"{v}");
            // foreach(int k in evals.Keys) 
            // {
            //     Console.Write($"({k} : {evals[k]}) ");
            // }
            // Console.WriteLine();
        }
        return allData;
    }

    public Dictionary<uint, Dictionary<int, double>> CalcFairMarketValue(List<uint> IMO_List, List<int> ValuationYears) 
    {
        // sort Valuation years, so that the hash for the same list of years is the same (used when caching)
        ValuationYears.Sort();
        Dictionary<uint, Dictionary<int, double>>  IMOReturn = new();
        Dictionary<int, double> valResults = new();
        foreach (uint imo in IMO_List) 
        {
            // if not then calucuate the FMV
            foreach (int year in ValuationYears)
            {
                double result = CalcSingleFairMarketValue(imo, year);
                valResults[year] = result;
            }
            // shallow coppy valResults to the return dict
            IMOReturn[imo] = valResults.ToDictionary(entry => entry.Key, entry => entry.Value);

            valResults.Clear();
        }
        return IMOReturn;
    }


    public double CalcSingleFairMarketValue(uint IMO, int year) 
    {
        /*
        The calculation logic for the timeseries is a linear parametric equation of the format:
        Timeseries = A x Size + B x Age in years + Constant
        For example, to calculate the Fair Market Value for a Dry Bulk vessel:
        Fair Market Value ($Mn) = 0.001 x Size – 1 * Age + 3
        Assume that a list of vessels is already stored in a database 
        */

        // get the vessel from the db
        Vessel v = DB.Read(IMO);

        if (year < v.YearOfBuild) 
        {
            throw new Exception($"Cannot calculate valuation for {year} on a vessel that was built on ({v.YearOfBuild})");
        }

        // calculate the FMV for that year
        // first, check the cache to see if its previsouly been calculated 
        string cacheKey = cache.GetHashAsString($"{A}{v.Size}{B}{year - v.YearOfBuild}{Constant}");
        var cachRead = cache.ReadCache(cacheKey);
        if (cachRead != null) 
        {
            return (double)cachRead;
        } else 
        {
            double FMV = A * v.Size + B * (year - v.YearOfBuild) + Constant;
            cache.AddCache(cacheKey, FMV);
            v.AddValuadtion(year, FMV);
            return FMV;
        }
    }
}