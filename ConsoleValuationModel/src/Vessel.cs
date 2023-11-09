
namespace ValuationModel;

public class Vessel
{
    public enum VesselTypeEnum
    {
        DRY_BULK,
        OIL_TANKER,
        CONTAINER_SHIP
    }
    public uint Size { 
        get => _Size;
        set { _Size = SetSize(value);}
    }

    public uint IMO;
    public VesselTypeEnum vesselType;
    
    public uint YearOfBuild;
    private Dictionary<int, double> Valuations = new();
    private uint _Size;

    public Vessel(uint IMO, VesselTypeEnum vesselType, uint YearOfBuild, uint Size)
    {
        this.IMO = IMO;
        this.vesselType = vesselType;
        this.YearOfBuild = YearOfBuild;
        _Size = this.Size = Size;
    }

    public void AddValuadtion(int year, double val) 
    {
        Valuations[year] = val;
    }

    public Dictionary<int, double> GetValuations() 
    {
        return Valuations;
    }

    public override string ToString()
    {
        return $"Vessel[{this.vesselType}, Size: {this.Size}, Contains Evaluations: {Valuations.Count != 0}]";
    }
    private uint SetSize(uint inpSize) 
    {
        string ExReason = string.Empty;
        switch(vesselType) 
        {
            case VesselTypeEnum.DRY_BULK: // Dry Bulk: 25000-125000, 
                if (inpSize >= 25000 && inpSize <= 125000) {return inpSize;}
                ExReason = "Dry Bulk: 25000-125000"; 
                break;
            case VesselTypeEnum.OIL_TANKER: // Oil Tanker: 35000-75000
                if (inpSize >= 35000 && inpSize <= 75000) {return inpSize;}
                ExReason = "Oil Tanker: 35000-75000"; 
                break;
            case VesselTypeEnum.CONTAINER_SHIP: // Containership: 20000-45000 If year of build is smaller than 2018, otherwise 20000-55000
                if (this.YearOfBuild < 2018) 
                {
                    if (inpSize >= 20000 && inpSize <= 45000) 
                    {
                        return inpSize;
                    }
                    ExReason = "Containership: 20000-45000, If year of build is smaller than 2018"; 
                } else 
                {
                    if (inpSize >= 20000 && inpSize <= 55000) 
                    {
                        return inpSize;
                    }
                    ExReason = "Containership: 20000-55000, If year of build is greater than 2018"; 
                }
                break;
            default:
                break;
        }
        throw new Exception($"Muse define vessel type before setting vessel size. {ExReason}");
    }
}
