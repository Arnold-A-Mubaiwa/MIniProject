using FluentValidation;
namespace KRSInternproject.Domain
{

  public class GoodValidator: AbstractValidator<Good>
  {
    public GoodValidator()
    {
      RuleFor(c=>c.code).NotEmpty().MinimumLength(5).MaximumLength(5);
      RuleFor(n => n.name).NotEmpty();
    }

  }
}
