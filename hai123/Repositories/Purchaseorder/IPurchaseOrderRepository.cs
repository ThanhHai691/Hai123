using hai123.Entities;
using hai123.Extensions;
using hai123.Repositories.Repository;


namespace hai123.Repositories.Purchaseorder;

public interface IPurchaseOrderRepository : IRepository<PurchaseOrder>
{
    public Task<Pagination> GetAllAsync(ParamQuery paramQuery);
}



