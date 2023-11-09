
using ValuationModel;

DbMock DB = new DbMock();
ValuationProcessor FMV = new(DB);

List<uint> IMOsToEvaluate = new List<uint> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
List<int> YearsToEaluate = new List<int> {2020, 2021, 2022};

Dictionary<uint, Dictionary<int, double>> res = FMV.CalcFairMarketValue(IMOsToEvaluate, YearsToEaluate);

foreach (uint k in IMOsToEvaluate) 
{
    Console.WriteLine($"Evaluating IMO {k} {DB.Read(k)}: ");
    foreach(int y in YearsToEaluate) 
    {
        Dictionary<int, double> SingleImoResult  = res[k];
        Console.Write($"{y} : {SingleImoResult[y]}, ");
    }
    Console.WriteLine();
}
Console.WriteLine($"{FMV.CalcFairMarketValue(IMOsToEvaluate, YearsToEaluate)}");