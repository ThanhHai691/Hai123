using System.ComponentModel.DataAnnotations;
using hai123.Repositories.Repository;

namespace hai123.Entities;

public class PurchaseOrder : IEntity 
{

    public int Id { get; set; }
    [MaxLength(255)] public string PurchaseOrderCode { get; set; } = string.Empty;

    public int UserId { get; set; }
    public User? User { get; set; }

    public List<PurchaseOrderLine> PurchaseOrderLines { get; set; } = [];
    
}

public class User
{
    public int Id { get; set; }
    [MaxLength(255)]  public string FullName { get; set; } = string.Empty;
    public int Age { get; set; }
}

public class PurchaseOrderLine
{
    public int Id { get; set; }
    public int FatherId { get; set; }
    [MaxLength(255)] public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
}