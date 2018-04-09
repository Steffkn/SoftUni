namespace P07.HackTests.Math
{
    using System;
    using NUnit.Framework;
    using System.Collections;

    [TestFixture]
    public class AbsTests
    {
        public static IEnumerable TestListsOfInts
        {
            get
            {
                yield return new TestCaseData(0M, 0M);
                yield return new TestCaseData(-10M, 10M);
                yield return new TestCaseData(10.0M, 10.0M);
                yield return new TestCaseData(decimal.MinValue, decimal.MaxValue);
                yield return new TestCaseData(decimal.MaxValue, decimal.MaxValue);
            }
        }

        [TestCaseSource(nameof(TestListsOfInts))]
        public void AbsTestsWithValues(decimal input, decimal expected)
        {
            // Mocking statick objects?
            Assert.That(Math.Abs(input), Is.EqualTo(expected));
        }
    }
}
