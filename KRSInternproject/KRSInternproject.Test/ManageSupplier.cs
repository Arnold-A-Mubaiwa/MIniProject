using KRSInternproject.Domain;

namespace KRSInternproject.Test
{
  public class ManageSupplier
  {
    [Fact]
    public void ShouldCreateSupplier()
    {
      // Give a new Supplier
      // When craeting the new Supplier
      var supplier = new Supplier("ARNO1", "Arnold", 2);
      // Then the new supplier should be created
      Assert.NotNull(supplier);
    }
  }
}
