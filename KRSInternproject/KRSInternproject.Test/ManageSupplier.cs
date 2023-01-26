using KRSInternproject.ApplicationService;
using KRSInternproject.Domain;

namespace KRSInternproject.Test
{
  public class ManageSupplier
  {
    private readonly SupplierValidator _validate = new();
    private readonly SupplierApplicationService _supplierApplicationService = new();
    
    [Fact]
    public void ShouldCreateSupplier()
    {
      // Give a new Supplier
      // When craeting the new Supplier
      var supplier = new Supplier("ARNO1", "Arnold", 2);
      // Then the new supplier should be created
      Assert.NotNull(supplier);
    }

    [Fact]
    public void ShouldValidateSupplier()
    {
      // Given a supplier
      var supplier = new Supplier("ARNOl", "Arnold", 2);
      // When validating the supplier
      var validate = _validate.Validate(supplier);
      // Then the supplier should be valid
      Assert.True(validate.IsValid);
    }

    [Fact]
    public void ShouldNotValidateInvalidSupplier()
    {
      // Given an invalid supplier.. Invalid code
      var supplier = new Supplier("ARNO", "Arnold", 2);
      // When validating the supplier
      var validate = _validate.Validate(supplier);
      //Then the supplier shouldn't be validated
      Assert.False(validate.IsValid);
    }

    [Fact]
    public async Task ShouldAddSupplier()
    {
      // Given a new SSupplier 
      var supplier = new Supplier("ARNOq", "Arnold", 2);
      // When adding the new supplier
      var findSupplier = await _supplierApplicationService.FindSupplier(supplier.Code);
      Assert.Null(findSupplier);
      var addNewSupplier = await _supplierApplicationService.AddSupplier(supplier);
      // Then the supplier should be added
      Assert.True(addNewSupplier);
      var findSupplierAfterAdding = await _supplierApplicationService.FindSupplier(supplier.Code);
      Assert.NotNull(findSupplierAfterAdding);
    }

    [Fact]
    public async Task ShouldFindSupplier()
    {
      // Given a supplier code
      var code = "ARNO1";
      // When finding a supplier with a code
      var findSupplier = await _supplierApplicationService.FindSupplier(code);
      // Then should find the supplier
      Assert.NotNull(findSupplier);
      Assert.Equal(code, findSupplier.Code);
    }

    [Fact]
    public async Task ShouldNotFindInvalidSupplier()
    {
      // Given an invalid code
      var code = "ARNO";
      // When finding a supplier with a code
      var findSupplier = await _supplierApplicationService.FindSupplier(code);
      // Then the supplier shouldn't be founf
      Assert.Null(findSupplier);
    }
  }
}
