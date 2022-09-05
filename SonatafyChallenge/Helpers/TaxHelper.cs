using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonatafyChallenge
{
    public static class TaxHelper
    {
        public static decimal TaxPercentage(TaxEnum taxEnum)
        {
            switch (taxEnum)
            {
                case TaxEnum.NORMAL: return 0.10m;
                case TaxEnum.EXEMPT: return 0m;
                default: throw new ApplicationException($"TaxEnum {taxEnum} doesn't have a valid value");
            }
        }

        public static decimal RoundTax(decimal value)
        {
            /* Round the value up to the nearest 5 cents */
            return Math.Ceiling(value * 20) / 20;
        }

    }
}
