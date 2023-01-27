using FluentValidation;

namespace KRSInternproject.Domain
{
  public class PurchaseOrderValidator: AbstractValidator<PurchaseOrder>
  {
    public PurchaseOrderValidator()
    {
      RuleFor(p => p.Number).NotEmpty().GreaterThan(0);
      RuleFor(p => p.supplier).SetValidator(new SupplierValidator());
      RuleForEach(p => p.Items).SetValidator(new ItemValidator());
      RuleFor(p => p.Items).NotEmpty();
    }
  }
}
