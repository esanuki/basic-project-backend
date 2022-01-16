using BaseProject.Domain.Models;
using FluentValidation;

namespace BaseProject.Domain.Validations
{
    public class VendaItemValidation : AbstractValidator<VendaItem>
    {
        public VendaItemValidation()
        {
            RuleFor(vi => vi.ProdutoId)
                .NotEmpty().WithMessage("Produto deve ser informado na venda");

            RuleFor(vi => vi.Qtde)
                .GreaterThan(0).WithMessage("Quantidade deve ser maior que 0(zero)");

            RuleFor(vi => vi.ValorUnitario)
                .GreaterThan(0).WithMessage("Valor unitário deve ser maior que 0(zero)");
        }
    }
}
