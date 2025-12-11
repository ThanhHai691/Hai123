using System.ComponentModel.DataAnnotations;

namespace hai123.Dto;

public class UpdatePurchaseOrder
{
    [MaxLength(255)] public string PurchaseOrderCode { get; set; } = string.Empty;

    public int UserId { get; set; }

    public List<UpdatePurchaseOrderLine> PurchaseOrderLines { get; set; } = [];
}

public abstract class UpdatePurchaseOrderLine
{
    public int? Id { get; set; }

    [MaxLength(255)] public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
}