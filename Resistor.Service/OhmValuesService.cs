using System;
using System.Collections.Generic;
using System.Linq;

namespace Resistor.Service
{
    public class OhmValuesService : ICalculateOhmValues
    {
        /// <summary>
        /// Calculates the Ohm value of a resistor based on the band colors.
        /// </summary>
        /// <param name="bandAColor">The color of the first figure of component value band.</param>
        /// <param name="bandBColor">The color of the second significant figure band.</param>
        /// <param name="bandCColor">The color of the decimal muliplier band.</param>
        /// <param name="bandDColor">The color of the tolerance value band.</param>
        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            if (string.IsNullOrEmpty(bandAColor))
            {
                throw new ArgumentNullException(nameof(bandAColor));
            }

            if (string.IsNullOrEmpty(bandBColor))
            {
                throw new ArgumentNullException(nameof(bandBColor));
            }

            if (string.IsNullOrEmpty(bandCColor))
            {
                throw new ArgumentNullException(nameof(bandCColor));
            }

            if (string.IsNullOrEmpty(bandDColor))
            {
                bandDColor = "none";
            }

            bandAColor = bandAColor.ToLower();
            bandBColor = bandBColor.ToLower();
            bandCColor = bandCColor.ToLower();
            bandDColor = bandDColor.ToLower();

            if (!OhmValuesServiceValues.ValueColorBands.ContainsKey(bandAColor))
            {
                throw new ArgumentOutOfRangeException(nameof(bandAColor));
            }

            if (!OhmValuesServiceValues.ValueColorBands.ContainsKey(bandBColor))
            {
                throw new ArgumentOutOfRangeException(nameof(bandBColor));
            }

            if (!OhmValuesServiceValues.MultiplierColorBands.ContainsKey(bandCColor))
            {
                throw new ArgumentOutOfRangeException(nameof(bandCColor));
            }

            if (!OhmValuesServiceValues.ToleranceColorBands.ContainsKey(bandDColor))
            {
                throw new ArgumentOutOfRangeException(nameof(bandDColor));
            }

            var ohmValue = ((OhmValuesServiceValues.ValueColorBands[bandAColor] * 10) + OhmValuesServiceValues.ValueColorBands[bandBColor]) * OhmValuesServiceValues.MultiplierColorBands[bandCColor];

            return ohmValue;
        }
    }
}
