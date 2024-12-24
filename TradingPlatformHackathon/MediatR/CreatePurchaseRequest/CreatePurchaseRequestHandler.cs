using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.Models;
using TradingPlatformHackathon.Repositories;

namespace TradingPlatformHackathon.MediatR.CreatePurchaseRequest;

public class CreatePurchaseRequestHandler : IRequestHandler<CreatePurchaseRequestRequest, Result<CreatePurchaseRequestResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPurchaseRequestRepository _purchaseRequestRepository;

    public CreatePurchaseRequestHandler(IUserRepository userRepository, IPurchaseRequestRepository purchaseRequestRepository)
    {
        _userRepository = userRepository;
        _purchaseRequestRepository = purchaseRequestRepository;
    }

    public async Task<Result<CreatePurchaseRequestResponse>> Handle(CreatePurchaseRequestRequest request, CancellationToken cancellationToken)
    {
        var buyer = await _userRepository.GetById(request.BuyerId, cancellationToken);
        if (buyer == null)
        {
            return Result.Fail("Пользователь не найден!");
        }

        var purchaseRequest = new PurchaseRequest()
        {
            ProductName = request.ProductName,
            ProductCount = request.ProductCount,
            Cost = request.Cost,
            BuyerId = buyer.Id
        };
        _purchaseRequestRepository.Add(purchaseRequest);
        await _purchaseRequestRepository.SaveChanges(cancellationToken);
        return Result.Ok(new CreatePurchaseRequestResponse());
    }
}