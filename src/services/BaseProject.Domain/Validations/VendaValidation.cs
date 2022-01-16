using BaseProject.Domain.Models;
using FluentValidation;
using System.Linq;

namespace BaseProject.Domain.Validations
{
    public class VendaValidation : AbstractValidator<Venda>
    {
        public VendaValidation()
        {
            RuleFor(v => v.ClienteId)
                .NotEmpty().WithMessage("Cliente deve ser informado na venda");

            RuleFor(v => v.VendaItens)
                .Must(vi => vi.Count() == 0)
                .WithMessage("Venda deve ter ao menos um item");

        }
    }
}
