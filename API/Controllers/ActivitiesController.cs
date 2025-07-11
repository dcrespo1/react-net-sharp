using System;
using Application.Activities.Commands;
using Application.Activities.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    // Example of the cancellation token in action
    // [HttpGet]
    // public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken ct)
    // {
    //     return await Mediator.Send(new GetActivityList.Query(), ct);
    // }
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await Mediator.Send(new GetActivityList.Query());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetail(string id)
    {
        return await Mediator.Send(new GetActivityDetails.Query { id = id });
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateActivity(Activity activity)
    {
        return await Mediator.Send(new CreateActivity.Command { Activity = activity });
    }

    [HttpPut]
    public async Task<ActionResult> EditActivity(Activity activity)
    {
        await Mediator.Send(new EditActivity.Command { Activity = activity });
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteActivity(string id)
    {
        await Mediator.Send(new DeleteActivity.Command { Id = id });
        return Ok();
    }
}
