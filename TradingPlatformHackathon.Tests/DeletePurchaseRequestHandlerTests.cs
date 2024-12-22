using Moq;
using TradingPlatformHackathon.MediatR.DeletePurchaseRequest;
using TradingPlatformHackathon.Repositories;

namespace TradingPlatformHackathon.Tests;

public class DeletePurchaseRequestHandlerTests
{
    [Fact]
    public async Task Handle_Should_Succeed_And_DeleteData_WhenPurchaseRequestExists()
    {
        // arrange - установка
        var purchaseRequestRepositoryMock = new Mock<IPurchaseRequestRepository>();
        var purchaseResponseRepositoryMock = new Mock<IPurchaseResponseRepository>();
        purchaseRequestRepositoryMock.Setup(x => x.ExistsById(3, It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);
        var sut = new DeletePurchaseRequestHandler(purchaseRequestRepositoryMock.Object,
            purchaseResponseRepositoryMock.Object);

        // act - действие
        var result = await sut.Handle(new DeletePurchaseRequestRequest(3), CancellationToken.None);

        // assert - проверка
        Assert.True(result.IsSuccess);
        purchaseRequestRepositoryMock.Verify(x => x.DeleteById(3, It.IsAny<CancellationToken>()), Times.Exactly(1));
        purchaseResponseRepositoryMock.Verify(x => x.DeleteByPurchaseRequestId(3, It.IsAny<CancellationToken>()),
            Times.Once);
    }
    
    [Fact]
    public async Task Handle_Should_Fail_WhenPurchaseRequestNotExists()
    {
        // arrange - установка
        var purchaseRequestRepositoryMock = new Mock<IPurchaseRequestRepository>();
        var purchaseResponseRepositoryMock = new Mock<IPurchaseResponseRepository>();
        purchaseRequestRepositoryMock.Setup(x => x.ExistsById(3, It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);
        var sut = new DeletePurchaseRequestHandler(purchaseRequestRepositoryMock.Object,
            purchaseResponseRepositoryMock.Object);

        // act - действие
        var result = await sut.Handle(new DeletePurchaseRequestRequest(3), CancellationToken.None);

        // assert - проверка
        Assert.False(result.IsSuccess);
        purchaseRequestRepositoryMock.Verify(x => x.DeleteById(3, It.IsAny<CancellationToken>()), Times.Never);
        purchaseResponseRepositoryMock.Verify(x => x.DeleteByPurchaseRequestId(3, It.IsAny<CancellationToken>()),
            Times.Never);
    }
}