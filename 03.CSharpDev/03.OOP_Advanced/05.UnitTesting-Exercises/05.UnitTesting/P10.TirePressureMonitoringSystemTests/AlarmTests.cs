namespace P10.TirePressureMonitoringSystemTests
{
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Reflection;
    using TDDMicroExercises.TirePressureMonitoringSystem;

    [TestFixture]
    public class AlarmTests
    {
        [TestCase(16)]
        [TestCase(22)]
        public void Check_WithValuesThatAreOutOfRange(double preasure)
        {
            var mockedSensor = new Mock<ISensor>();
            mockedSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(preasure);
            var sensorField = typeof(Alarm).GetField("_sensor", BindingFlags.NonPublic | BindingFlags.Instance);
            var alarm = (Alarm)Activator.CreateInstance(typeof(Alarm));
            sensorField.SetValue(alarm, mockedSensor.Object);

            Assert.That(alarm.AlarmOn, Is.EqualTo(false));
            alarm.Check();
            Assert.That(alarm.AlarmOn, Is.EqualTo(true));
        }

        [TestCase(17)]
        [TestCase(21)]
        [TestCase(19)]
        public void Check_WithValuesThatAreInRange(double preasure)
        {
            var mockedSensor = new Mock<ISensor>();
            mockedSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(preasure);
            var sensorField = typeof(Alarm).GetField("_sensor", BindingFlags.NonPublic | BindingFlags.Instance);
            var alarm = (Alarm)Activator.CreateInstance(typeof(Alarm));
            sensorField.SetValue(alarm, mockedSensor.Object);

            Assert.That(alarm.AlarmOn, Is.EqualTo(false));
            alarm.Check();
            Assert.That(alarm.AlarmOn, Is.EqualTo(false));
        }
    }
}
