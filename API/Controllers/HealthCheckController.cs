using System.Text.Json.Nodes;
using Application.Health.Queries;
using Domain;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

public class HealthController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<JsonArray>> GetHealthCheck()
    {
        return await Mediator.Send(new GetHealthStatus.Query());
    }

   
}