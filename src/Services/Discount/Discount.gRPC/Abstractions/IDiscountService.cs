using Grpc.Core;

namespace Discount.gRPC.Abstractions;
public interface IDiscountService
{
    Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context);
    Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context);
    Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context);
    Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context);
}