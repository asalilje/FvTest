using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FluentValidation;
using FluentValidation.Validators;

namespace FVTest.Models.Validators
{
	public class DeviationValidator : AbstractValidator<Deviation>
	{
		private IEnumerable<string> _validUsers = new [] {"åsa", "dan", "pablo", "daniel", "carina"};

		public DeviationValidator()
		{

			RuleFor(deviation => deviation.User)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotEmpty().WithMessage("Namn måste anges")
				.Must(user => _validUsers.Any(validuser => string.Equals(user, validuser, StringComparison.OrdinalIgnoreCase))).WithMessage("Användaren finns ej");


			RuleFor(deviation => deviation.PeriodFromDate)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotEmpty().WithMessage("Fråndatum måste anges")
				.MustBeValidDate();


			RuleFor(deviation => deviation.PeriodToDate)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotEmpty().WithMessage("Tilldatum måste anges")
				.MustBeValidDate()
				.GreaterThanOrEqualTo(deviation => deviation.PeriodFromDate).WithMessage("Tilldatum måste vara samma eller senare än {0}", deviation => deviation.PeriodFromDate);


			When(deviation => string.IsNullOrEmpty(deviation.Enter2), () => 
				RuleFor(deviation => deviation.Enter1)
				.NotEmpty()
				.WithMessage("Här måste du skriva något om du inte skrivit något nedanför"));


			When(deviation => string.IsNullOrEmpty(deviation.Enter1), () =>
				RuleFor(deviation => deviation.Enter2)
				.NotEmpty()
				.WithMessage("Här måste du skriva något om du inte skrivit något ovanför"));

			
		}
		 
	}

}