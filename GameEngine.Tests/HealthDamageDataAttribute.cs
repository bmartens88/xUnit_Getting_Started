using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace GameEngine.Tests
{
    public class HealthDamageDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 0, 100 };
            yield return new object[] { 1, 99 };
            yield return new object[] { 50, 50 };
            yield return new object[] { 75, 25 };
            yield return new object[] { 101, 1 };

            // Custom DataAttribute can also be used in conjunction with external data
            // i.e. reading test data from external file through usage of this attribute
        }
    }
}
