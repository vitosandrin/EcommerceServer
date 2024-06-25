using Contracts.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.Abstractions;

public interface IDiscountContext
{
    DbSet<Coupon> Coupons { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}