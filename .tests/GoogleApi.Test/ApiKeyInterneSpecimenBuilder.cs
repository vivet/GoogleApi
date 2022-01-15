using AutoFixture;
using AutoFixture.Kernel;
using System;
using System.Reflection;

namespace GoogleApi.Test
{
    public class ApiKeyInterneSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (request is PropertyInfo property
                && property.Name.Equals("Key", StringComparison.Ordinal)
                && property.PropertyType == typeof(string))
            {
                var settings = (BaseTest.AppSettings)context.Resolve(typeof(BaseTest.AppSettings));
                return settings.ApiKey;
            }

            return new NoSpecimen();
        }

        public static ICustomization ToCustomization()
        {
            return new ApiKeyInterneSpecimenBuilder().ToCustomization();
        }
    }
}
