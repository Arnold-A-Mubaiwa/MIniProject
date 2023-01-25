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
      if (!await ValidateGood(good)||await CheckDuplicate(good)) return false;
        
      goods.Add(good);
      return true;
    }

    public async Task<bool> ValidateGood(Good good)
    {
      var valid = _validate.Validate(good);
      return valid.IsValid;
    }
    public async Task<Good> FindGood(string code)
    {
      var good = goods.FirstOrDefault(c => c.code == code);
      return good;
    }
    public async Task<bool> EditGood(string code, string name)
    {
      var newgood = new Good(code, name);
      var good = await FindGood(code);
      if (good == null) return false;

      goods =  goods.Select(g => g.code == code? newgood:g).ToList();
      return true;
    }
    public async Task<bool> DeleteGood(string code)
    {
      var good = await FindGood(code);
      if (good == null) return false;

      goods.RemoveAll(e=> e.code == code);
      return true;
    }

    public async Task<bool> CheckDuplicate(Good good)
    {
      var found = await FindGood(good.code);
      if (found == null) return false;
      return true;
    }
    
  }
}