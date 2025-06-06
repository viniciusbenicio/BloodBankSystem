using BloodBankSystem.Application.Commands.Donation.CreateDonation;
using BloodBankSystem.Application.Commands.Donor.CreateDonor;
using FluentValidation;

namespace BloodBankSystem.Application.Validators
{
    public class CreateDonorValidator : AbstractValidator<CreateDonorCommand>
    {
        public CreateDonorValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Nome obrigatório")
                .MaximumLength(100).WithMessage("Tamanho máximo de 100 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-mail obrigatório")
                .EmailAddress().WithMessage("E-mail inválido");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Data de nascimento obrigatória")
                .LessThan(DateTime.Today).WithMessage("A data de nascimento deve ser no passado")
                .Must(BeAtLeast18YearsOld).WithMessage("É necessário ter pelo menos 18 anos");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Sexo obrigatório")
                .Must(g => new[] { "Masculino", "Feminino", "Outro" }.Contains(g))
                .WithMessage("Sexo inválido");

            RuleFor(x => x.Weight)
                .GreaterThan(0).WithMessage("Peso deve ser maior que zero")
                .GreaterThanOrEqualTo(50).WithMessage("Peso mínimo para doação é 50kg");

            RuleFor(x => x.BloodType)
                .NotEmpty().WithMessage("Tipo sanguíneo obrigatório")
                .Must(bt => new[] { "A", "B", "AB", "O" }.Contains(bt.ToUpper()))
                .WithMessage("Tipo sanguíneo inválido");

            RuleFor(x => x.HRFactor)
                .NotEmpty().WithMessage("Fator RH obrigatório")
                .Must(rh => rh == "+" || rh == "-")
                .WithMessage("Fator RH deve ser '+' ou '-'");

            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Rua obrigatória")
                .MaximumLength(150).WithMessage("Tamanho máximo de 150 caracteres");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Cidade obrigatória")
                .MaximumLength(100).WithMessage("Tamanho máximo de 100 caracteres");

            RuleFor(x => x.State)
                .NotEmpty().WithMessage("Estado obrigatório")
                .Length(2).WithMessage("Estado deve conter 2 caracteres (UF)");

            RuleFor(x => x.ZipCode)
                .NotEmpty().WithMessage("CEP obrigatório")
                .Matches(@"^\d{5}-?\d{3}$").WithMessage("CEP inválido (formato esperado: 00000-000)");
        }

        private bool BeAtLeast18YearsOld(DateTime birthDate)
        {
            return birthDate <= DateTime.Today.AddYears(-18);
        }
    }

}
