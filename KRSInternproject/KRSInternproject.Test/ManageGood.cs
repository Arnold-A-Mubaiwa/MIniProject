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
      // When creating a good
      var good = new Good("ABCDE", "Arnold");
      // Then the Good should be created
      Assert.NotNull(good);
    }
    [Fact]
    public void ShouldValidateGood()
    {
      // Given a good 
      var good = new Good("DANC1", "Dance marks");
      // When validating the good 
      var validGood = _validator.Validate(good);
      // Then the Good should validate
      Assert.True(validGood.IsValid);
    }
    

  }
}