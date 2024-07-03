using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs.Validators
{
    /// <summary>
    /// Validator for UserDto.
    /// </summary>
    public class UserDtoValidator : AbstractValidator<UserDTO>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserDtoValidator"/> class.
        /// </summary>
        public UserDtoValidator()
        {
            RuleFor(u => u.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MaximumLength(50).WithMessage("Username must not exceed 50 characters.");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.s");
        }
    }
}
