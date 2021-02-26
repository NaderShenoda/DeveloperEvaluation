using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Resistor.Service.Tests
{
    [TestClass]
    public class CalculateOhmValuesTest
    { 
        private readonly ICalculateOhmValues OhmValuesCalculator = new OhmValuesService();

        [TestMethod]
        [ArgumentExceptionAttribute(typeof(ArgumentNullException), "bandAColor")]
        [DataRow("")]
        [DataRow(null)]
        public void ICalculateOhmValues_CalculateOhmValue_Missing_Band_A_Color_Throws_Exception(string bandAColor)
        {
            OhmValuesCalculator.CalculateOhmValue(bandAColor, OhmValuesServiceValues.ValueColorBands.Keys.First(), OhmValuesServiceValues.MultiplierColorBands.Keys.First(), OhmValuesServiceValues.ToleranceColorBands.Keys.First());
        }

        [TestMethod]
        [ArgumentExceptionAttribute(typeof(ArgumentNullException), "bandBColor")]
        [DataRow("")]
        [DataRow(null)]
        public void ICalculateOhmValues_CalculateOhmValue_Missing_Band_B_Color_Throws_Exception(string bandBColor)
        {
            OhmValuesCalculator.CalculateOhmValue(OhmValuesServiceValues.ValueColorBands.Keys.First(), bandBColor, OhmValuesServiceValues.MultiplierColorBands.Keys.First(), OhmValuesServiceValues.ToleranceColorBands.Keys.First());
        }

        [TestMethod]
        [ArgumentExceptionAttribute(typeof(ArgumentNullException), "bandCColor")]
        [DataRow("")]
        [DataRow(null)]
        public void ICalculateOhmValues_CalculateOhmValue_Missing_Band_C_Color_Throws_Exception(string bandCColor)
        {
            OhmValuesCalculator.CalculateOhmValue(OhmValuesServiceValues.ValueColorBands.Keys.First(), OhmValuesServiceValues.ValueColorBands.Keys.First(), bandCColor, OhmValuesServiceValues.ToleranceColorBands.Keys.First());
        }

        [TestMethod]
        [ArgumentExceptionAttribute(typeof(ArgumentOutOfRangeException), "bandAColor")]
        [DataRow("INVALID")]
        [DataRow("\t")]
        [DataRow(" ")]
        public void ICalculateOhmValues_CalculateOhmValue_Invalid_Band_A_Color_Throws_Exception(string bandAColor)
        {
            Assert.IsFalse(OhmValuesServiceValues.ValueColorBands.ContainsKey(bandAColor), "Test invalidated; testing for invalid band a vaue that is now valid.");
            OhmValuesCalculator.CalculateOhmValue(bandAColor, OhmValuesServiceValues.ValueColorBands.Keys.First(), OhmValuesServiceValues.MultiplierColorBands.Keys.First(), OhmValuesServiceValues.ToleranceColorBands.Keys.First());
        }

        [TestMethod]
        [ArgumentExceptionAttribute(typeof(ArgumentOutOfRangeException), "bandBColor")]
        [DataRow("INVALID")]
        [DataRow("\t")]
        [DataRow(" ")]
        public void ICalculateOhmValues_CalculateOhmValue_Invalid_Band_B_Color_Throws_Exception(string bandBColor)
        {
            Assert.IsFalse(OhmValuesServiceValues.ValueColorBands.ContainsKey(bandBColor), "Test invalidated; testing for invalid band b vaue that is now valid.");
            OhmValuesCalculator.CalculateOhmValue(OhmValuesServiceValues.ValueColorBands.Keys.First(), bandBColor, OhmValuesServiceValues.MultiplierColorBands.Keys.First(), OhmValuesServiceValues.ToleranceColorBands.Keys.First());
        }

        [TestMethod]
        [ArgumentExceptionAttribute(typeof(ArgumentOutOfRangeException), "bandCColor")]
        [DataRow("INVALID")]
        [DataRow("\t")]
        [DataRow(" ")]
        public void ICalculateOhmValues_CalculateOhmValue_Invalid_Band_C_Color_Throws_Exception(string bandCColor)
        {
            Assert.IsFalse(OhmValuesServiceValues.MultiplierColorBands.ContainsKey(bandCColor), "Test invalidated; testing for invalid band c vaue that is now valid.");
            OhmValuesCalculator.CalculateOhmValue(OhmValuesServiceValues.ValueColorBands.Keys.First(), OhmValuesServiceValues.ValueColorBands.Keys.First(), bandCColor, OhmValuesServiceValues.ToleranceColorBands.Keys.First());
        }

        [TestMethod]
        [ArgumentExceptionAttribute(typeof(ArgumentOutOfRangeException), "bandDColor")]
        [DataRow("INVALID")]
        [DataRow("\t")]
        [DataRow(" ")]
        public void ICalculateOhmValues_CalculateOhmValue_Invalid_Band_D_Color_Throws_Exception(string bandDColor)
        {
            Assert.IsFalse(OhmValuesServiceValues.ToleranceColorBands.ContainsKey(bandDColor), "Test invalidated; testing for invalid band d vaue that is now valid.");
            OhmValuesCalculator.CalculateOhmValue(OhmValuesServiceValues.ValueColorBands.Keys.First(), OhmValuesServiceValues.ValueColorBands.Keys.First(), OhmValuesServiceValues.MultiplierColorBands.Keys.First(), bandDColor);
        }

        [TestMethod]
        [DataRow("black", "black", "black", "green", 0)] 
        [DataRow("orange", "brown", "red", null, 3100)] // value chosen to ensure no mixup in value positions in calculation
        [DataRow("rEd", "Red", "Brown", "nOnE", 220)] // is not case sensitive
        public void ICalculateOhmValues_CalculateOhmValue_Calculates_As_Expected(string bandAColor, string bandBColor, string bandCColor, string bandDColor, int expectedResult)
        {
            Assert.IsTrue(OhmValuesServiceValues.ValueColorBands.ContainsKey(bandAColor.ToLower()), "Test invalidated; testing for valid band a vaue that is now invalid.");
            Assert.IsTrue(OhmValuesServiceValues.ValueColorBands.ContainsKey(bandBColor.ToLower()), "Test invalidated; testing for valid band b vaue that is now invalid.");
            Assert.IsTrue(OhmValuesServiceValues.MultiplierColorBands.ContainsKey(bandCColor.ToLower()), "Test invalidated; testing for valid band c vaue that is now invalid.");
            if (!string.IsNullOrEmpty(bandDColor))
            {
                Assert.IsTrue(OhmValuesServiceValues.ToleranceColorBands.ContainsKey(bandDColor.ToLower()), "Test invalidated; testing for valid band d vaue that is now invalid.");
            }
            var result = OhmValuesCalculator.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);
            Assert.AreEqual(expectedResult, result, "Calculation returned unexpected result.");
        }
    }
}
