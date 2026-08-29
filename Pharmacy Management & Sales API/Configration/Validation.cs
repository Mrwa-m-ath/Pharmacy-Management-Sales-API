using FluentValidation;
using FluentValidation.AspNetCore;
using Pharmacy_Management___Sales_API.DTO.DtoUsers;
using Pharmacy_Management___Sales_API.Model;
using System.Data;

namespace Pharmacy_Management___Sales_API.Configration
{
    public class Validations : AbstractValidator<UserDtoCreatAccount>
    {
        public Validations()
        {

            RuleFor(s => s.Email).EmailAddress().NotEmpty().WithMessage("Enter Email");
        }
    }
}
