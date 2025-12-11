namespace hai123.Services.PurchaseOrder;

public class IPurchaseOrderServices
{
    Task<Entities.PurchaseOrder> CreateAsync(CreatePurchaseOrder purchaseOrder);
    Task<Entities.PurchaseOrder> UpdateAsync(int id, UpdatePurchaseOrder purchaseOrder);
    Task<bool>                  DeleteAsync(int id);
    Task<Entities.PurchaseOrder> GetByIdAsync(int id);
    Task<Pagination>            GetAllAsync(ParamQuery paramQuery);
}