using API.Models;
using FluentValidation;

namespace API.Validators
{
    public class HotelValidator : AbstractValidator<Hotel>
    {
        public HotelValidator()
        {
            RuleFor(h => h.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(h => h.Location)
                .NotEmpty().WithMessage("Location is required.")
                .MaximumLength(200).WithMessage("Location cannot exceed 200 characters.");

            RuleFor(h => h.Rating)
                .InclusiveBetween(0, 5).WithMessage("Rating must be between 0 and 5.");

            RuleFor(h => h.PhoneNo)
                .MaximumLength(15).WithMessage("Phone number cannot exceed 15 characters.");

            RuleFor(h => h.Email)
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.");

            RuleFor(h => h.CreatedBy)
                .MaximumLength(50).WithMessage("CreatedBy cannot exceed 50 characters.");

            RuleFor(h => h.UpdatedBy)
                .MaximumLength(50).WithMessage("UpdatedBy cannot exceed 50 characters.");
        }
    }
}
