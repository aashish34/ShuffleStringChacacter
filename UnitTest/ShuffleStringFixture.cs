using NUnit.Framework;
using RandomStringGenerator;
using System.Collections.Generic;

namespace UnitTest
{   

    public class ShuffleStringFixture
    {

        public enum SolutionType
        {
            Simple,
            Random,
            ThreadSafe,
            Winter
        };


        public class TestCase
        {
            // Inputs
            public string Description { get; set; }

            public string Request { get; set; }

            public SolutionType SolutionType { get; set; }
            // Outputs
            public bool Success { get; set; }
            public string GeneratedRandomString { get; set; }

            public override string ToString()
            {
                return Description;
            }
        }

        public static IEnumerable<TestCase> GetTestCases()
        {
            // Sunny day scenarios
            yield return new TestCase
            {
                Description = "Simple one liner solution",
                Request = "Hello world",
                SolutionType= SolutionType.Simple,
                Success = true
            };
            yield return new TestCase
            {
                Description = "Using random number generator",
                Request = "Hello world",
                SolutionType = SolutionType.Random,
                Success = true
            };
            
            yield return new TestCase
            {
                Description = "Thread safe with Fishre yates algoritam",
                Request = "Hello world",
                SolutionType = SolutionType.ThreadSafe,
                Success = true
            };
        }

        [TestCaseSource(nameof(GetTestCases))]
        public void TestShuffleString(TestCase testCase)
        {
            var shuffleString = new ShuffleString();
            var response = new RandomStringResponse();
            if (testCase.SolutionType == SolutionType.Simple)
            {
                response = shuffleString.OneLinerSimpleSolution(testCase.Request);
            }
            else if (testCase.SolutionType == SolutionType.Random)
            {
                response = shuffleString.UsingRandomSolution(testCase.Request);
            }
            else if (testCase.SolutionType == SolutionType.ThreadSafe)
            {
                response = shuffleString.ThreadSafeUsingFisherYatesSolution(testCase.Request);
            }

            Assert.AreEqual(response.Success, testCase.Success);
            Assert.AreNotEqual(response.GeneratedRandomString, testCase.Request);
        }
    }
}
