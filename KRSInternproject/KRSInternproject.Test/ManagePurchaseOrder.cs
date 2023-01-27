
using KRSInternproject.ApplicationService;
using KRSInternproject.Domain;

namespace KRSInternproject.Test
{
  public class ManagePurchaseOrder
  {
    private readonly PurchaseOrderApplicationService _service = new();
    [Fact]
     public void ShouldCreatePurchaseOrder()
    {
      // Given a purchase order
      var supplier = new Supplier("ABCD1", "Arnold", 3);
      var good = new Good("GOOD1", "My good");
      var item = new Item(good, 2, 50.23m);
      // When creating the purchase oredr in the AS
      var order = new PurchaseOrder(111, supplier, new List<Item> { item });
      // Then the purchase order should be created
      Assert.NotNull(order);
    }

    [Fact]
    public async Task ShouldFindPurchaseOrder()
    {
      // Given an existing purchase order number
      var number = 111;
      // When finding the purchase order
      var findPurchaseOrder = await _service.FindPurchaseOrder(number);
      // Then the purchase oder should be found
      Assert.NotNull(findPurchaseOrder);
      Assert.Equal(number, findPurchaseOrder.Number);
    }

  }
}
