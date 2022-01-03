using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseProject.Core.Domain.Models
{
    public abstract class BaseModel
    {
        public decimal Id { get; set; }
        [NotMapped]
        public ValidationResult ValidationResult { get; private set; }

        public abstract bool EhValido();
    }
}
