using System;
using System.Collections.Generic;
using System.Linq;

namespace Resistor.Service
{
    public static class OhmValuesServiceValues
    {
        public static IReadOnlyDictionary<string, int> ValueColorBands { get; } = new Dictionary<string, int> 
        {
            {"black", 0}, 
            {"brown", 1},  
            {"red", 2},
            {"orange", 3},  
            {"yellow", 4}, 
            {"green", 5},
            {"blue", 6},
            {"violet", 7},
            {"grey", 8},
            {"white", 9}
        };

        public static IReadOnlyDictionary<string, int> MultiplierColorBands  { get; } = new Dictionary<string, int> 
        {
            {"black", 1}, 
            {"brown", 10},
            {"red", 100},
            {"orange", 1000},
            {"yellow", 10000},
            {"green", 100000},
            {"blue", 1000000},
            {"violet", 10000000},
            // these valid values are not compatible with the result data type
            // {"grey", 100000000},
            // {"white", 1000000000},
            // {"gold", .1},
            // {"silver", .01}
        };

        public static IReadOnlyDictionary<string, double> ToleranceColorBands  { get; } = new Dictionary<string, double> 
        {
            {"brown", .01D},
            {"red", .02D},  
            {"green", .005D},  
            {"blue", .0025D},  
            {"violet", .0001D},  
            {"gold", .05D},  
            {"silver", .1D},  
            {"none", .2D} 
        };
    }
}
