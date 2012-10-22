
using System;
using FVTest.Models.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FVTest.Tests
{
	[TestClass]
	public class WhenValidatingADate
	{
		 
		// ReSharper disable InconsistentNaming

		private DateTime _expectedResult;

		[TestInitialize]
		public void InitTest()
		{
			_expectedResult = new DateTime(2012, 10, 25);
		}


		[TestMethod]
		public void TheDateFormatYYYYMMDDShouldBeValidWithoutDashes()
		{
			//Arrange
			const string dateString = "20121025";
			DateTime result;

			//Act
			var isValid = DateHelper.IsValidDate(dateString, out result);

			//Assert
			Assert.AreEqual(true, isValid);
			Assert.AreEqual(_expectedResult, result);
		}

		[TestMethod]
		public void TheDateFormatYYYYMMDDShouldBeValidWithDashes()
		{
			//Arrange
			const string dateString = "2012-10-25";
			DateTime result;

			//Act
			var isValid = DateHelper.IsValidDate(dateString, out result);

			//Assert
			Assert.AreEqual(true, isValid);
			Assert.AreEqual(_expectedResult, result);
		}

		[TestMethod]
		public void TheDateFormatYYMMDDShouldBeValidWithoutDashes()
		{
			//Arrange
			const string dateString = "121025";
			DateTime result;

			//Act
			var isValid = DateHelper.IsValidDate(dateString, out result);

			//Assert
			Assert.AreEqual(true, isValid);
			Assert.AreEqual(_expectedResult, result);
		}

		[TestMethod]
		public void TheDateFormatYYMMDDShouldBeValidWithDashes()
		{
			//Arrange
			const string dateString = "12-10-25";
			DateTime result;

			//Act
			var isValid = DateHelper.IsValidDate(dateString, out result);

			//Assert
			Assert.AreEqual(true, isValid);
			Assert.AreEqual(_expectedResult, result);
		}


		[TestMethod]
		public void TheDateFormatCanNotContainDots()
		{
			//Arrange
			const string dateString = "12.10.25";
			DateTime result;

			//Act
			var isValid = DateHelper.IsValidDate(dateString, out result);

			//Assert
			Assert.AreEqual(false, isValid);
		}

		[TestMethod]
		public void TheDateFormatCanNotContainSlashes()
		{
			//Arrange
			const string dateString = "12/10/25";
			DateTime result;

			//Act
			var isValid = DateHelper.IsValidDate(dateString, out result);

			//Assert
			Assert.AreEqual(false, isValid);
		}


		// ReSharper restore InconsistentNaming

	}
}