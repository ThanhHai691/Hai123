
using hai123.Data;
using hai123.Extensions;
using Microsoft.EntityFrameworkCore;

namespace hai123.Repositories.Purchaseorder;

public class PurchaseOrderRepository
    : Repository<Entities.PurchaseOrder>,IPurchaseOrderRepository

{

   public async Task<Pagination> GetAllAsync(ParamQuery paramQuery)
   {
       var query = _context.PurchaseOrders.AsQueryable();
       if (!string.IsNullOrEmpty(paramQuery.Search))
       {
           query = query.Where(x => x.PurchaseOrderCode.Contains(paramQuery.Search));
       }

       var countAsync = await query.CountAsync();
       List<object> result = [await query
           .Skip((paramQuery.Page - 1) * paramQuery.PageSize)
           .Take(paramQuery.PageSize)
           .ToListAsync()];

       return new Pagination
       {
           Data = result,
           Page = paramQuery.Page,
           PageSize = paramQuery.PageSize,
           Total = countAsync
       };
   }
}



