
# Description
This project uses the below formula  
 A x Size + B x Age in years + Constant  
to calculate the Fair Market Value of a specific vessel.  
A mock database is used, that houses various different vessels, all with a unique IMO. This database mock uses a CRUD interface.  
All the business code for this is in the dir ConsoleValuationModel.  
The dir ValuationModelAPI houses a simple api, with a single endpoint /valuation. 
Using a GET request will yeild the full database of vessles with their valuations. If a vessel does not have its valuation
cached, then a new ones for the years 2020, 2021, 2022 are calculated.  

# Additional extentions
Many improv








