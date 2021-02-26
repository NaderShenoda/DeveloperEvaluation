using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Resistor.Service.Tests
{
    [TestClass]
    public class CalculateOhmStaticValuesTest
    { 
        [TestMethod]
        [DataRow("black", 0)] 
        [DataRow("brown", 1)]  
        [DataRow("red", 2)]
        [DataRow("orange", 3)]  
        [DataRow("yellow", 4)] 
        [DataRow("green", 5)]
        [DataRow("blue", 6)]
        [DataRow("violet", 7)]
        [DataRow("grey", 8)]
        [DataRow("white", 9)]
        public void OhmValuesServiceValues_ValueColorBands_Expected_Values(string bandColor, int expectedValue)
        {
            Assert.IsTrue(OhmValuesServiceValues.ValueColorBands.ContainsKey(bandColor));
            Assert.AreEqual(expectedValue, OhmValuesServiceValues.ValueColorBands[bandColor]);
        }

        [TestMethod]
        [DataRow("black", 1)] 
        [DataRow("brown", 10)]  
        [DataRow("red", 100)]
        [DataRow("orange", 1000)]  
        [DataRow("yellow", 10000)] 
        [DataRow("green", 100000)]
        [DataRow("blue", 1000000)]
        [DataRow("violet", 10000000)]
        public void OhmValuesServiceValues_MultiplierColorBands_Expected_Values(string bandColor, int expectedValue)
        {
            Assert.IsTrue(OhmValuesServiceValues.MultiplierColorBands.ContainsKey(bandColor));
            Assert.AreEqual(expectedValue, OhmValuesServiceValues.MultiplierColorBands[bandColor]);
        }

        [TestMethod]
        [DataRow("brown", .01D)]  
        [DataRow("red", .02D)]
        [DataRow("green", .005D)]
        [DataRow("blue", .0025D)]
        [DataRow("violet", .0001D)]
        [DataRow("gold", .05D)]
        [DataRow("silver", .1D)]
        [DataRow("none", .2D)]
        public void OhmValuesServiceValues_ToleranceColorBands_Expected_Values(string bandColor, double expectedValue)
        {
            Assert.IsTrue(OhmValuesServiceValues.ToleranceColorBands.ContainsKey(bandColor));
            Assert.AreEqual(expectedValue, OhmValuesServiceValues.ToleranceColorBands[bandColor]);
        }
    }
}
