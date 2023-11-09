
namespace ValuationModel;

public class DbMock
{
    private List<Vessel> _DB = new();
    public DbMock()
    {
        Vessel svm_db1 = new(0, Vessel.VesselType.DRY_BULK, 2015, 25000);

        _DB.Add(svm_db1);
    }

}