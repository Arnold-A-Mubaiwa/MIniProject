using KRSInternproject.Domain;

namespace KRSInternproject.ApplicationService
{
  public class SupplierApplicationService
  {

    private List<Supplier> _suppliers  = new List<Supplier>()
    {
      new Supplier("ARNO1", "Arnold", 1),
    };
    public async Task<bool> AddSupplier(Supplier supplier)
    {
      if ( await FindSupplier(supplier.Code)!=null) return false;
      _suppliers.Add(supplier);
      return true;
    }

    public async Task<Supplier> FindSupplier(string code)
    {
      return _suppliers.FirstOrDefault(s => s.Code == code)!;
    }


  }
}
