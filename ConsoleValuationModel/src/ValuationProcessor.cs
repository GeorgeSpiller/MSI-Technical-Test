
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
        cache = new CacheManager();
    }

    public void CalcFairMarketValue(List<uint> IMO_List, List<int> ValuationYears) 
    {
        throw new NotImplementedException();
    }
    
    public double CalcFairMarketValue(uint IMO, int year) 
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
        double FMV = A * v.Size + B * (year - v.YearOfBuild) + Constant;

        return FMV;
        
    }
    
}