using KRSInternproject.Domain;

namespace KRSInternproject.Test
{
  public class ManageGood
  {
    private readonly GoodValidator _validator = new();
    [Fact]
    public void ShouldCreateAGood()
    {
      // Given a code and name
      var code = "ABCDE";
      var name = "Arnold";
      // When creating a good
      var good = new Good(code, name);
      // Then the Good should be created
      Assert.NotNull(good);
    }
    [Fact]
    public void ShouldValidateGood()
    {
      // Given a good 

      // When validating the good 

      // Then the Good should validate
    }
    

  }
}