
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
Many improvements can me made to the rest api such as:
- separating out the /valuations request to different routes
- Adding more entry points that call the available functions in ValueationProcessor.cs  

This could also be extended to a mirco-service archetecture. Firstly, the ASP api code will be its own separate service to
the ValuationModel code. The former will not need the latter as a project dependancy. Instead, the api would push a request object
onto a message broker queue (for example using rabbitMQ). The ValuationModel would then be extended to allow it to subscribe to this 
message queue, and digest these requests. On completion, these requests can be sent back to the api via a different queue to be presented
to the end user. 








