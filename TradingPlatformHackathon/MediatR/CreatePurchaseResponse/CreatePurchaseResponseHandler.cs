using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.Models;
using TradingPlatformHackathon.Repositories;

namespace TradingPlatformHackathon.MediatR.CreatePurchaseResponse;

public class CreatePurchaseResponseHandler : IRequestHandler<CreatePurchaseResponseRequest,
    Result<CreatePurchaseResponseResponse>>
{
    private readonly UserRepository _userRepository;
    private readonly PurchaseResponseRepository _purchaseResponseRepository;

    public CreatePurchaseResponseHandler(UserRepository userRepository, PurchaseResponseRepository purchaseResponseRepository)
    {
        _userRepository = userRepository;
        _purchaseResponseRepository = purchaseResponseRepository;
    }

    public async Task<Result<CreatePurchaseResponseResponse>> Handle(CreatePurchaseResponseRequest request,
        CancellationToken cancellationToken)
    {
        var supplier = await _userRepository.GetById(request.SupplierId, cancellationToken);
        if (supplier == null)
        {
            return Result.Fail("Пользователь не найден!");
        }

        var purchaseResponse = new PurchaseResponse()
        {
            PurchaseRequestId = request.PurchaseRequestId,
            Cost = request.Cost,
            Comment = request.Comment,
            SupplierId = supplier.Id
        };
        _purchaseResponseRepository.Add(purchaseResponse);
        await _purchaseResponseRepository.SaveChanges(cancellationToken);

        return Result.Ok(new CreatePurchaseResponseResponse());
    }
}