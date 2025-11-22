using Application.Common;
using Domain.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Application.Orders.GetOrderSummary
{
    internal sealed class GetOrderSummaryQueryHandler
        : IRequestHandler<GetOrderSummaryQuery, OrderSummary?>
    {
        private readonly IApplicationDbContext _context;

        public GetOrderSummaryQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OrderSummary?> Handle(GetOrderSummaryQuery request, CancellationToken cancellationToken)
        {
            return await _context.OrderSummaries
                .AsNoTracking()
                .FirstOrDefaultAsync(order => order.Id == request.OrderId, cancellationToken);
        }
    }
}
