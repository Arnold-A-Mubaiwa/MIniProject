using KRSInternproject.Domain;

namespace KRSInternproject.ApplicationService
{
  public class SupplierApplicationService
  {

    private readonly SupplierValidator _validator = new();
    private List<Supplier> _suppliers  = new List<Supplier>()
    {
      new Supplier("ARNO1", "Arnold", 1),
      new Supplier("ARNO2", "Anotida Mubaiwa", 2),
  };
    public async Task<bool> AddSupplier(Supplier supplier)
    {
      if ( await CheckDuplicate(supplier) || !validateSupplier(supplier)) return false;
      _suppliers.Add(supplier);
      return true;
    }

    public async Task<Supplier> FindSupplier(string code)
    {
      return _suppliers.FirstOrDefault(s => s.Code == code)!;
    }

    public bool validateSupplier(Supplier supplier)
    {
      var validate = _validator.Validate(supplier);
      return (validate.IsValid)? true: false;
    }
    public async Task<bool> EditSupplier(Supplier supplier)
    {
      var findSupplier = await FindSupplier(supplier.Code);
      if (findSupplier == null || !validateSupplier(supplier)) return false;
      
      _suppliers = _suppliers.Select(s => s.Code == findSupplier.Code ? supplier : s).ToList();
      return true;
    }

    public async Task<bool> DeleteSupplier(Supplier  supplier)
    {
      if (await FindSupplier(supplier.Code) == null) return false;

      _suppliers.Remove(supplier);
      return true;
    }
    public async Task<bool> CheckDuplicate(Supplier supplier)
    {
      if (await FindSupplier(supplier.Code) == null) return false;
      return true;
    }
  }
}
