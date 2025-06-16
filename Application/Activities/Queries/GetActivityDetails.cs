using System;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities.Queries;

public class GetActivityDetails()
{
    public class Query : IRequest<Activity>
    {
        public required string id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, Activity>
    {
        public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities.FindAsync([request.id], cancellationToken: cancellationToken)
             ?? throw new Exception("Activity not found");
            return activity;
        }
    }
}
