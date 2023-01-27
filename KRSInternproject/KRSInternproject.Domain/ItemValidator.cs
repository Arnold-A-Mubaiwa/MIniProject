using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KRSInternproject.Domain
{
  public class ItemValidator: AbstractValidator<Item>
  {
    public ItemValidator()
    {
      RuleFor(i => i.Price).NotEmpty().GreaterThan(0);
      RuleFor(i => i.Quantity).NotEmpty().GreaterThan(0);
      RuleFor(i => i.good).NotEmpty();
    }
  }
}
