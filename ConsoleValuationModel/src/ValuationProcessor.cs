
namespace ValuationModel;

public class ValuationProcessor_CLV 
{

    private const double A = 0.001;
    private const int B = -1;
    private const int Constant = 0;
    private DbMock DB;
    private CacheManager cache;
    public ValuationProcessor_CLV(DbMock db)
    {
        DB = db;
        cache = new CacheManager();
    }

    /*
        The calculation logic for the timeseries is a linear parametric equation of the format:
        Timeseries = A x Size + B x Age in years + Constant
        For example, to calculate the Fair Market Value for a Dry Bulk vessel:
        Fair Market Value ($Mn) = 0.001 x Size – 1 * Age + 3
        Assume that a list of vessels is already stored in a database 
    */

    public void CalcFairMarketValue(List<uint> IMO_List, List<int> ValuationYears) 
    {
        throw new NotImplementedException();
    }
    
    public double CalcFairMarketValue(uint IMO, int year)  
    {
        throw new NotImplementedException();
    }
    
}