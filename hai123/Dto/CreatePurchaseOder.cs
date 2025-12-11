using System.ComponentModel.DataAnnotations;

namespace ConnectDatabaseAndSimpleApi.Dto;

public class CreatePurchaseOrder
{
    [MaxLength(255)] public string PurchaseOrderCode { get; set; } = string.Empty;

    public int UserId { get; set; }
    public List<CreatePurchaseOrderLine> PurchaseOrderLines { get; set; } = [];
}

public class CreatePurchaseOrderLine
{
    [MaxLength(255)] public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
}