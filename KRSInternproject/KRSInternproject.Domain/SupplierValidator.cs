
using FluentValidation;

namespace KRSInternproject.Domain
{
  public class SupplierValidator: AbstractValidator<Supplier>
  {
    public SupplierValidator()
    {
      RuleFor(s => s.Code).NotEmpty().MinimumLength(5).MaximumLength(5);
      RuleFor(s => s.Name).NotEmpty();
      RuleFor(s => s.LeadTime).NotEmpty().GreaterThan(0);
    }
  }
}
