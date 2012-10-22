using System;
using FVTest.Models.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentValidation;
using FluentValidation.TestHelper;

namespace FVTest.Tests
{
	[TestClass]
	public class WhenValidatingADeviation
	{

		private DeviationValidator _validator;

		[TestInitialize]
		public void InitTest()
		{
			_validator = new DeviationValidator();
		}

		[TestMethod]
		public void ShouldGetErrorWhenUserIsEmpty()
		{
			//Act, Assert
			_validator.ShouldHaveValidationErrorFor(deviation => deviation.User, null as string);
		}

		[TestMethod]
		public void ShouldNotGetErrorWhenUserIsNotEmpty()
		{
			//Act, Assert
			_validator.ShouldNotHaveValidationErrorFor(deviation => deviation.User, "åsa");
		}

		[TestMethod]
		public void ShouldGetErrorWhenDateIsEmpty()
		{
			//Act, Assert
			_validator.ShouldHaveValidationErrorFor(deviation => deviation.PeriodFromDate, null as string);
		}

		[TestMethod]
		public void ShouldNotGetErrorWhenDateIsNotEmptyAndValid()
		{
			//Act, Assert
			_validator.ShouldNotHaveValidationErrorFor(deviation => deviation.PeriodFromDate, DateTime.Now.ToShortDateString());
		}

		[TestMethod]
		public void ShouldGetErrorWhenDateIsNotEmptyAndNotValid()
		{
			//Act, Assert
			_validator.ShouldHaveValidationErrorFor(deviation => deviation.PeriodFromDate, "2012/10/10");
		}
	}
}