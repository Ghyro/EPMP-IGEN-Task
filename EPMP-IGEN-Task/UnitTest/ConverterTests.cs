using Converter;
using NUnit.Framework;
using System;

namespace UnitTest
{
    [TestFixture]
    public class ConverterTests
    {
        [Test]
        [TestCase(90, "15:00")]
        [TestCase(1, "7:38")]
        [TestCase(7.5, "15:15")]
        [TestCase(62.5, "3:5")]
        [TestCase(4, "6:32")]
        [TestCase(60, "01:60")]
        public void Add_TheHourAndMinutes_PositiveValues (double expected, string time)
        {
            // Arrange
            TimeConvert convert = new TimeConvert();

            // Act
            var result = convert.Convert(time);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Add_TheHourAndMinutes_NegativeValues_ArgumentNullException(string time)
        {
            // Arrange
            TimeConvert convert = new TimeConvert();

            // Act
            Assert.Throws<ArgumentNullException>(() => convert.Convert(time));
        }

        [Test]
        [TestCase("-1:01")]
        [TestCase("01:-1")]
        [TestCase("25:01")]
        
        public void Add_TheHourAndMinutes_NegativeValues_ArgumentOutOfRangeException(string time)
        {
            // Arrange
            TimeConvert convert = new TimeConvert();

            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => convert.Convert(time));
        }

        [Test]
        [TestCase("-15:40")]
        [TestCase("15-40")]
        [TestCase("15.40")]
        [TestCase("5.40")]
        [TestCase("15/40")]
        public void Add_TheHourAndMinutes_NegativeValues_FormatException(string time)
        {
            // Arrange
            TimeConvert convert = new TimeConvert();

            // Act
            Assert.Throws<FormatException>(() => convert.Convert(time));
        }
    }
}
