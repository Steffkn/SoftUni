namespace P09.DateTimeTests.DateTime
{
    using Moq;
    using NUnit.Framework;
    using P09.DateTimeWrapper.Interfaces;
    using System;
    using System.Collections;

    [TestFixture]
    public class AddDaysTests
    {
        public static IEnumerable TestListsOfDateTime
        {
            get
            {
                yield return new TestCaseData(
                    new DateTime(2008, 6, 16),
                    1,
                    new DateTime(2008, 6, 17)
                    );
                yield return new TestCaseData(
                    new DateTime(2008, 7, 31),
                    1,
                    new DateTime(2008, 8, 1)
                    );
                yield return new TestCaseData(
                    new DateTime(2008, 2, 28),
                    1,
                    new DateTime(2008, 2, 29)
                    );
                yield return new TestCaseData(
                    new DateTime(1900, 2, 28),
                    1,
                    new DateTime(1900, 3, 1)
                    );

                yield return new TestCaseData(
                    new DateTime(2008, 6, 17),
                    -1,
                    new DateTime(2008, 6, 16)
                    );
                yield return new TestCaseData(
                    new DateTime(2008, 8, 1),
                    -1,
                    new DateTime(2008, 7, 31)
                    );
                yield return new TestCaseData(
                    new DateTime(2008, 2, 29),
                    -1,
                    new DateTime(2008, 2, 28)
                    );
                yield return new TestCaseData(
                    new DateTime(1900, 3, 1),
                    -1,
                    new DateTime(1900, 2, 28)
                    );
            }
        }

        [TestCaseSource(nameof(TestListsOfDateTime))]
        public void AddDays_ToDateTimeNow_Tests(DateTime currentDate, double value, DateTime expectedDate)
        {
            var dt = new Mock<IDateTimeWrapper>();
            dt.Setup(d => d.Now).Returns(currentDate);

            var dateTime = dt.Object.Now;
            dateTime = dateTime.AddDays(value);
            Assert.That(dateTime, Is.EqualTo(expectedDate));
        }
    }
}
