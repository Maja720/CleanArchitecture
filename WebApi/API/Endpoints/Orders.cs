namespace WebApi.API.Endpoints;

using Application.Orders.Create;
using Application.Orders.GetOrderSummary;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Routing;

public class Orders : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("orders", async (Guid customerId, ISender sender) =>
        {
            var command = new CreateOrderCommand(customerId);

            await sender.Send(command);

            return Results.Ok();
        });

        app.MapGet("orders/{id}/summary", async (Guid id, ISender sender) =>
        {
            var query = new GetOrderSummaryQuery(id);

            await sender.Send(query);

            return Results.Ok();
        });
    }
} 
