﻿
using KRSInternproject.Domain;

namespace KRSInternproject.ApplicationService
{
  public class PurchaseOrderApplicationService
  {
    private readonly PurchaseOrderValidator _validate = new();
    private List<PurchaseOrder> _purchaseOrder = new List<PurchaseOrder>()
    {
      new PurchaseOrder(111, new Supplier("ABCD1", "Arnold", 3), new List<Item> (){new Item(new Good("GOOD1", "My good"), 2, 50.02m) } ),
    };

    public async Task<PurchaseOrder> FindPurchaseOrder(int number)
    {
      return _purchaseOrder.FirstOrDefault(s => s.Number == number)!;
    }

    public async Task<bool> AddPurchaseOrder(PurchaseOrder purchaseOrder)
    {
      var findOrder = await FindPurchaseOrder(purchaseOrder.Number);
      if (findOrder != null || !await ValidatePurchaseOrder(purchaseOrder)) return false;

      _purchaseOrder.Add(purchaseOrder);
      return true;
    }

    public async Task<bool> ValidatePurchaseOrder(PurchaseOrder purchaseOrder)
    {
      return _validate.Validate(purchaseOrder).IsValid;
    }
  }
}
