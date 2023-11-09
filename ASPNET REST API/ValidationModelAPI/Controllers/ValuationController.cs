using Microsoft.AspNetCore.Mvc;
using ValuationModel;


[ApiController]
[Route("[controller]")]
public class ValuationController: ControllerBase
{

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<Vessel> Get()
    {

    }
}
