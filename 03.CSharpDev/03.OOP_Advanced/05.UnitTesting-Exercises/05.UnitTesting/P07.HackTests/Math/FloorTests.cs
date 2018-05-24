namespace P07.HackTests.Math
{
    using System;
    using NUnit.Framework;
    using System.Collections;
    using Moq;

    [TestFixture]
    class FloorTests
    {
        public static IEnumerable TestListsOfDecimals
        {
            get
            {
                yield return new TestCaseData(0M, 0M);
                yield return new TestCaseData(-10.1M, -11M);
                yield return new TestCaseData(9.9M, 9M);
                yield return new TestCaseData(9.1M, 9M);
                yield return new TestCaseData(9.01M, 9M);
                yield return new TestCaseData(9.001M, 9M);
                yield return new TestCaseData(decimal.MaxValue, decimal.MaxValue);
            }
        }

        [TestCaseSource(nameof(TestListsOfDecimals))]
        public void AbsTestsWithValues(decimal input, decimal expected)
        {
            // Mocking statick objects?
            Assert.That(Math.Floor(input), Is.EqualTo(expected));
        }
    }
}
