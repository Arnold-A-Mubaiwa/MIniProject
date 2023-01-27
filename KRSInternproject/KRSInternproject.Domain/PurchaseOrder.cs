﻿
namespace KRSInternproject.Domain
{
  public class PurchaseOrder
  {
    public int Number { get; set; }
    public DateTime OrderDate { get; init; }
    public Supplier supplier { get; set; }
    public DateTime EstimatedDateOfDelivery => OrderDate.AddDays(supplier.LeadTime);
    private List<Item> _items { get; set; } = new();
    public IEnumerable<Item> Items  => _items;

    public PurchaseOrder(int number, Supplier supplier, List<Item> items)
    {
      Number = number;
      _items = items;
      OrderDate = DateTime.Now;
      this.supplier = supplier;
    }
  }
}
