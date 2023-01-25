using KRSInternproject.ApplicationService;
using KRSInternproject.Domain;
using System.ComponentModel.DataAnnotations;

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
    public async Task ShouldAddGood()
    {
      // Given a good code and name
      var good = new Good("ABCDE", "Alphabet");
      // When adding a good
      var addGood = await goodApplicationService.AddGood(good);
      // Then the Good should be created
      Assert.True(addGood);
    }

    [Fact]
    public async Task ShouldFindGood()
    {
      // Given a code 
      var code = "BED12";
      // When finding the Good by code us AS
      var findGood = await goodApplicationService.FindGood(code);
      // The good should be returned
      Assert.Equal(code, findGood.code);
    }

    [Fact]
    public async Task ShouldNotFindGood()
    {
      // Given a code 
      var code = "BED13";
      // When finding the Good by code us AS
      var findGood = await goodApplicationService.FindGood(code);
      // The good shouldn't be returned
      Assert.Null(findGood);
    }

    [Fact]
    public async Task ShouldEditGood()
    {
      // Given a code  and new name
      var code = "BED12";
      var name = "New Name";
      // When editing the good by code
      var newGood = await goodApplicationService.EditGood(code, name);
      // Then the good should be edited
      Assert.True(newGood);
      var findGood = await goodApplicationService.FindGood(code);
      // The good should be returned
      Assert.Equal(name, findGood.name);
    }

    [Fact] 
    public async Task SShouldDeleteGood()
    {
      // Given the existing code of the good to be deleted
      var code = "BED12";
      // When deleting the good
      var deleteGood = await goodApplicationService.DeleteGood(code);
      // the good should be deleted
      Assert.True(deleteGood);
      var findGood = await goodApplicationService.FindGood(code);
      Assert.Null(findGood);

    }
  }
}