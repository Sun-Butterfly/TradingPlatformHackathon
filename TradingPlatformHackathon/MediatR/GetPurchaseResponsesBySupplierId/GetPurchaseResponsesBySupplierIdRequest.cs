using FluentResults;
using MediatR;

namespace TradingPlatformHackathon.MediatR.GetPurchaseResponsesBySupplierId;

public record GetPurchaseResponsesBySupplierIdRequest(long SupplierId) : IRequest<Result<GetPurchaseResponsesBySupplierIdResponse>>;