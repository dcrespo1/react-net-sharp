using System;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Health.Queries;

public class GetHealthStatus
{
    public class Query : IRequest<JsonArray> { }

    public class Handler : IRequestHandler<Query, JsonArray>
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public Handler(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<JsonArray> Handle(Query request, CancellationToken cancellationToken)
        {
            var version = _configuration["Version"] ?? "unknown";
            string dbStatus;

            try
            {
                
                await _context.Database.ExecuteSqlRawAsync("SELECT 1", cancellationToken);
                dbStatus = "Healthy";
            }
            catch
            {
                dbStatus = "Unhealthy";
            }

            var healthStatus = new JsonArray
            {
                new JsonObject
                {
                    ["status"] = "OK",
                    ["timestamp"] = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")).ToString("o"),
                    ["version"] = version,
                    ["database"] = dbStatus
                }
            };
            return healthStatus;
        }
    }
}
