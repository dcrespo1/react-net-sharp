using Domain;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

public class HealthCheckController : BaseApiController
{
    [HttpGet]
    public ActionResult<string> GetHealthCheck()
    {
        return "Healthy";
    }

    [HttpGet("ping")]
    public ActionResult<string> Ping()
    {
        return "Pong";
    }
}