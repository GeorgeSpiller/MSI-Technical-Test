
namespace ValuationModel;

public class DbMock
{
    private List<Vessel> _DB = new();
    public DbMock()
    {
        Vessel svm_db1 = new(0, Vessel.VesselType.DRY_BULK, 2015, 25000);
        Vessel svm_db2 = new(1, Vessel.VesselType.DRY_BULK, 2015, 25000);
        Vessel svm_db3 = new(2, Vessel.VesselType.DRY_BULK, 2015, 25000);

        Vessel svm_ot1 = new(3, Vessel.VesselType.OIL_TANKER, 2015, 35000);
        Vessel svm_ot2 = new(4, Vessel.VesselType.OIL_TANKER, 2015, 35000);
        Vessel svm_ot3 = new(5, Vessel.VesselType.OIL_TANKER, 2015, 35000);

        Vessel svm_cs1 = new(6, Vessel.VesselType.CONTAINER_SHIP, 2015, 20000);
        Vessel svm_cs2 = new(7, Vessel.VesselType.CONTAINER_SHIP, 2015, 30000);
        Vessel svm_cs3 = new(8, Vessel.VesselType.CONTAINER_SHIP, 2015, 45000);
        Vessel svm_cs4 = new(9, Vessel.VesselType.CONTAINER_SHIP, 2020, 20000);
        Vessel svm_cs5 = new(10, Vessel.VesselType.CONTAINER_SHIP, 2020, 46000);
        Vessel svm_cs6 = new(11, Vessel.VesselType.CONTAINER_SHIP, 2020, 55000);

        _DB.Add(svm_db1);
        _DB.Add(svm_db2);
        _DB.Add(svm_db3);
        _DB.Add(svm_ot1);
        _DB.Add(svm_ot2);
        _DB.Add(svm_ot3);
        _DB.Add(svm_cs1);
        _DB.Add(svm_cs2);
        _DB.Add(svm_cs3);
        _DB.Add(svm_cs4);
        _DB.Add(svm_cs5);
        _DB.Add(svm_cs6);
    }

    public void Create(Vessel v) 
    {
        _DB.Add(v);
    }
    public Vessel Read(uint IMO) 
    {
        foreach (Vessel v in _DB) 
        {
            if (v.IMO == IMO) 
            {
                return v;
            }
        }
        throw new Exception($"Cannot find {IMO} in DB");
    }
    public void Update() 
    {
        throw new NotImplementedException();
    }
    public void Delete() 
    {
        throw new NotImplementedException();
    }

    public List<Vessel> ReadAll() 
    {
        return _DB;
    }
}