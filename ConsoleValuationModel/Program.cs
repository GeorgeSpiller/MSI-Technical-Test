
using ValuationModel;

DbMock DB = new DbMock();
ValuationProcessor FMV = new(DB);

List<uint> IMOsToEvaluate = new List<uint> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
List<int> YearsToEaluate = new List<int> {2021, 2020, 2022}; // out of order to test sort


FMV.GetAllValuations(YearsToEaluate);
