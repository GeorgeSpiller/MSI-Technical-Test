
namespace ValuationModel;

public class Vessel
{
    public enum VesselType
    {
        DRY_BULK,
        OIL_TANKER,
        CONTAINER_SHIP
    }
    public uint Size { get; set; }

    public uint IMO;
    public VesselType vesselType;
    
    public uint YearOfBuild;
    private Dictionary<int, double> Valuations = new();

    public Vessel(uint IMO, VesselType vesselType, uint YearOfBuild, uint Size)
    {
        this.IMO = IMO;
        this.vesselType = vesselType;
        this.YearOfBuild = YearOfBuild;
        this.Size = Size;
    }
}


