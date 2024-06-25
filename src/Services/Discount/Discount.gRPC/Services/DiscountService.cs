using Contracts.DataTransferObjects;
using Discount.gRPC.Abstractions;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.Services;

public class DiscountService
    (IDiscountContext dbContext, ILogger<DiscountService> logger)
    : DiscountProtoService.DiscountProtoServiceBase, IDiscountService
{
    private readonly IDiscountContext _dbContext = dbContext;
    private readonly ILogger<DiscountService> _logger = logger;
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await _dbContext
            .Coupons
            .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

        if (coupon is null)
            coupon = new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" };

        _logger.LogInformation("Discount is retrieved for ProductName : {productName}, Amount : {amount}", coupon.ProductName, coupon.Amount);

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();
        if (coupon is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));

        _dbContext.Coupons.Add(coupon);
        await _dbContext.SaveChangesAsync();

        _logger.LogInformation("Discount is successfully created. ProductName : {ProductName}", coupon.ProductName);

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }


    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();
        if (coupon is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));

        _dbContext.Coupons.Update(coupon);
        await _dbContext.SaveChangesAsync();

        _logger.LogInformation("Discount is successfully updated. ProductName : {ProductName}", coupon.ProductName);

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var coupon = await _dbContext
            .Coupons
            .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

        if (coupon is null)
            throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName={request.ProductName} is not found."));

        _dbContext.Coupons.Remove(coupon);
        await _dbContext.SaveChangesAsync();

        _logger.LogInformation("Discount is successfully deleted. ProductName : {ProductName}", request.ProductName);

        return new DeleteDiscountResponse { Success = true };
    }
}