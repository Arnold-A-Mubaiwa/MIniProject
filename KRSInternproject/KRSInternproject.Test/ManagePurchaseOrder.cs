
using KRSInternproject.ApplicationService;
using KRSInternproject.Domain;

namespace KRSInternproject.Test
{
  public class ManagePurchaseOrder
  {
    private readonly PurchaseOrderApplicationService _service = new();
    private readonly PurchaseOrderValidator _validator = new();
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

    [Fact]
    public async Task ShouldAddToPurchaseOrder()
    {
      // Given a new purchase order
      var supplier = new Supplier("ABCD2", "Arnold", 3);
      var good = new Good("GOOD2", "My good");
      var item = new Item(good, 2, 50.23m);
      var item2 = new Item(good, 2, 50.23m);
      var purchaseOrder = new PurchaseOrder(112, supplier, new List<Item>() { item, item2 });
      // When adding the purchase order
      var addPurchase = await _service.AddPurchaseOrder(purchaseOrder);
      var findAfterAdd = await _service.FindPurchaseOrder(purchaseOrder.Number);
      // Then the purchase order should be added
      Assert.True(addPurchase);
      Assert.Equal(purchaseOrder.Number, findAfterAdd.Number);
    }

    [Fact]
    public void ShouldValidatePurchaseOrder()
    {
      // Given a purchase order 
      var supplier = new Supplier("ABCD3", "Arnold", 3);
      var good = new Good("GOOD3", "My good");
      var item = new Item(good, 2, 50.23m);
      var item2 = new Item(good, 2, 50.23m);
      var purchaseOrder = new PurchaseOrder(113, supplier, new List<Item>() { item, item2 });
      // When validating the purchaseOrder
      var validate = _validator.Validate(purchaseOrder);
      // Then the purchase order should be validated
      Assert.True(validate.IsValid);
    }

    [Fact]
    public void ShouldNotValidateInvalidPurchaseOrder()
    {
      // Given an invalid purcahse order
      var supplier = new Supplier("ABCD", "Arnold", 3);
      var good = new Good("GOOD", "My good");
      var item = new Item(good, 2, 50.23m);
      var item2 = new Item(good, 2, 50.23m);
      var purchaseOrder = new PurchaseOrder(0, supplier, new List<Item>() { item, item2 });
      // When validating the purchaseOrder
      var validate = _validator.Validate(purchaseOrder);
      // Then the purchase order should not be validated
      Assert.False(validate.IsValid);
    }
  }
}
