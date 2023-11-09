using Microsoft.AspNetCore.Mvc;
using ValuationModel;


[ApiController]
[Route("[controller]")]
public class ValuationController: ControllerBase
{

    [HttpGet(Name = "GetAllValuations")]
    public IEnumerable<VesselOutput> GetAllValuations()
    {
        DbMock DB = new DbMock();
        ValuationProcessor FMV = new(DB);

        List<uint> IMOsToEvaluate = new List<uint> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
        List<int> YearsToEaluate = new List<int> {2021, 2020, 2022}; // out of order to test sort

        List<Vessel> outputList =  FMV.GetAllValuations(YearsToEaluate);
        List<VesselOutput> vOut = new();
        foreach (Vessel v in outputList) 
        {
            string vTypeStr = "";
            // theres pros a way to do this without switch but running out of time 
            switch (v.vesselType) 
            {
                case Vessel.VesselTypeEnum.CONTAINER_SHIP:
                    vTypeStr = "CONTAINER_SHIP";
                    break;
                case Vessel.VesselTypeEnum.DRY_BULK:
                    vTypeStr = "DRY_BULK";
                    break;
                case Vessel.VesselTypeEnum.OIL_TANKER:
                    vTypeStr = "OIL_TANKER";
                    break;
            }
            vOut.Add(new(v.IMO, v.Size, vTypeStr, v.YearOfBuild, v.GetValuations()));
        }
        return vOut;
    }

    [HttpPost(Name = "GetValuation")]
    public double GetValuation(uint IMO, int year)
    {
        DbMock DB = new DbMock();
        ValuationProcessor FMV = new(DB);
        return FMV.CalcSingleFairMarketValue(IMO, year);
    }
}



