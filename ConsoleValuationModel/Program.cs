
using ValuationModel;

DbMock DB = new DbMock();
ValuationProcessor FMV = new(DB);

List<uint> IMOsToEvaluate = new List<uint> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
List<int> YearsToEaluate = new List<int> {2020, 2021, 2022};


// Dictionary<uint, Dictionary<int, double>> res = FMV.CalcFairMarketValue(IMOsToEvaluate, YearsToEaluate);

foreach (uint k in IMOsToEvaluate) 
{
    foreach(int y in YearsToEaluate) 
    {
        double SingleImoResult  = FMV.CalcFairMarketValue(k, y);
        Console.WriteLine($"{DB.Read(k)} {y} : {SingleImoResult}");
    }
    Console.WriteLine();
}