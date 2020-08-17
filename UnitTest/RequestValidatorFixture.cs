using System.Collections.Generic;
using NUnit.Framework;
using RandomStringGenerator;

namespace UnitTest
{
    public class RequestValidatorFixture
    {
        public class TestCase
        {
            // Inputs
            public string Description { get; set; }

            public string OriginalString { get; set; }

            // Outputs
            public bool Success { get; set; }
            public int ErrorCode { get; set; }

            public override string ToString()
            {
                return Description;
            }
        }

        public static IEnumerable<TestCase> GetTestCases()
        {
            // Rainy day scenarios
            yield return new TestCase
            {
                Description = "Given the string is empty",
                ErrorCode = (int)Fault.ErrorCode.StringEmpty,
                OriginalString = "",                
                Success = false
            };
            yield return new TestCase
            {
                Description = "Given the string has same characters",
                ErrorCode = (int)Fault.ErrorCode.StringHasSameLetter,
                OriginalString = "aaaa",
                Success = false
            };

            // Sunny day scenarios
            yield return new TestCase
            {
                Description = "Given string is valid",
                OriginalString = "Hello world",
                Success = true
            };
         
        }

        [TestCaseSource(nameof(GetTestCases))]
        public void TestRequestValidator(TestCase testCase)
        {
            var requestValidator = new RequestValidator();
            var response = requestValidator.Validate(testCase.OriginalString);

            Assert.AreEqual(response.Success, testCase.Success);

            if (!response.Success)
            {
                Assert.AreEqual(response.Fault.Code, testCase.ErrorCode);
            }
        }
    }
}
