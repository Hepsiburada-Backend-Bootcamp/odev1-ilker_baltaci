using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace abc.Validations
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Please enter 'id' value!");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Please enter 'name' value!");
            RuleFor(c => c.Age).Must(d => d >= 18).WithMessage("Your age must be greater than 18 ! ");
        }
    }
}
