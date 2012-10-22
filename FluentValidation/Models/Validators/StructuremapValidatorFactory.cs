using System;
using FluentValidation;
using StructureMap;

namespace FVTest.Models.Validators
{
	public class StructuremapValidatorFactory : ValidatorFactoryBase
	{

		public override IValidator CreateInstance(Type validatorType)
		{
			return ObjectFactory.TryGetInstance(validatorType) as IValidator;
		}

	}
}