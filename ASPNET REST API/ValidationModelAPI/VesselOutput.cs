
public class VesselOutput
{
    public uint IMO {get; set;}
    public uint Size {get; set;}
    public string Type {get; set;} = "";
    public uint YearOfBuild {get; set;}
    public Dictionary<int, double> Valuations {get; set;}

    public VesselOutput(uint IMO, uint Size, string Type, uint YearOfBuild, Dictionary<int, double> Valuations)
    {
        this.IMO = IMO;
        this.Size = Size;
        this.Type = Type;
        this.YearOfBuild = YearOfBuild;
        this.Valuations = Valuations;
    }
}
