using KRSInternproject.Domain;

namespace KRSInternproject.ApplicationService
{
  public class GoodApplicationService
  {
    private readonly GoodValidator _validate = new();
    List<Good> goods= new List<Good>();
    public bool AddGood(Good good)
    {
      if (!ValidateGood(good)) return false;
        
      goods.Add(good);
      return true;
    }

    public bool ValidateGood(Good good)
    {
      var valid = _validate.Validate(good);
      return valid.IsValid;
    }
  }
}