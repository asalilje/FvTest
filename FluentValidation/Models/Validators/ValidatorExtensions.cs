using System;
using FluentValidation;
using FluentValidation.Validators;

namespace FVTest.Models.Validators
{
	public static class ValidatorExtensions
	{
		public static IRuleBuilderOptions<T, string> MustBeValidDate<T>(this IRuleBuilder<T, string> ruleBuilder)
		{
			return ruleBuilder.SetValidator(new StringIsValidDate());
		}
	}


	public class StringIsValidDate : PropertyValidator
	{

		public StringIsValidDate()
			: base("Datumfältet {PropertyName} är inget giltigt datum!")
		{

		}

		protected override bool IsValid(PropertyValidatorContext context)
		{
			DateTime result;
			var isValid = DateHelper.IsValidDate(context.PropertyValue.ToString(), out result);
			return isValid;
		}

	}
}