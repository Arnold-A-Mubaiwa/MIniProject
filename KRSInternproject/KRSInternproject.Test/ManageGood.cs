using KRSInternproject.ApplicationService;
using KRSInternproject.Domain;

namespace KRSInternproject.Test
{
  public class ManageGood
  {
    private readonly GoodValidator _validator = new();
    GoodApplicationService goodApplicationService = new();
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

    [Fact]
    public void ShouldValidateAnInvalidGood()
    {
      // Given a invalid Good
      var good = new Good("DANC", "Dance Naps");
      // When validating the good
      var validGood = _validator.Validate(good);
      // Then the Good should not validate
      Assert.False(validGood.IsValid);
    }

    [Fact]
    public void ShouldAddGood()
    {
      // Given a good code and name
      var good = new Good("ABCDE", "Alphabet");
      // When adding a good
      var addGood = goodApplicationService.AddGood(good);
      // Then the Good should be created
      Assert.True(addGood);
    }

  }
}