using KRSInternproject.Domain;

namespace KRSInternproject.ApplicationService
{
  public class GoodApplicationService
  {
    private readonly GoodValidator _validate = new();
    List<Good> goods = new List<Good>()
    {
      new Good("BED12", "Bed spread"),
      new Good("PHO12", "Huawei Pro")
    };
    public async Task<bool> AddGood(Good good)
    {
      if (!await ValidateGood(good)) return false;
        
      goods.Add(good);
      return true;
    }

    public async Task<bool> ValidateGood(Good good)
    {
      var valid = _validate.Validate(good);
      return valid.IsValid;
    }
  }
}