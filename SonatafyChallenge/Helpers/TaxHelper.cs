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
                case TaxEnum.IMPORT: return 0.05m;
                default: throw new ApplicationException($"TaxEnum {taxEnum} doesn't have a valid value");
            }
        }

    }
}
