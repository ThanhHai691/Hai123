using ConnectDatabaseAndSimpleApi.Controllers;
using ConnectDatabaseAndSimpleApi.Dto;
using hai123.Entities;
using hai123.Extensions;
using hai123.Repositories.Purchaseorder;
using hai123.Repositories.Repository;

namespace hai123.Services.PurchaseOrder;

public class PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository, IUnitOfWork unitOfWork)
    : IPurchaseOrderService
{
    public async Task<ConnectDatabaseAndSimpleApi.Entites.PurchaseOrder> CreateAsync(CreatePurchaseOrder purchaseOrder)
    {
        var newItem = new ConnectDatabaseAndSimpleApi.Entites.PurchaseOrder
        {
            PurchaseOrderCode = purchaseOrder.PurchaseOrderCode,
            UserId            = purchaseOrder.UserId,
            PurchaseOrderLines = purchaseOrder.PurchaseOrderLines.Select(x => new PurchaseOrderLine
            {
                ProductName = x.ProductName,
                Price       = x.Price,
                Quantity    = x.Quantity
            }).ToList()
        };
        var result = purchaseOrderRepository.Add(newItem);
        await unitOfWork.SaveChangesAsync();
        return newItem;
    }

    public async Task<ConnectDatabaseAndSimpleApi.Entites.PurchaseOrder> UpdateAsync(int id, UpdatePurchaseOrder purchaseOrder)
    {
        var result = await purchaseOrderRepository.FindByIdAsync(id);
        if (result is null) throw new Exception("KHông tìm thấy đơn hàng");
        result.PurchaseOrderCode = purchaseOrder.PurchaseOrderCode;
        result.UserId            = purchaseOrder.UserId;
        purchaseOrderRepository.Update(result);
        await unitOfWork.SaveChangesAsync();

        return result;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var findPurchaseOrder = await purchaseOrderRepository.FindByIdAsync(id);
        if (findPurchaseOrder is null) throw new Exception("Không tìm thấy đơn hàng");
        var afterDelete = purchaseOrderRepository.Delete(findPurchaseOrder);
        await unitOfWork.SaveChangesAsync();
        return afterDelete;
    }

    public async Task<ConnectDatabaseAndSimpleApi.Entites.PurchaseOrder> GetByIdAsync(int id)
    {
        var result = await purchaseOrderRepository.FindByIdAsync(id);

        if (result is null) throw new Exception("Không tìm they đơn hàng");
        return result;
    }

    public async Task<Pagination> GetAllAsync(ParamQuery paramQuery)
    {
        var result = await purchaseOrderRepository.GetAllAsync(paramQuery);
        return result;
    }
}